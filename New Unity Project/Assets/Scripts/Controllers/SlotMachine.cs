using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    //[SerializeField] private Reel[] reelModels;
    [SerializeField] private GameObject[] reelContainer = null;
    [SerializeField] private Reel reelPrefab = null;

    [SerializeField] private List<Reel> reelsList = new List<Reel>();

    // Start is called before the first frame update
    void Start()
    {
        MainApp.instance.GameController.SlotMachine = this;

        InstantiateReelsAtFinalPos();
        InstantiateReelsAtStartingPos();
    }

    // Update is called once per frame
    void Update()
    {
        StartRotating();

        CheckReelOrder();

        ClearReelList();
    }  

    public void InstantiateReelsAtFinalPos()
    {
        for (int i = 0; i < reelContainer.Length; i++)
        {
            Reel reel = Instantiate(reelPrefab, reelContainer[i].transform);
            reel.IsCurrent = true;
            reelsList.Add(reel);
            SetReelPosition(reel, reel.FinalPos);
        }
    }

    public void InstantiateReelsAtStartingPos()
    {
        for (int i = 0; i < reelContainer.Length; i++)
        {
            Reel reel = Instantiate(reelPrefab, reelContainer[i].transform);
            reelsList.Add(reel);
            SetReelPosition(reel, reel.StartingPos);
        }
    }

    private void SetReelPosition(Reel reel, Vector3 currentPos)
    {
        reel.SetPosition(currentPos);
    }

    public void StartRotating()
    {
        for (int i = 0; i < reelContainer.Length; i++)
        {
            for (int j = 0; j < reelContainer[i].transform.childCount; j++)
            {
                float speed = reelContainer[i].transform.GetChild(j).GetComponent<Reel>().Speed;
                reelContainer[i].transform.GetChild(j).GetComponent<Reel>().RotateReel(speed);
            }
        }
    }

    public void ClearReelList()
    {
        for (int i = 0; i < reelsList.Count; i++)
        {
            if (reelsList[i].IsLast && reelsList[i].transform.localPosition.y <= -reelPrefab.ReelRect.rect.height)
            {

                reelsList[i].DestroyReel();
                reelsList.Remove(reelsList[i]);
            }
        }
    }

    public void CheckReelOrder()
    {
        foreach (Reel reels in reelsList)
        {

            if (reels.transform.localPosition.y >= (-reelPrefab.ReelRect.rect.height / 2) &&
                reels.transform.localPosition.y <= (reelPrefab.ReelRect.rect.height / 2))
            {
                reels.IsCurrent = true;
                reels.IsFirst = false;
                reels.IsLast = false;
            }
            else if (reels.transform.localPosition.y >= (reelPrefab.ReelRect.rect.height / 2))
            {
                reels.IsCurrent = false;
                reels.IsFirst = true;
                reels.IsLast = false;
            }
            else if (reels.transform.localPosition.y <= (-reelPrefab.ReelRect.rect.height / 2))
            {
                reels.IsCurrent = false;
                reels.IsFirst = false;
                reels.IsLast = true;
            }
        }
    }
}
