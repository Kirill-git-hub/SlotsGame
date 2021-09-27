using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    private MainMenuView mainMenuView;

    public MainMenuView MainMenuView { get => mainMenuView; set => mainMenuView = value; }
}
