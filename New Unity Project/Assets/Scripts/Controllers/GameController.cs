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
    }

    //public void InitReels()
    //{
    //    //for(int i = 0; i < reels.Count; i++)
    //    //{
    //    //    reels[i].SpawnReels();
    //    //}
    //    //foreach (ReelSpawner r in reels)
    //    //{
    //    //    r.SpawnReels();
    //    //}

    //    for (int i = 0; i < SlotMachine.ReelContainer.Length; i++)
    //    {
    //        for (int j = 0; j < SlotMachine.ReelContainer[i].transform.childCount; j++)
    //        {
    //            //SlotMachine.ReelContainer[i].transform.GetChild(j).gameObject.
    //        }
    //    }
    //}
}
