using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class PausePopup : MonoBehaviour
{
    [SerializeField] private Button continueButton = null;
    [SerializeField] private Button exitButton;
    [SerializeField] private string mainMenu;

    private bool inInstantiatedCopy = false;

    public Button ContinueButton { get => continueButton; set => continueButton = value; }
    public Button ExitButton { get => exitButton; set => exitButton = value; }
    public string MainMenu { get => mainMenu; set => mainMenu = value; }
    public bool InInstantiatedCopy { get => inInstantiatedCopy; set => inInstantiatedCopy = value; }

    private void Start()
    {
        PopupController.instance.PausePopup = this;
    }

    public void InstantiatePopup(UnityAction action)
    {
        InInstantiatedCopy = true;

        exitButton.onClick.AddListener(action);
    }

    public void DeactivatePopup()
    {
        if (InInstantiatedCopy)
        {
            Destroy(gameObject);
        }
    }
}
