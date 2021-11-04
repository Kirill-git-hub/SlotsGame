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

    // Start is called before the first frame update
    public MainMenuView()
    {
        isMainMenuActive = true;

        mainMenuCanvas = GameObject.Find("Canvas_MainMenu");
        startGameButton = mainMenuCanvas.transform.Find("Panel_Background/Button_Play").gameObject.GetComponent<Button>();

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
        mainMenuCanvas.SetActive(isMainMenuActive);
    }

    public void DisactivateMainMenuPanel()
    {
        mainMenuCanvas.SetActive(!isMainMenuActive);
    }
}
