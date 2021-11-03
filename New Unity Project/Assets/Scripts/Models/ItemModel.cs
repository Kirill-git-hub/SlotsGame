using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemModel 
{
    private Image itemImage = null;
    private ItemType itemType;
    private float payout;
    private int itemID;

    public ItemType ItemType { get => itemType; set => itemType = value; }
    public float Payout { get => payout; set => payout = value; }
    public int ItemID { get => itemID; set => itemID = value; }

    public ItemModel(Image itemImage, Sprite sprite, string type)
    {
        itemImage.sprite = sprite;

        switch (type)
        {
            case "BurgerIcon":
                ItemType = ItemType.Burger;
                ItemID = (int)ItemType.Burger;
                Payout = 0.4f;
                break;
            case "CherryIcon":
                ItemType = ItemType.Cherry;
                ItemID = (int)ItemType.Cherry;
                Payout = 0.8f;
                break;
            case "CoinsIcon":
                ItemType = ItemType.Coins;
                ItemID = (int)ItemType.Coins;
                Payout = 1.2f;
                break;
            case "DiamondIcon":
                ItemType = ItemType.Diamond;
                ItemID = (int)ItemType.Diamond;
                Payout = 1.6f;
                break;
            case "GrapesIcon":
                ItemType = ItemType.Grapes;
                ItemID = (int)ItemType.Grapes;
                Payout = 2f;
                break;
            case "PoopIcon":
                ItemType = ItemType.Poop;
                ItemID = (int)ItemType.Poop;
                Payout = 2.4f;
                break;
        }
    }

    // public void Init(Sprite sprite, string type)
    // {
    //     itemImage.sprite = sprite;

    //     switch (type)
    //     {
    //         case "BurgerIcon":
    //             ItemType = ItemType.Burger;
    //             ItemID = (int)ItemType.Burger;
    //             Payout = 0.4f;
    //             break;
    //         case "CherryIcon":
    //             ItemType = ItemType.Cherry;
    //             ItemID = (int)ItemType.Cherry;
    //             Payout = 0.8f;
    //             break;
    //         case "CoinsIcon":
    //             ItemType = ItemType.Coins;
    //             ItemID = (int)ItemType.Coins;
    //             Payout = 1.2f;
    //             break;
    //         case "DiamondIcon":
    //             ItemType = ItemType.Diamond;
    //             ItemID = (int)ItemType.Diamond;
    //             Payout = 1.6f;
    //             break;
    //         case "GrapesIcon":
    //             ItemType = ItemType.Grapes;
    //             ItemID = (int)ItemType.Grapes;
    //             Payout = 2f;
    //             break;
    //         case "PoopIcon":
    //             ItemType = ItemType.Poop;
    //             ItemID = (int)ItemType.Poop;
    //             Payout = 2.4f;
    //             break;
    //     }
    // }
}
