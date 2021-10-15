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

                    if (reelsList[r].Index >= 2 && reelsList[r].Index <= 49)
                    {
                        reelsList[r].transform.GetChild(0).transform.localPosition = new Vector3
                            (0, reelsList[r].Index * (-(ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)), 0);

                        reelsList[r].transform.GetChild(1).transform.localPosition = 
                            reelsList[r].transform.GetChild(0).transform.localPosition +
                            new Vector3(0, ReelPrefab.BlockRect.rect.height, 0);                   
                    }
                    else if (reelsList[r].Index >= 0 && reelsList[r].Index < 2)
                    {
                        reelsList[r].transform.GetChild(0).transform.localPosition = new Vector3
                            (0, reelsList[r].Index * -((ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)), 0);

                        reelsList[r].transform.GetChild(1).transform.localPosition = new Vector3
                            (reelsList[r].transform.GetChild(1).transform.localPosition.x,
                           -ReelPrefab.BlockRect.rect.height - ((ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing) * reelsList[r].Index),
                           reelsList[r].transform.GetChild(1).transform.localPosition.z);
                    }

                    if (reelsList[r].Index >= 52 && reelsList[r].Index <= 99)
                    {
                        reelsList[r].transform.GetChild(1).transform.localPosition = new Vector3
                            (0, (reelsList[r].Index -50) * -(ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing), 0);

                        reelsList[r].transform.GetChild(0).transform.localPosition = 
                            reelsList[r].transform.GetChild(1).transform.localPosition +
                            new Vector3(0, ReelPrefab.BlockRect.rect.height, 0);
                    }
                    else if (reelsList[r].Index >= 50 && reelsList[r].Index < 52)
                    {
                        reelsList[r].transform.GetChild(1).transform.localPosition = new Vector3
                            (0, (reelsList[r].Index - 50) * -(ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing), 0);

                        reelsList[r].transform.GetChild(0).transform.localPosition = new Vector3
                            (reelsList[r].transform.GetChild(0).transform.localPosition.x,
                            -ReelPrefab.BlockRect.rect.height - ((ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing) * (reelsList[r].Index - 50)),
                            reelsList[r].transform.GetChild(0).transform.localPosition.z);
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
                if (reelsList[i].transform.GetChild(0).transform.localPosition.y <= 
                    (-ReelPrefab.BlockRect.rect.height - (ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)))
                {
                    reelsList[i].transform.GetChild(0).transform.localPosition = 
                        reelsList[i].transform.GetChild(1).transform.localPosition
                        + new Vector3(0, reelPrefab.BlockRect.rect.height - reelPrefab.Spacing, 0);
                }
                else if (reelsList[i].transform.GetChild(1).transform.localPosition.y <= 
                    (-ReelPrefab.BlockRect.rect.height - (ReelPrefab.BlockRect.rect.width + ReelPrefab.Spacing)))
                {
                    reelsList[i].transform.GetChild(1).transform.localPosition =
                        reelsList[i].transform.GetChild(0).transform.localPosition
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
            }
        }
    }
}
