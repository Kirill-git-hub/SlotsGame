using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuView 
{
    private Button startGameButton;
    [SerializeField] private GameObject mainMenuCanvas;


    private bool isMainMenuActive;

    public Button StartGameButton { get => startGameButton; set => startGameButton = value; }
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
        
        //MainApp.instance.MainMenuController.MainMenuView = this;
        
        //gamePlayCanvas.SetActive(!isMainMenuActive);
        //StartGameButton.onClick.AddListener(SwitchPanels);
        //StartGameButton.onClick.AddListener(MainApp.instance.InitializeGame);
        //MainApp.instance.MainMenu.transform.Find("Canvas_MainMenu/Panel_Background/Button_Play").gameObject.GetComponent<Button>().onClick.AddListener(SwitchPanels);
        startGameButton = GameObject.Find("Canvas_MainMenu/Panel_Background/Button_Play").gameObject.GetComponent<Button>();
        startGameButton.onClick.AddListener(() =>
        {
            //MainApp.instance.InitializeGame();
            SwitchPanels();
        });
    }

    //public void InitializeGameScene()
    //{
    //    MainApp.instance.GameController = new GameController();
    //    //SceneManager.LoadScene(gameScene, LoadSceneMode.Additive);
    //    RemoveListener();
    //}

    public void SwitchPanels()
    {
        DisactivateMainMenuPanel();
        MainApp.instance.GameController.GameView.ActivateGamePanel();
        //mainMenuCanvas.SetActive(!isMainMenuActive);
        //gamePlayCanvas.SetActive(isMainMenuActive);      
    }

    public void ActivateMainMenuPanel()
    {
        mainMenuCanvas.SetActive(true);
    }

    public void DisactivateMainMenuPanel()
    {
        mainMenuCanvas.SetActive(false);
    }

    // public void Init()
    // {
    //     MainApp.instance.GameController.SlotMachine.InstantiateReels();
    // }

    //public void RemoveListener()
    //{
    //    StartGameButton.onClick.RemoveListener(InitializeGameScene);
    //}
}
