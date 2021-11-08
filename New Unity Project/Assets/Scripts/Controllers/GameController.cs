using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    private GameView gameView;
    private SlotMachine slotMachine;

    public GameView GameView { get => gameView; set => gameView = value; }
    public SlotMachine SlotMachine { get => slotMachine; set => slotMachine = value; }

    public GameController()
    {
        SlotMachine = new SlotMachine();
        GameView = new GameView();
    }

    public void Update()
    {
        SlotMachine.Update();
    }

    public void StartSpin()
    {
        SlotMachine.CanRotate();
        SlotMachine.TotalWin = 0f;
        MainApp.instance.GameController.GameView.UpdateTotalWin();
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
