﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button startGameButton;

    public Button StartGameButton { get => startGameButton; set => startGameButton = value; }

    // Start is called before the first frame update
    void Start()
    {
        InitializeView();
    }

    public void InitializeView()
    {
        MainApp.instance.MainMenuController.MainMenuView = this;
 
        StartGameButton.onClick.AddListener(InitializiGameScene);
    }

    public void InitializiGameScene()
    {
        MainApp.instance.GameController = new GameController();
        SceneManager.LoadScene("GamePlay", LoadSceneMode.Additive);
        RemoveListener();
    }

    public void RemoveListener()
    {
        StartGameButton.onClick.RemoveListener(InitializiGameScene);
    }
}