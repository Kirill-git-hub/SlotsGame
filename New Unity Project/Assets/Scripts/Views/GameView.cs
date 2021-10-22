using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameView : MonoBehaviour
{
    [SerializeField] private Button pauseButton = null;
    [SerializeField] private Button spinButton = null;
    [SerializeField] private Button increaseBetButton = null;
    [SerializeField] private Button decreaseBetButton = null;
    [SerializeField] private Button increaseLinesCountButton = null;
    [SerializeField] private Button decreaseLinesCountButton = null;
    [SerializeField] private TextMeshProUGUI betText = null;
    [SerializeField] private TextMeshProUGUI linesCountText = null;
    [SerializeField] private TextMeshProUGUI totalWinText = null;

    public Button SpinButton { get => spinButton; set => spinButton = value; }
    public TextMeshProUGUI LinesCountText { get => linesCountText; set => linesCountText = value; }
    public TextMeshProUGUI BetText { get => betText; set => betText = value; }
    public TextMeshProUGUI TotalWinText { get => totalWinText; set => totalWinText = value; }

    private void Start()
    {
        MainApp.instance.GameController.GameView = this;
        AddListener();
        //MainApp.instance.GameController.UpdateLinesCount();

        Debug.Log("прикрепил ивент активировать панель паузы");
    }

    public void AddListener()
    {
        pauseButton.onClick.AddListener(PopupController.instance.InstantiatePausePopup);

        SpinButton.onClick.AddListener(MainApp.instance.GameController.StartSpin);

        increaseLinesCountButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.IncreaseLinesCount();
            MainApp.instance.GameController.UpdateLinesCount();
        });

        decreaseLinesCountButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.DecreaseLinesCount();
            MainApp.instance.GameController.UpdateLinesCount();
        });

        increaseBetButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.IncreaseBet();
            MainApp.instance.GameController.UpdateBet();
        });

        decreaseBetButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.DecreaseBet();
            MainApp.instance.GameController.UpdateBet();
        });
    }

    public void RemoveListener()
    {
        pauseButton.onClick.RemoveListener(PopupController.instance.InstantiatePausePopup);
    }
}
