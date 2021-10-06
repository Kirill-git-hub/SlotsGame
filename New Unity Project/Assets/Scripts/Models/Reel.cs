using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{

    [SerializeField] private List<ItemModel> itemsList = new List<ItemModel>();
    [SerializeField] private List<Sprite> spritesList = new List<Sprite>();
    [SerializeField] private float delay;
    [SerializeField] private float speed;

    private Vector2 startPos;

    public Vector2 StartPos { get => startPos; set => startPos = value; }
    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        //startPos = transform.position;
        SetItems();
    }

    private void Update()
    {
        //RotateReel();
    }

    public void RotateReel(float reelSpeed)
    {
        transform.Translate(Vector2.down * Time.deltaTime * reelSpeed);
    }

    public void SetItems()
    {
        foreach (ItemModel item in itemsList)
        {
            item.Init(spritesList[Random.Range(0, spritesList.Count)]);
        }
    }
}
