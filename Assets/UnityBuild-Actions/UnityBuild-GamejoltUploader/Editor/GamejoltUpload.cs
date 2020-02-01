using System.Diagnostics;
using Ionic.Zip;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;
using SuperSystems.UnityBuild;
using System;

public class GamejoltUpload : BuildAction, IPostBuildPerPlatformAction
{
    public string outputPath = "$BUILDPATH";
    public string outputFileName = "$PRODUCT_NAME-$RELEASE_TYPE-$YEAR_$MONTH_$DAY.zip";

    [FilePath(false, true, "Path to gjpush.exe")]
    public string pathTGJPushExe = "";
    public string gameID;
    public string packageID;

    public bool BrowserBuild;

    [Header("Disable to capture error output for debugging.")]
    public bool showUploadProgress = true;

    #region Public Methods

    public override void PerBuildExecute(BuildReleaseType releaseType, BuildPlatform platform, BuildArchitecture architecture, BuildDistribution distribution, System.DateTime buildTime, ref BuildOptions options, string configKey, string buildPath) {
        // Verify that butler executable exists.
        if (!File.Exists(pathTGJPushExe)) {
            UnityEngine.Debug.LogError("Couldn't find gjpush.exe file at path \"" + pathTGJPushExe + "\", please check provided path");
            return;
        }

        string resolvedOutputPath = Path.Combine(outputPath.Replace("$BUILDPATH", buildPath), outputFileName);
        resolvedOutputPath = BuildProject.ResolvePath(resolvedOutputPath, releaseType, platform, architecture, distribution, buildTime);

        if (!resolvedOutputPath.EndsWith(".zip"))
            resolvedOutputPath += ".zip";

        buildPath = Path.GetFullPath(buildPath);
        string zip = Path.GetFullPath(resolvedOutputPath);
        PerformZip(Path.GetFullPath(buildPath), Path.GetFullPath(resolvedOutputPath));

        // Generate build args for the form: butler push {optional args} {build path} {itch username}/{itch game}:{channel}
        StringBuilder scriptArguments = new StringBuilder("");

        scriptArguments.Append(string.Format("-r {0} ", BuildSettings.productParameters.lastGeneratedVersion));

        scriptArguments.Append("-g " + gameID + " -p " + packageID + " ");
        if (BrowserBuild)
            scriptArguments.Append("-b ");
        scriptArguments.Append("\"" + zip+"\"");

        // UnityEngine.Debug.Log("Would have run itch uploader with following command line: \"" + pathToButlerExe + " " + scriptArguments + "\"");
        UnityEngine.Debug.Log(scriptArguments.ToString());
        RunScript(pathTGJPushExe, scriptArguments.ToString());
    }

    #endregion

    #region Private Methods

    private void RunScript(string scriptPath, string arguments) {
        // Create and start butler process.
        ProcessStartInfo startInfo = new ProcessStartInfo();
        startInfo.FileName = Path.GetFullPath(scriptPath);
        startInfo.UseShellExecute = showUploadProgress;
        startInfo.CreateNoWindow = !showUploadProgress;
        startInfo.RedirectStandardOutput = !showUploadProgress;
        startInfo.RedirectStandardError = !showUploadProgress;

        if (!string.IsNullOrEmpty(arguments))
            startInfo.Arguments = arguments;

        Process proc = Process.Start(startInfo);

        StringBuilder outputText = new StringBuilder();
        if (!showUploadProgress) {
            // Capture stdout.
            proc.OutputDataReceived += (sendingProcess, outputLine) => {
                outputText.AppendLine(outputLine.Data);
            };

            proc.BeginOutputReadLine();
        }

        // Wait for butler to finish.
        proc.WaitForExit();

        // Display error if one occurred.
        if (proc.ExitCode != 0) {
            string errString;
            if (showUploadProgress) {
                errString = "Run w/ ShowUploadProgress disabled to capture debug output to console.";
            } else {
                errString = "Check console window for debug output.";
            }

            BuildNotificationList.instance.AddNotification(new BuildNotification(
                BuildNotification.Category.Error,
                "Gamejolt Upload Failed.", string.Format("Exit code: {0}\n{1}", proc.ExitCode, errString),
                true, null));

            UnityEngine.Debug.Log("GJPUSH.EXE OUTPUT: " + outputText.ToString());
        }
    }

    private void PerformZip(string inputPath, string outputPath)
    {
        try
        {
            if (!Directory.Exists(inputPath))
            {
                BuildNotificationList.instance.AddNotification(new BuildNotification(
                    BuildNotification.Category.Error,
                    "Zip Operation Failed.", string.Format("Input path does not exist: {0}", inputPath),
                    true, null));
                return;
            }

            // Make sure that all parent directories in path are already created.
            string parentPath = Path.GetDirectoryName(outputPath);
            if (!Directory.Exists(parentPath))
            {
                Directory.CreateDirectory(parentPath);
            }

            // Delete old file if it exists.
            if (File.Exists(outputPath))
                File.Delete(outputPath);

            using (ZipFile zip = new ZipFile(outputPath))
            {
                zip.ParallelDeflateThreshold = -1; // Parallel deflate is bugged in DotNetZip, so we need to disable it.
                zip.AddDirectory(inputPath);
                zip.Save();
            }
        }
        catch (Exception ex)
        {
            UnityEngine.Debug.LogError(ex.ToString());
        }
    }
    #endregion
}
