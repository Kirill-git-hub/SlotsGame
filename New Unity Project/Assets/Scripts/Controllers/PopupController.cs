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

    [SerializeField] private PausePopup popupView;
    [SerializeField] private RectTransform popupCanvas;

    public PausePopup PopupView { get => popupView; set => popupView = value; }

    public void InstantiatePausePopup()
    {
        Debug.Log("зашел в метод активировать панель паузы");
        GameObject popupCopy = Instantiate(popupView.gameObject, popupCanvas);
        //PausePopup popupview = popupCopy.GetComponent<PausePopup>();
        popupCopy.SetActive(true);

        PopupView.ExitButton.onClick.AddListener(SwitchToMainMenu);
    }

    public void SwitchToMainMenu()
    {
        SceneManager.LoadScene(PopupView.MainMenu, LoadSceneMode.Additive);
    }
}
