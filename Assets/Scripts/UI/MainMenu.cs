﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    string m_SceneName;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        // SceneManager.LoadScene(m_SceneName, LoadSceneMode.Additive);
        SceneManager.LoadScene(m_SceneName, LoadSceneMode.Single);
    }

    public void HowToPlay()
    {

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
