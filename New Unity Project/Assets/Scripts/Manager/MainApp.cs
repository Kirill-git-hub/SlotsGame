using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainApp : MonoBehaviour
{
    public static MainApp instance = null;
    private MainMenuController mainMenuController;
    private GameController gameController;
    private PopupController popupController;

    public MainMenuController MainMenuController { get => mainMenuController; set => mainMenuController = value; }
    public GameController GameController { get => gameController; set => gameController = value; }
    public PopupController PopupController { get => popupController; set => popupController = value; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        PopupController = new PopupController();
        GameController = new GameController();
        MainMenuController = new MainMenuController();
    }

    private void Update()
    {
        GameController.Update();
    }
}
