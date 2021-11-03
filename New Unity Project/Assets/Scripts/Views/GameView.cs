using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameView 
{
    private PopupController popupController;
    private GameObject gamePlayCanvas;
    private Button spinButton = null;
    private Button increaseBetButton = null;
    private Button decreaseBetButton = null;
    private Button increaseLinesCountButton = null;
    private Button decreaseLinesCountButton = null;
    private TextMeshProUGUI betText = null;
    private TextMeshProUGUI linesCountText = null;
    private TextMeshProUGUI totalWinText = null;

    private Button pauseButton = null;
    private GameObject pausePopup = null;
    private GameObject panel = null;
    private GameObject gamePanel = null;
    private GameObject betLinesContainer;

    public Button SpinButton { get => spinButton; set => spinButton = value; }
    public TextMeshProUGUI LinesCountText { get => linesCountText; set => linesCountText = value; }
    public TextMeshProUGUI BetText { get => betText; set => betText = value; }

    public GameView()
    {
        gamePlayCanvas = GameObject.Find("Canvas_GamePlay/Panel_Background");
        SpinButton = gamePlayCanvas.transform.Find("Panel_UI/Button_Spin").GetComponent<Button>();
        pauseButton = gamePlayCanvas.transform.Find("Button_Pause").GetComponent<Button>();
        betLinesContainer = gamePlayCanvas.transform.Find("Panel_UI/BetLinesContainer").gameObject;
        increaseBetButton = betLinesContainer.transform.Find("Bet/Button_Plus").GetComponent<Button>();
        decreaseBetButton = betLinesContainer.transform.Find("Bet/Button_Minus").GetComponent<Button>();
        increaseLinesCountButton = betLinesContainer.transform.Find("Lines/Button_Plus").GetComponent<Button>();
        decreaseLinesCountButton = betLinesContainer.transform.Find("Lines/Button_Minus").GetComponent<Button>();
        betText = betLinesContainer.transform.Find("Bet/Text_ShowBet").GetComponent<TextMeshProUGUI>();
        linesCountText = betLinesContainer.transform.Find("Lines/Text_ShowLinesCount").GetComponent<TextMeshProUGUI>();
        totalWinText = gamePlayCanvas.transform.Find("Panel_UI/TotalWin/Text_ShowTotalWin").GetComponent<TextMeshProUGUI>();

        SpinButton.onClick.AddListener(Spin);
        pauseButton.onClick.AddListener(PauseButtonOnClick);

        increaseLinesCountButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.IncreaseLinesCount();
            UpdateLinesCount();
        });

        decreaseLinesCountButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.DecreaseLinesCount();
            UpdateLinesCount();
        });

        increaseBetButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.IncreaseBet();
            UpdateBet();
        });

        decreaseBetButton.onClick.AddListener(() => 
        {
            MainApp.instance.GameController.DecreaseBet();
            UpdateBet();
        });

        DisactivateGamePanel();
    }

    public void ActivateGamePanel()
    {
        gamePlayCanvas.SetActive(true);
    }

    public void DisactivateGamePanel()
    {
        gamePlayCanvas.SetActive(false);
    }

    private void Spin()
    {
        MainApp.instance.GameController.StartSpin();
    }

    public void Start()
    {

        Debug.Log("прикрепил ивент активировать панель паузы");

    }

    public void PauseButtonOnClick()
    {
        MainApp.instance.PopupController.PausePopup.SetActivePausePopup();
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
        totalWinText.text = MainApp.instance.GameController.SlotMachine.TotalWin.ToString();
    }
}
