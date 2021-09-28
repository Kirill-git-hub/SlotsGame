using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button pauseButton;

    private void Start()
    {
        MainApp.instance.GameController.GameView = this;
        pauseButton.onClick.AddListener(PopupController.instance.InstantiatePausePopup);
        Debug.Log("прикрепил ивент активировать панель паузы");
    }
}
