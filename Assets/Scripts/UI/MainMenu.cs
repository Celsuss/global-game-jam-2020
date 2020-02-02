using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string m_SceneName;
    [SerializeField]
    GameObject m_HowToPlayImage;
    
    bool m_ShowHowToPlayImage = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // m_HowToPlayRawImage = m_HowToPlayRawImage.getComponent<RawImage>();
    }

    // Update is called once per frame
    void Update()
    {
        if(m_ShowHowToPlayImage && Input.anyKeyDown){
            HideHowToPlay();
        }
    }

    public void StartGame()
    {
        // SceneManager.LoadScene(m_SceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(m_SceneName, LoadSceneMode.Single);
    }

    private void HideHowToPlay()
    {
        m_HowToPlayImage.active = false;
        m_ShowHowToPlayImage = false;
    }

    public void ShowHowToPlay()
    {
        m_HowToPlayImage.active = true;
        m_ShowHowToPlayImage = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
