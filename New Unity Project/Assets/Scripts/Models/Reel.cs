using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{

    [SerializeField] private List<ItemModel> itemsList = new List<ItemModel>();
    [SerializeField] private List<Sprite> spritesList = new List<Sprite>();
    [SerializeField] private float delay;
    [SerializeField] private float speed;
    [SerializeField] private RectTransform rectTransform;

    private bool isFinal = false;
    private Vector3 startingPos = new Vector3(0, 1450, 0);
    private Vector3 finalPos = new Vector3(0, 0, 0);
    private Vector3 endingPos = new Vector3(0, -1450, 0);

    public Vector3 StartingPos => startingPos;
    public Vector3 FinalPos => finalPos;
    public Vector3 EndingPos => endingPos;
    public float Speed { get => speed; set => speed = value; }

    private void Start()
    {
        SetItems();
    }

    public void SetPosition(Vector3 pos)
    {
        transform.localPosition = pos;
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
