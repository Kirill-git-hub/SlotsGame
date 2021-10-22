using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] reelContainer = null;
    [SerializeField] private Reel reelPrefab = null;
    [SerializeField] private List<Reel> reelsList = new List<Reel>();
    [SerializeField] private Lines lines;

    private const int MinLinesCount = 1;
    private const int MaxLinesCount = 25;
    private const int MinBetIndex = 0;
    private const int MaxBetIndex = 5;

    private float timeLeft;
    private int[] bet = { 1, 2, 5, 10, 25, 50};
    private int betIndex = MinBetIndex;
    private int linesCount = MinLinesCount;
    private float totalWin;

    public Reel ReelPrefab => reelPrefab;
    public GameObject[] ReelContainer { get => reelContainer; set => reelContainer = value; }
    public List<Reel> ReelsList { get => reelsList; set => reelsList = value; }
    public Lines Lines { get => lines; set => lines = value; }
    public int[] Bet { get => bet; set => bet = value; }
    public int LinesCount
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

    // Start is called before the first frame update
    void Start()
    {
        MainApp.instance.GameController.SlotMachine = this;
        InstantiateReels();
    }

    // Update is called once per frame
    void Update()
    {     
        if (reelPrefab.CanSpin)
        {
            StartRotating();

            timeLeft -= Time.deltaTime;

            if (timeLeft <= 0)
            {
                MainApp.instance.GameController.GameView.SpinButton.interactable = true;

                for (int r = 0; r < ReelsList.Count; r++)
                {
                    ReelsList[r].CanSpin = false;

                    if (ReelsList[r].Index >= 2 && ReelsList[r].Index <= 49)
                    {
                        ReelsList[r].transform.GetChild(0).transform.localPosition = new Vector3
                            (0, ReelsList[r].Index * (-(ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)), 0);

                        ReelsList[r].transform.GetChild(1).transform.localPosition = 
                            ReelsList[r].transform.GetChild(0).transform.localPosition +
                            new Vector3(0, ReelPrefab.BlockRect.rect.height, 0);                   
                    }
                    //else if (ReelsList[r].Index >= 0 && ReelsList[r].Index < 2)
                    //{
                    //    ReelsList[r].transform.GetChild(0).transform.localPosition = new Vector3
                    //        (0, ReelsList[r].Index * -((ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)), 0);

                    //    ReelsList[r].transform.GetChild(1).transform.localPosition = new Vector3
                    //        (ReelsList[r].transform.GetChild(1).transform.localPosition.x,
                    //       -ReelPrefab.BlockRect.rect.height - ((ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing) * ReelsList[r].Index),
                    //       ReelsList[r].transform.GetChild(1).transform.localPosition.z);
                    //}

                    if (ReelsList[r].Index >= 52 && ReelsList[r].Index <= 99)
                    {
                        ReelsList[r].transform.GetChild(1).transform.localPosition = new Vector3
                            (0, (ReelsList[r].Index -50) * -(ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing), 0);

                        ReelsList[r].transform.GetChild(0).transform.localPosition = 
                            ReelsList[r].transform.GetChild(1).transform.localPosition +
                            new Vector3(0, ReelPrefab.BlockRect.rect.height, 0);
                    }
                    //else if (ReelsList[r].Index >= 50 && ReelsList[r].Index < 52)
                    //{
                    //    ReelsList[r].transform.GetChild(1).transform.localPosition = new Vector3
                    //        (0, (ReelsList[r].Index - 50) * -(ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing), 0);

                    //    ReelsList[r].transform.GetChild(0).transform.localPosition = new Vector3
                    //        (ReelsList[r].transform.GetChild(0).transform.localPosition.x,
                    //        -ReelPrefab.BlockRect.rect.height - ((ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing) * (ReelsList[r].Index - 50)),
                    //        ReelsList[r].transform.GetChild(0).transform.localPosition.z);
                    //}
                }
            }
        }

        if (reelPrefab.CanGetRndIndex)
        {
            for (int i = 0; i < reelContainer.Length; i++)
            {
                ReelsList[i].Index = ReelsList[i].GetRandomIndexToStop();
            }
            Lines.FillResultArray();
            Lines.CheckLines(Lines.ResultArray, Lines.PayLines);

            reelPrefab.CanGetRndIndex = false;
        }
    }

    public void CanRotate()
    {
        reelPrefab.CanSpin = true;
        reelPrefab.CanGetRndIndex = true;
        MainApp.instance.GameController.GameView.SpinButton.interactable = false;
        timeLeft = 5f;
    }

    public void StartRotating()
    {
        for (int i = 0; i < ReelsList.Count; i++)
        {
            for (int j = 0; j < ReelsList[i].transform.childCount; j++)
            {               
                ReelsList[i].transform.GetChild(j).transform.Translate(Vector2.down * Time.deltaTime * ReelsList[i].Speed);
            }
        }

        ChangeReelsOrder();
    }

    public void ChangeReelsOrder()
    {
        for (int i = 0; i < ReelsList.Count; i++)
        {
            for (int j = 0; j < ReelsList[i].transform.childCount; j++)
            {
                if (ReelsList[i].transform.GetChild(0).transform.localPosition.y <= 
                    (-ReelPrefab.BlockRect.rect.height - (ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)))
                {
                    ReelsList[i].transform.GetChild(0).transform.localPosition = 
                        ReelsList[i].transform.GetChild(1).transform.localPosition
                        + new Vector3(0, reelPrefab.BlockRect.rect.height - reelPrefab.Spacing, 0);
                }
                else if (ReelsList[i].transform.GetChild(1).transform.localPosition.y <= 
                    (-ReelPrefab.BlockRect.rect.height - (ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)))
                {
                    ReelsList[i].transform.GetChild(1).transform.localPosition =
                        ReelsList[i].transform.GetChild(0).transform.localPosition
                        + new Vector3(0, reelPrefab.BlockRect.rect.height + reelPrefab.Spacing, 0);
                }
            }
        }
    }

    public void InstantiateReels()
    {
        for (int i = 0; i < reelContainer.Length; i++)
        {
            for (int j = 0; j < reelContainer[i].transform.childCount; j++)
            {
                Reel reel = Instantiate(reelPrefab, reelContainer[i].transform.GetChild(j).transform);
                ReelsList.Add(reel);
            }
        }
    }
}
