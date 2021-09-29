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

    [SerializeField] private PausePopup pausePopup = null;
    [SerializeField] private RectTransform popupCanvas = null;

    Popup activePopup;

    public void InstantiatePausePopup()
    {
        MainApp.instance.GameController.GameView.RemoveListener();
        Debug.Log("зашел в метод активировать панель паузы");
        GameObject popupCopy = Instantiate(this.pausePopup.gameObject, popupCanvas);
        PausePopup pausePopup = popupCopy.GetComponent<PausePopup>();
        pausePopup.InstantiatePopup(DeactivateActivePopup, MainApp.instance.MainMenuController.MainMenuView.InitializeView);
        popupCopy.SetActive(true);
        activePopup = pausePopup;
    }

    public void DeactivateActivePopup()
    {
        activePopup.DeactivatePopup();
        activePopup = null;

        MainApp.instance.GameController.GameView.AddListener();
    }
}
