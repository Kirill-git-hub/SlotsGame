using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController 
{

    private GameView gameView;
    private SlotMachine slotMachine;

    public GameView GameView { get => gameView; set => gameView = value; }
    public SlotMachine SlotMachine { get => slotMachine; set => slotMachine = value; }

    public void StartSpin()
    {
        MainApp.instance.GameController.SlotMachine.CanRotate();
        MainApp.instance.GameController.SlotMachine.TotalWin = 0f;
        MainApp.instance.GameController.GameView.TotalWinText.text = MainApp.instance.GameController.SlotMachine.TotalWin.ToString();  
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
        MainApp.instance.GameController.GameView.LinesCountText.text = 
            MainApp.instance.GameController.SlotMachine.LinesCount.ToString();
    }

    public void UpdateBet()
    {
        MainApp.instance.GameController.GameView.BetText.text = 
            MainApp.instance.GameController.SlotMachine.Bet[MainApp.instance.GameController.SlotMachine.BetIndex].ToString();
    }

    public void UpdateTotalWin()
    {
        MainApp.instance.GameController.GameView.TotalWinText.text = 
            MainApp.instance.GameController.SlotMachine.TotalWin.ToString();
    }
}
