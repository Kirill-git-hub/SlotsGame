using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{

    [SerializeField] private List<ItemModel> itemsList = new List<ItemModel>();
    [SerializeField] private List<Sprite> spritesList = new List<Sprite>();
    [SerializeField] private float delay;
    [SerializeField] private float speed;
    [SerializeField] private RectTransform reelRect;

    [SerializeField] private bool isFisrt = false;
    [SerializeField] private bool isCurrent = false;
    [SerializeField] private bool isLast = false;

    private bool isFinal = false;
    private Vector3 startingPos = new Vector3(0, 1450, 0);
    private Vector3 finalPos = new Vector3(0, 0, 0);
    private Vector3 endingPos = new Vector3(0, -1450, 0);
    private bool canSpin;

    public Vector3 StartingPos => startingPos;
    public Vector3 FinalPos => finalPos;
    public Vector3 EndingPos => endingPos;
    public float Speed { get => speed; set => speed = value; }
    public float Delay => delay;

    public bool IsFirst { get => isFisrt; set => isFisrt = value; }
    public bool IsCurrent { get => isCurrent; set => isCurrent = value; }
    public bool IsLast { get => isLast; set => isLast = value; }
    public RectTransform ReelRect => reelRect;

    private void Start()
    {
        SetItems();
        canSpin = false;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    private void Update()
    {
        //RotateReel(100);
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

    public void DestroyReel()
    {
        Destroy(gameObject);
    }
}
