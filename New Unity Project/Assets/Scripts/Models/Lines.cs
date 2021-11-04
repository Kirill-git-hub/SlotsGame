using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines
{
    private int winItemCounter = 1;
    private ItemModel winItem = null;
    private ItemModel curentWinItem = null;
    private bool isCorrectItem = true;
    private int[] resultArray = new int[5] { 0, 0, 0, 0, 0 };
    private int[][] payLines =
    {
        new int []{ 0, 0, 0, 0, 0 }, // 0
        new int []{ 1, 1, 1, 1, 1 }, // 1
        new int []{ 2, 2, 2, 2, 2 }, // 2
        new int []{ 0, 1, 2, 1, 0 }, // 3
        new int []{ 2, 1, 0, 1, 2 }, // 4
        new int []{ 1, 0, 1, 0, 1 }, // 5
        new int []{ 1, 2, 1, 2, 1 }, // 6
        new int []{ 0, 0, 1, 2, 2 }, // 7
        new int []{ 2, 2, 1, 0, 0 }, // 8
        new int []{ 1, 2, 1, 0, 1 }, // 9
        new int []{ 1, 0, 1, 2, 1 }, // 10
        new int []{ 0, 1, 1, 1, 0 }, // 11
        new int []{ 2, 1, 1, 1, 2 }, // 12
        new int []{ 0, 1, 0, 1, 0 }, // 13
        new int []{ 2, 1, 2, 1, 2 }, // 14
        new int []{ 1, 1, 0, 1, 1 }, // 15
        new int []{ 1, 1, 2, 1, 1 }, // 16
        new int []{ 0, 0, 2, 0, 0 }, // 17
        new int []{ 2, 2, 0, 2, 2 }, // 18
        new int []{ 0, 2, 2, 2, 0 }, // 19
        new int []{ 0, 1, 2, 2, 2 }, // 20
        new int []{ 2, 1, 0, 0, 0 }, // 21
        new int []{ 0, 2, 0, 2, 0 }, // 22
        new int []{ 2, 0, 2, 0, 2 }, // 23
        new int []{ 1, 0, 2, 0, 1 }, // 24
    };

    public int[] ResultArray => resultArray;
    public int[][] PayLines => payLines;

    public void FillResultArray()
    {
        for (int i = 0; i < ResultArray.Length; i++)
        {
            ResultArray[i] = MainApp.instance.GameController.SlotMachine.ReelsList[i].Index;
        }

        for (int i = 0; i < ResultArray.Length; i++)
        {
            Debug.Log(ResultArray[i]);
        }
    }

    public void CheckLines(int[] generatedIndexes, int[][] linesToCheck)
    {
        for (int lines = 0; lines < MainApp.instance.GameController.SlotMachine.LinesCount; lines++)
        {
            Debug.Log("линия - " + lines);
            int winIndex;
            winItemCounter = 1;
            winItem = null;
            curentWinItem = null;
            isCorrectItem = true;

            for (int reel = 0; reel < generatedIndexes.Length; reel++)
            {
                if (isCorrectItem)
                {
                    winIndex = generatedIndexes[reel] - linesToCheck[lines][reel];
                    Debug.Log(winIndex);

                    if (reel == 0)
                    {
                        winItem = MainApp.instance.GameController.SlotMachine.ReelsList[reel].ItemsList[winIndex];
                    }
                    else
                    {
                        curentWinItem = MainApp.instance.GameController.SlotMachine.ReelsList[reel].ItemsList[winIndex];

                        if (curentWinItem != null)
                        {
                            if (curentWinItem.ItemID == winItem.ItemID)
                            {
                                winItem = curentWinItem;
                                winItemCounter++;
                            }
                            else
                            {
                                isCorrectItem = false;

                                if (winItemCounter >= 2)
                                {
                                    MainApp.instance.GameController.SlotMachine.TotalWin +=
                                        ((MainApp.instance.GameController.SlotMachine.Bet[MainApp.instance.GameController.SlotMachine.BetIndex] /
                                        MainApp.instance.GameController.SlotMachine.LinesCount) * (winItemCounter * winItem.Payout));
                                    Debug.Log(MainApp.instance.GameController.SlotMachine.TotalWin);
                                }
                            }
                        }
                    }
                }
            }

            Debug.Log(winItemCounter);
        }
    }
}
