using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView 
{
    private Button startGameButton;
    private GameObject mainMenuCanvas;
    private bool isMainMenuActive;

    public bool IsMainMenuActive { get => isMainMenuActive; set => isMainMenuActive = value; }

    // Start is called before the first frame update
    public MainMenuView()
    {
        IsMainMenuActive = true;
        mainMenuCanvas = GameObject.Find("Canvas_MainMenu");

        InitializeView();
    }

    // public void Start()
    // {

    //     Debug.Log("Start in MainMenuView");
    //     InitializeView();
    // }

    public void InitializeView()
    {
        startGameButton = GameObject.Find("Canvas_MainMenu/Panel_Background/Button_Play").gameObject.GetComponent<Button>();
        startGameButton.onClick.AddListener(() =>
        {
            SwitchPanels();
        });
    }

    public void SwitchPanels()
    {
        DisactivateMainMenuPanel();
        MainApp.instance.GameController.GameView.ActivateGamePanel();    
    }

    public void ActivateMainMenuPanel()
    {
        mainMenuCanvas.SetActive(true);
    }

    public void DisactivateMainMenuPanel()
    {
        mainMenuCanvas.SetActive(false);
    }
}
