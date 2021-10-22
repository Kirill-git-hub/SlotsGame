using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    private static bool canSpin = false;
    private static float reelSpeed = 450f;

    [SerializeField] private List<ItemModel> itemsList = new List<ItemModel>();
    [SerializeField] private List<Sprite> spritesList = new List<Sprite>();
    [SerializeField] private RectTransform bockRect = null;
    [SerializeField] private int index;

    private float spacing = 20f;
    private bool canGetRndIndex;

    public float Speed => reelSpeed;
    public RectTransform BlockRect => bockRect;
    public bool CanSpin { get => canSpin; set => canSpin = value; }
    public float Spacing => spacing;
    public int Index { get => index; set => index = value; }
    public bool CanGetRndIndex { get => canGetRndIndex; set => canGetRndIndex = value; }
    public List<ItemModel> ItemsList { get => itemsList; set => itemsList = value; }

    private void Start()
    {
        SetItems();
        CanSpin = false;
    }

    public void SetItems()
    {
        foreach (ItemModel item in ItemsList)
        {
            Sprite rndSprite = spritesList[Random.Range(0, spritesList.Count)];
            item.Init(rndSprite, rndSprite.name);
        }
    }

    public int GetRandomIndexToStop()
    {
        int rndItem = Random.Range(2, ItemsList.Count);
        return rndItem;
    }
}
