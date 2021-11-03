using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PausePopup : Popup
{
    private Button continueButton = null;
    private Button exitButton = null;
    private GameObject pausePopupPanel;

    public PausePopup()
    {
        pausePopupPanel = GameObject.Find("Canvas_Popups/PausePopup");
        exitButton = pausePopupPanel.transform.Find("Panel_Pause/ButtonsContainer/Button_Exit").GetComponent<Button>();
        continueButton = pausePopupPanel.transform.Find("Panel_Pause/ButtonsContainer/Button_ContinueGame").GetComponent<Button>();

        continueButton.onClick.AddListener(() => DisactivatePopup(pausePopupPanel));
        exitButton.onClick.AddListener(() => 
        {
            DisactivatePopup(pausePopupPanel);
            MainApp.instance.GameController.GameView.DisactivateGamePanel();
            MainApp.instance.MainMenuController.MainMenuView.ActivateMainMenuPanel();
        });

        DisactivatePopup(pausePopupPanel);
    }

    public void SetActivePausePopup()
    {
        pausePopupPanel.SetActive(isActivePopup);
    }

    // public void ClearReel()
    // {
    //     MainApp.instance.GameController.SlotMachine.ClearReels();
    // }
}
