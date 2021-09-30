using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PausePopup : Popup
{
    [SerializeField] private Button continueButton = null;
    [SerializeField] private Button exitButton = null;

    public void InstantiatePopup(UnityAction action, UnityAction action1)
    {
        isInstantiatedCopy = true;

        continueButton.onClick.AddListener(PopupController.instance.DeactivateActivePopup);

        exitButton.onClick.AddListener(()=>
        {
            SceneLoader.Unload(MainApp.instance.MainMenuController.MainMenuView.GameScene);
            action();
            action1();  
        });
    }
}
