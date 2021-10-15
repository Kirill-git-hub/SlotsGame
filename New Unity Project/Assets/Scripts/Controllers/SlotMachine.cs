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

                for (int r = 0; r < reelsList.Count; r++)
                {
                    reelsList[r].CanSpin = false;

                    for (int child = 0; child < reelsList[r].transform.childCount; child++)
                    {
                        //reelsList[r].transform.GetChild(child).transform.GetChild(reelPrefab.StopWithIndex()).transform.position = new Vector3(transform.position.x, 20.8f, 0);
                        //if (reelsList[r].transform.GetChild(child).transform.GetChild(reelsList[r].Index).gameObject.transform.position.y > 32.1f)
                        //{
                        //    if (reelsList[r].transform.GetChild(child).transform.GetChild(reelsList[r].Index).gameObject.transform.position.y <= 32.1f)
                        //    {
                        //        reelsList[r].transform.GetChild(child).transform.GetChild(reelsList[r].Index).gameObject.transform.position = new Vector3(-50, 32.1f, 0);
                        //    }                      
                        //}
                    }
                }
            }
        }

        if (reelPrefab.CanGetRndIndex)
        {
            for (int i = 0; i < reelContainer.Length; i++)
            {
                reelsList[i].Index = reelsList[i].GetRandomIndexToStop();
            }

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
        for (int i = 0; i < reelsList.Count; i++)
        {
            for (int j = 0; j < reelsList[i].transform.childCount; j++)
            {               
                reelsList[i].transform.GetChild(j).transform.Translate(Vector2.down * Time.deltaTime * reelsList[i].Speed);
            }
        }

        ChangeReelsOrder();
    }

    public void ChangeReelsOrder()
    {
        for (int i = 0; i < reelsList.Count; i++)
        {
            for (int j = 0; j < reelsList[i].transform.childCount; j++)
            {
                if (reelsList[i].transform.GetChild(0).transform.localPosition.y <= -12000)
                {
                    reelsList[i].transform.GetChild(0).transform.localPosition = reelsList[i].transform.GetChild(1).transform.localPosition
                        + new Vector3(0, reelPrefab.BlockRect.rect.height - reelPrefab.Spacing, 0);
                }
                else if (reelsList[i].transform.GetChild(1).transform.localPosition.y <= -12000)
                {
                    reelsList[i].transform.GetChild(1).transform.localPosition = reelsList[i].transform.GetChild(0).transform.localPosition
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
                reelsList.Add(reel);

                //Debug.Log(reelContainer[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(49).name + " - localPosition: " +
                //    reelContainer[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(49).transform.localPosition);
                //Debug.Log(reelContainer[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(49).name + " - position: " +
                //    reelContainer[i].transform.GetChild(0).transform.GetChild(0).transform.GetChild(0).transform.GetChild(49).transform.position);
            }
        }
    }
}
