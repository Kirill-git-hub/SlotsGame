﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button pauseButton = null;
    [SerializeField] private Button spinButton = null;

    public Button SpinButton { get => spinButton; set => spinButton = value; }

    private void Start()
    {
        MainApp.instance.GameController.GameView = this;
        AddListener();
        Debug.Log("прикрепил ивент активировать панель паузы");
    }

    public void AddListener()
    {
        pauseButton.onClick.AddListener(PopupController.instance.InstantiatePausePopup);

        SpinButton.onClick.AddListener(MainApp.instance.GameController.StartSpin);
    }

    public void RemoveListener()
    {
        pauseButton.onClick.RemoveListener(PopupController.instance.InstantiatePausePopup);
    }
}
