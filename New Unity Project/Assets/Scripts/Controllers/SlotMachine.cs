﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine : MonoBehaviour
{
    //[SerializeField] private Reel[] reelModels;
    [SerializeField] private GameObject[] reelContainer = null;
    [SerializeField] private Reel reelPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        MainApp.instance.GameController.SlotMachine = this;

        InstantiateReelsAtFinalPos();
    }

    // Update is called once per frame
    void Update()
    {
        StartRotating();
    }

    public void InstantiateReelsAtFinalPos()
    {
        for (int i = 0; i < reelContainer.Length; i++)
        {
            Reel reel = Instantiate(reelPrefab, reelContainer[i].transform);

            SetReelPosition(reel, reel.FinalPos);
        }
    }

    public void InstantiateReelsAtStartingPos()
    {
        for (int i = 0; i < reelContainer.Length; i++)
        {
            Reel reel = Instantiate(reelPrefab, reelContainer[i].transform);

            SetReelPosition(reel, reel.StartingPos);
        }
    }

    private void SetReelPosition(Reel reel, Vector3 currentPos)
    {
        reel.SetPosition(currentPos);
    }

    public void StartRotating()
    {
        //StartCoroutine(RotateNextReel());
        //for (int i = 0; i < reelSet.Length; i++)
        //{
        //    for (int j = 0; j < reelSet[i].transform.childCount; j++)
        //    {
        //        float speed = reelSet[i].transform.GetChild(j).GetComponent<Reel>().Speed;
        //        reelSet[i].transform.GetChild(j).GetComponent<Reel>().RotateReel(speed);
        //    }
        //}
    }

    //public IEnumerator RotateNextReel()
    //{
    //    for (int i = 0; i < reelSet.Length; i++)
    //    {
    //        for (int j = 0; j < reelSet[i].transform.childCount; j++)
    //        {
    //            float speed = reelSet[i].transform.GetChild(j).GetComponent<Reel>().Speed;
    //            reelSet[i].transform.GetChild(j).GetComponent<Reel>().RotateReel(speed);
    //        }
    //        yield return new WaitForSeconds(Random.Range(0.3f,1f));
    //    }
    //}
}
