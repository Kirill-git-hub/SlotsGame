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
            IncreaseLinesCount();
            UpdateLinesCount();
        });

        decreaseLinesCountButton.onClick.AddListener(() => 
        {
            DecreaseLinesCount();
            UpdateLinesCount();
        });

        increaseBetButton.onClick.AddListener(() => 
        {
            IncreaseBet();
            UpdateBet();
        });

        decreaseBetButton.onClick.AddListener(() => 
        {
            DecreaseBet();
            UpdateBet();
        });
    }

    public void RemoveListener()
    {
        pauseButton.onClick.RemoveListener(PopupController.instance.InstantiatePausePopup);
    }

    public void IncreaseBet()
    {
        MainApp.instance.GameController.SlotMachine.BetIndex++;
    }

    public void DecreaseBet()
    {
        MainApp.instance.GameController.SlotMachine.BetIndex--;
    }

    public void IncreaseLinesCount()
    {
        MainApp.instance.GameController.SlotMachine.LinesCount++;
    }

    public void DecreaseLinesCount()
    {
        MainApp.instance.GameController.SlotMachine.LinesCount--;
    }

    public void UpdateLinesCount()
    {
        LinesCountText.text = MainApp.instance.GameController.SlotMachine.LinesCount.ToString();
    }

    public void UpdateBet()
    {
        BetText.text = MainApp.instance.GameController.SlotMachine.Bet[MainApp.instance.GameController.SlotMachine.BetIndex].ToString();
    }

    public void UpdateTotalWin()
    {
        TotalWinText.text = MainApp.instance.GameController.SlotMachine.TotalWin.ToString();
    }
}
