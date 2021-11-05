using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine
{
    Reel genericReel = new Reel();
    private List<GameObject> reelsContainer = new List<GameObject>();
    private List<Reel> reelsList = new List<Reel>();
    private List<GameObject> reelsObjList = new List<GameObject>();
    private Lines lines;
    private GameObject slotMachineObj;
    private const int MinLinesCount = 1;
    private const int MaxLinesCount = 25;
    private const int MinBetIndex = 0;
    private const int MaxBetIndex = 5;
    private float timeLeft;
    private float[] bet = { 1, 2, 5, 10, 25, 50 };
    private int betIndex = MinBetIndex;
    private float linesCount = MinLinesCount;
    private float totalWin = 0f;

    public List<Reel> ReelsList { get => reelsList; set => reelsList = value; }
    public Lines Lines { get => lines; set => lines = value; }
    public float[] Bet { get => bet; set => bet = value; }
    public float LinesCount
    {
        get => linesCount;
        set
        {
            if (value < MinLinesCount)
                value = MinLinesCount;
            else if (value > MaxLinesCount)
                value = MaxLinesCount;
            else
                linesCount = value;
        }
    }
    public float TotalWin { get => totalWin; set => totalWin = value; }
    public int BetIndex
    {
        get => betIndex;
        set
        {
            if (value < MinBetIndex)
                value = MinBetIndex;
            else if (value > MaxBetIndex)
                value = MaxBetIndex;
            else
                betIndex = value;
        }
    }

    public GameObject SlotMachineObj { get => slotMachineObj; set => slotMachineObj = value; }
    public List<GameObject> ReelsObjList { get => reelsObjList; set => reelsObjList = value; }

    public SlotMachine()
    {
        SlotMachineObj = GameObject.Find("Canvas_GamePlay/Panel_Background/Panel_Slots/SlotMachine");
        Lines = new Lines();
        AddSpawners();
        InstantiateReels();
    }

    public void AddSpawners()
    {
        for (int i = 0; i < SlotMachineObj.transform.childCount; i++)
        {
            Transform container = SlotMachineObj.transform.GetChild(i).transform;

            for (int j = 0; j < SlotMachineObj.transform.GetChild(i).childCount; j++)
            {
                reelsContainer.Add(container.GetChild(j).gameObject);
            }
        }
    }

    // Update is called once per frame
    public void Update()
    {
        if (genericReel.CanSpin)
        {
            StartRotating();

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                SetButtonsInteractable(true);

                for (int r = 0; r < ReelsList.Count; r++)
                {
                    ReelsList[r].CanSpin = false;

                    if (ReelsList[r].Index >= 0 && ReelsList[r].Index <= 49)
                    {
                        reelsObjList[r].transform.GetChild(0).transform.localPosition = new Vector3
                        (0, ReelsList[r].Index * ((ReelsList[r].Width + ReelsList[r].Spacing)), 0);

                        reelsObjList[r].transform.GetChild(1).transform.localPosition =
                        reelsObjList[r].transform.GetChild(0).transform.localPosition -
                        new Vector3(0, ReelsList[r].Height, 0);
                    }
                    else if (ReelsList[r].Index >= 50 && ReelsList[r].Index <= 97)
                    {
                        reelsObjList[r].transform.GetChild(1).transform.localPosition = new Vector3
                        (0, (ReelsList[r].Index - 50) * ((ReelsList[r].Width + ReelsList[r].Spacing)), 0);

                        reelsObjList[r].transform.GetChild(0).transform.localPosition =
                        reelsObjList[r].transform.GetChild(1).transform.localPosition +
                        new Vector3(0, ReelsList[r].Height, 0);
                    }
                }

                Lines.CheckLines(Lines.ResultArray, Lines.PayLines);
                MainApp.instance.GameController.GameView.UpdateTotalWin();
            }
        }

        if (genericReel.CanGetRndIndex)
        {
            for (int i = 0; i < reelsList.Count; i++)
            {
                ReelsList[i].Index = ReelsList[i].GetRandomIndexToStop();
            }

            Lines.FillResultArray();

            genericReel.CanGetRndIndex = false;
        }
    }

    public void CanRotate()
    {
        genericReel.CanGetRndIndex = true;
        genericReel.CanSpin = true;
        SetButtonsInteractable(false);
        timeLeft = 3f; 
    }

    public void StartRotating()
    {
        for (int i = 0; i < reelsObjList.Count; i++)
        {
            for (int j = 0; j < reelsObjList[i].transform.childCount; j++)
            {
                reelsObjList[i].transform.GetChild(j).transform.Translate(Vector2.down * Time.deltaTime * ReelsList[i].ReelSpeed);
            }
        }

        ChangeReelsOrder();
    }

    public void ChangeReelsOrder()
    {
        for (int i = 0; i < reelsObjList.Count; i++)
        {
            for (int j = 0; j < reelsObjList[i].transform.childCount; j++)
            {
                if (reelsObjList[i].transform.GetChild(0).transform.localPosition.y <=
                (-ReelsList[i].Height - (ReelsList[i].Width + ReelsList[i].Spacing)))
                {
                    reelsObjList[i].transform.GetChild(0).transform.localPosition =
                    reelsObjList[i].transform.GetChild(1).transform.localPosition
                    + new Vector3(0, ReelsList[i].Height - ReelsList[i].Spacing, 0);
                }
                else if (reelsObjList[i].transform.GetChild(1).transform.localPosition.y <=
                (-ReelsList[i].Height - (ReelsList[i].Width + ReelsList[i].Spacing)))
                {
                    reelsObjList[i].transform.GetChild(1).transform.localPosition =
                    reelsObjList[i].transform.GetChild(0).transform.localPosition
                    + new Vector3(0, ReelsList[i].Height + ReelsList[i].Spacing, 0);
                }
            }
        }
    }

    public void InstantiateReels()
    {
        for (int i = 0; i < reelsContainer.Count; i++)
        {
            ReelsList.Add(new Reel(reelsContainer[i].transform));
        }

        foreach (GameObject item in reelsContainer)
        {
            ReelsObjList.Add(item.transform.GetChild(0).gameObject);
        }
    }

    public void SetButtonsInteractable(bool interactable)
    {
        MainApp.instance.GameController.GameView.SetInteractable(interactable);
    }
}
