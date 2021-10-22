using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemModel : MonoBehaviour
{
    [SerializeField] private Image itemImage = null;
    [SerializeField] private ItemType itemType;
    [SerializeField] private float payout;
    [SerializeField] private int itemID;

    public int ItemID { get => itemID; set => itemID = value; }
    public ItemType ItemType { get => itemType; set => itemType = value; }

    public void Init(Sprite sprite, string type)
    {
        itemImage.sprite = sprite;

        switch (type)
        {
            case "BeardManIcon":
                ItemType = ItemType.BeardMan;
                ItemID = (int)ItemType.BeardMan;
                payout = 0.4f;
                break;
            case "BellIcon":
                ItemType = ItemType.Bell;
                ItemID = (int)ItemType.Bell;
                payout = 0.8f;
                break;
            case "BurgerIcon":
                ItemType = ItemType.Burger;
                ItemID = (int)ItemType.Burger;
                payout = 1.2f;
                break;
            case "CherryIcon":
                ItemType = ItemType.Cherry;
                ItemID = (int)ItemType.Cherry;
                payout = 1.6f;
                break;
            case "CoinsIcon":
                ItemType = ItemType.Coins;
                ItemID = (int)ItemType.Coins;
                payout = 2f;
                break;
            case "DiamondIcon":
                ItemType = ItemType.Diamond;
                ItemID = (int)ItemType.Diamond;
                payout = 2.4f;
                break;
            case "DogPoopingIcon":
                ItemType = ItemType.DogPooping;
                ItemID = (int)ItemType.DogPooping;
                payout = 2.8f;
                break;
            case "GrapesIcon":
                ItemType = ItemType.Grapes;
                ItemID = (int)ItemType.Grapes;
                payout = 3.2f;
                break;
            case "PoopIcon":
                ItemType = ItemType.Poop;
                ItemID = (int)ItemType.Poop;
                payout = 3.6f;
                break;
            case "StrawberryIcon":
                ItemType = ItemType.Strawberry;
                ItemID = (int)ItemType.Strawberry;
                payout = 4f;
                break;
        }
    }
}
