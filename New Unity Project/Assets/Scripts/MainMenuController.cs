﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startButton; 
    [SerializeField] private string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        startButton.onClick.AddListener(StartGameScene);
    }

    public void StartGameScene()
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        startButton.onClick.RemoveAllListeners();
    }
}
