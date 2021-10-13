using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    [SerializeField] private GameObject[] reelContainer = null;
    [SerializeField] private Reel reelPrefab = null;

    [SerializeField] private List<Reel> reelsList = new List<Reel>();
    private float timeLeft;
    public Reel ReelPrefab => reelPrefab;

    public GameObject[] ReelContainer { get => reelContainer; set => reelContainer = value; }

    // Start is called before the first frame update
    void Start()
    {
        MainApp.instance.GameController.SlotMachine = this;
        InstantiateReels();
        timeLeft = 5f;
        //MainApp.instance.GameController.InitReels();

        //InstantiateReelsAtFinalPos();
        //InstantiateReelsAtStartingPos();
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
                ClearReelsList();
            }

            if (timeLeft <= -1)
            {
                InstantiateReels();
                reelPrefab.CanSpin = false;
                timeLeft = 5;
            }
        }

        //CheckReelOrder();

        //ClearReelList();

        //if (reelPrefab.CanSpin)
        //{
        //    StartRotating();

        //    CheckReelOrder();

        //    ClearReelList();
        //}
    }

    public void InstantiateReelsAtFinalPos()
    {
        for (int i = 0; i < ReelContainer.Length; i++)
        {
            Reel reel = Instantiate(ReelPrefab, ReelContainer[i].transform);
            reel.IsCurrent = true;
            reelsList.Add(reel);
            SetReelPosition(reel, reel.FinalPos);
        }
    }

    public void InstantiateReelsAtStartingPos()
    {
        for (int i = 0; i < ReelContainer.Length; i++)
        {
            Reel reel = Instantiate(ReelPrefab, ReelContainer[i].transform);
            reel.IsFirst = true;
            reelsList.Add(reel);
            SetReelPosition(reel, reel.StartingPos);
        }
    }

    private void SetReelPosition(Reel reel, Vector3 currentPos)
    {
        reel.SetPosition(currentPos);
    }

    public void CanRotate()
    {
        reelPrefab.CanSpin = true;
        
        //foreach (Reel r in reelsList)
        //{
        //    if (!r.CanSpin)
        //    {
        //        r.CanSpin = true;
        //        r.Speed = 100f;
        //    }
        //    else
        //    {
        //        r.CanSpin = false;
        //        r.Speed = 0f;
        //    }
        //}
    }

    public void StartRotating()
    {
        //for (int i = 0; i < ReelContainer.Length; i++)
        //{
        //    for (int j = 0; j < ReelContainer[i].transform.childCount; j++)
        //    {
        //        float speed = ReelContainer[i].transform.GetChild(j).GetComponent<Reel>().Speed;
        //        ReelContainer[i].transform.GetChild(j).GetComponent<Reel>().RotateReel(speed);
        //    }
        //}

        foreach (Reel reels in reelsList)
        {
            reels.RotateReel(reelPrefab.Speed);
        }
    }

    public void ClearReelsList()
    {
        for (int i = 0; i < reelsList.Count; i++)
        {
            reelsList[i].DestroyReel();
        }
        reelsList.Clear();
    }

    //public void CheckReelOrder()
    //{
    //    foreach (Reel reels in reelsList)
    //    {
    //        if (reels.transform.localPosition.y >= (-ReelPrefab.ReelRect.rect.height / 2) &&
    //            reels.transform.localPosition.y <= (ReelPrefab.ReelRect.rect.height / 2))
    //        {
    //            reels.IsCurrent = true;
    //            reels.IsFirst = false;
    //            reels.IsLast = false;
    //        }
    //        else if (reels.transform.localPosition.y >= (ReelPrefab.ReelRect.rect.height / 2))
    //        {
    //            reels.IsCurrent = false;
    //            reels.IsFirst = true;
    //            reels.IsLast = false;
    //        }
    //        else if (reels.transform.localPosition.y <= (-ReelPrefab.ReelRect.rect.height / 2))
    //        {
    //            reels.IsCurrent = false;
    //            reels.IsFirst = false;
    //            reels.IsLast = true;
    //        }        
    //    }
    //}

    public void InstantiateReels()
    {
        for (int i = 0; i < reelContainer.Length; i++)
        {
            for (int j = 0; j < reelContainer[i].transform.childCount; j++)
            {
                Reel reel = Instantiate(reelPrefab, reelContainer[i].transform.GetChild(j).transform);
                reelsList.Add(reel);
            }
        }
    }
}
