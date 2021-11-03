using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reel 
{
    private static bool canSpin = false;
    private static float reelSpeed = 450f;

    private List<ItemModel> itemsList = new List<ItemModel>();
    private List<GameObject> items = new List<GameObject>();
    private List<Sprite> spritesList = new List<Sprite>();
    private Sprite[] sprites = new Sprite[5];
    private RectTransform blockRect = null;
    private float height = 10490f;
    private float width = 190f;
    private int index;

    private float spacing = 20f;
    private bool canGetRndIndex;

    public float Speed => reelSpeed;
    public RectTransform BlockRect => blockRect;
    public bool CanSpin { get => canSpin; set => canSpin = value; }
    public float Spacing => spacing;
    public int Index { get => index; set => index = value; }
    public bool CanGetRndIndex { get => canGetRndIndex; set => canGetRndIndex = value; }
    public List<ItemModel> ItemsList { get => itemsList; set => itemsList = value; }
    public Sprite[] Sprites { get => sprites; set => sprites = value; }
    public float Height { get => height; set => height = value; }
    public float Width { get => width; set => width = value; }

    public Reel(){}
    public Reel(Transform parentTransform)
    {
        CanSpin = false;
        GameObject reel = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ReelPrefab_1"), parentTransform);
        LoadSprites();
        GetItems(reel);
        SetItems();
        //itemsList.Reverse();
        //Debug.Log("Type - " + itemsList[49].ItemType + ", payout - " + itemsList[49].Payout + ", ID - " + itemsList[49].ItemID);
        //MainApp.instance.GameController.SlotMachine.ReelsObjList.Add(reel);
    }


    private void Start()
    {
        //SetItems();
        CanSpin = false;
    }

    public void LoadSprites()
    {
        Sprites = Resources.LoadAll<Sprite>("Icon");
    }

    public void SetItems()
    {
        // foreach (ItemModel item in ItemsList)
        // {
        //     Sprite rndSprite = spritesList[Random.Range(0, spritesList.Count)];
        //     item.Init(rndSprite, rndSprite.name);
        // }

        // for(int i = 0; i < reel.transform.childCount; i++)
        // {
        //     for(int j = 0; j < reel.transform.GetChild(i).childCount; j++)
        //     {
        //         for(int image = 0; image < reel.transform.GetChild(i).GetChild(j).childCount; image++)
        //         {
        //             reel.transform.GetChild(i).GetChild(j).GetChild(image).gameObject.GetComponent<Image>();
        //         }
        //         //reel.transform.GetChild(i).GetChild(j).G
        //     }
        // }

        for(int i = 0; i < items.Count; i++)
        {
            for(int j = 0; j < items[i].transform.childCount; j++)
            {
                Image image = items[i].transform.GetChild(j).GetComponent<Image>();
                Sprite rndSprite = Sprites[Random.Range(0,Sprites.Length)];
                ItemModel itemModel = new ItemModel(image, rndSprite, rndSprite.name);
                ItemsList.Add(itemModel);
            }
        } 
    }

    public void GetItems(GameObject reel)
    {
        for(int i = 0; i < reel.transform.childCount; i++)
        {
            for(int j = 0; j < reel.transform.GetChild(i).childCount; j++)
            {
                items.Add(reel.transform.GetChild(i).GetChild(j).gameObject);
            }
        } 
    }

    public int GetRandomIndexToStop()
    {
        int rndItem = Random.Range(2, ItemsList.Count);
        return rndItem;
    }
}
