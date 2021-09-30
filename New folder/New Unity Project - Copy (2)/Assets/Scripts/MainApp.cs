using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainApp : MonoBehaviour
{
    public static MainApp instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private MainMenuController mainMenuController;
    private GameController gameController;

    public MainMenuController MainMenuController { get => mainMenuController; set => mainMenuController = value; }
    public GameController GameController { get => gameController; set => gameController = value; }

    private void Start()
    {
        mainMenuController = new MainMenuController();
    }
}
