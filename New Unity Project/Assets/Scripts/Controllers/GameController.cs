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
}
