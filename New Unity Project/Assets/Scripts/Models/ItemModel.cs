using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemModel : MonoBehaviour
{
    [SerializeField] private Image itemImage = null;
    [SerializeField] private ItemType slotType;
    [SerializeField] private float payout;

    public void Init(Sprite sprite)
    {
        itemImage.sprite = sprite;
    }
}
