using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PausePopup : Popup
{
    //protected bool isActivePopup = true;
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

        //pausePopupPanel.SetActive(!isActivePopup);
        DisactivatePopup(pausePopupPanel);
    }

    public void SetActivePausePopup()
    {
        pausePopupPanel.SetActive(isActivePopup);
    }

    // public void ClearRel()
    // {
    //     MainApp.instance.GameController.SlotMachine.ClearReels();
    // }

    public void InstantiatePopup(UnityAction action, UnityAction action1)
    {
        //isInstantiatedCopy = true;
        //isActivePopup = true;

        //continueButton.onClick.AddListener(PopupController.instance.DeactivateActivePopup);
        //continueButton.onClick.AddListener(MainApp.instance.GameController.PopupController.DeactivateActivePopup);

        //exitButton.onClick.AddListener(()=>
        //{
        //    //SceneLoader.Unload(MainApp.instance.MainMenuController.MainMenuView.GameScene);
        //    action();
        //    action1();  
        //});
    }
}
