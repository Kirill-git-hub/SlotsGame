using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    public static PopupController instance = null;

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
    }

    [SerializeField] private PausePopup pausePopup;
    [SerializeField] private RectTransform popupCanvas;

    private PausePopup activePopup;

    public PausePopup PausePopup { get => pausePopup; set => pausePopup = value; }

    public void InstantiatePausePopup()
    {
        Debug.Log("зашел в метод активировать панель паузы");
        GameObject popupCopy = Instantiate(this.pausePopup.gameObject, popupCanvas);
        PausePopup pausePopup = popupCopy.GetComponent<PausePopup>();
        pausePopup.InstantiatePopup(SwitchToMainMenu);
        popupCopy.SetActive(true);
        activePopup = pausePopup;
    }

    public void SwitchToMainMenu()
    {
        SceneManager.UnloadScene("GamePlay");
        DeactivateActivePopup();
        MainApp.instance.MainMenuController.MainMenuView.StartGameButton.onClick.AddListener(MainApp.instance.MainMenuController.MainMenuView.InitializiGameScene);
    }

    public void DeactivateActivePopup()
    {
        activePopup.DeactivatePopup();
        activePopup = null;
    }
}
