using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController 
{
    private GameView gameView;
    private SlotMachine slotMachine;
    private PopupController popupController;

    public GameView GameView { get => gameView; set => gameView = value; }
    public SlotMachine SlotMachine { get => slotMachine; set => slotMachine = value; }
    public PopupController PopupController { get => popupController; set => popupController = value; }

    public GameController()
    {
        SlotMachine = new SlotMachine();
        GameView = new GameView();
    }

    public void Start()
    {
        Debug.Log("Start in GameController");

        GameView.Start();
    }

    public void StartSpin()
    {
        SlotMachine.CanRotate();
        SlotMachine.TotalWin = 0f;
        MainApp.instance.GameController.GameView.UpdateTotalWin();

        Debug.Log("start spin method"); 
    }

    public void IncreaseBet()
    {
        SlotMachine.BetIndex++;
    }

    public void DecreaseBet()
    {
        SlotMachine.BetIndex--;
    }

    public void IncreaseLinesCount()
    {
        SlotMachine.LinesCount++;
    }

    public void DecreaseLinesCount()
    {
        SlotMachine.LinesCount--;
    }
}
