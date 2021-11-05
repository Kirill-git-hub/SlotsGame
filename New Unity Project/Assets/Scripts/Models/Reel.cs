using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reel
{
    private static bool canSpin = false;
    private static float reelSpeed = 450f;

    private List<ItemModel> itemsList = new List<ItemModel>();
    private List<GameObject> itemsObj = new List<GameObject>();
    private Sprite[] sprites = new Sprite[5];
    private float height = 10490f;
    private float width = 190f;
    private int index;
    private float spacing = 20f;
    private bool canGetRndIndex;

    public bool CanSpin { get => canSpin; set => canSpin = value; }
    public float ReelSpeed => reelSpeed;
    public List<ItemModel> ItemsList { get => itemsList; set => itemsList = value; }
    public float Height => height;
    public float Width => width;
    public int Index { get => index; set => index = value; }
    public float Spacing => spacing;
    public bool CanGetRndIndex { get => canGetRndIndex; set => canGetRndIndex = value; }

    public Reel() { }
    public Reel(Transform parentTransform)
    {
        GameObject reel = MonoBehaviour.Instantiate(Resources.Load<GameObject>("ReelPrefab"), parentTransform);
        LoadSprites();
        GetItems(reel);
        SetItems();

        CanSpin = false;
    }

    public void LoadSprites()
    {
        sprites = Resources.LoadAll<Sprite>("Icon");
    }

    public void SetItems()
    {
        for (int i = 0; i < itemsObj.Count; i++)
        {
            for (int j = 0; j < itemsObj[i].transform.childCount; j++)
            {
                Image image = itemsObj[i].transform.GetChild(j).GetComponent<Image>();
                Sprite rndSprite = sprites[Random.Range(0, sprites.Length)];
                ItemModel itemModel = new ItemModel(image, rndSprite, rndSprite.name);
                ItemsList.Add(itemModel);
            }
        }
    }

    public void GetItems(GameObject reel)
    {
        for (int i = 0; i < reel.transform.childCount; i++)
        {
            for (int j = 0; j < reel.transform.GetChild(i).childCount; j++)
            {
                itemsObj.Add(reel.transform.GetChild(i).GetChild(j).gameObject);
            }
        }
    }

    public int GetRandomIndexToStop()
    {
        int rndItem = Random.Range(0, ItemsList.Count - 2);
        return rndItem;
    }
}
