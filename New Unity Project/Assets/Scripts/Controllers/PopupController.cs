using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupController 
{
    private PausePopup pausePopup;

    public PausePopup PausePopup { get => pausePopup; set => pausePopup = value; }

    public PopupController()
    {
        pausePopup = new PausePopup();
    }


    public void InstantiatePausePopup()
    {
        //pausePopup.gameObject.SetActive(true);

        //MainApp.instance.GameController.GameView.RemoveListener();
        //Debug.Log("зашел в метод активировать панель паузы");
        //GameObject popupCopy = Object.Instantiate(Resources.Load<GameObject>("Assets/Resources/Pause.prefab"), popupCanvas);
        //PausePopup pausePopup = popupCopy.GetComponent<PausePopup>();
        //pausePopup.InstantiatePopup(DeactivateActivePopup, MainApp.instance.MainMenuController.MainMenuView.InitializeView);
        //popupCopy.SetActive(true);
        //activePopup = pausePopup;
    }

    // public void DeactivateActivePopup()
    // {
    //     activePopup.DeactivatePopup();
    //     activePopup = null;

    //     MainApp.instance.GameController.GameView.AddListener();
    // }
}
