using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reel : MonoBehaviour
{
    [SerializeField] private static bool canSpin = false;
    private static float speed = 400f;

    [SerializeField] private List<ItemModel> itemsList = new List<ItemModel>();
    [SerializeField] private List<Sprite> spritesList = new List<Sprite>();
    [SerializeField] private float delay;
    [SerializeField] private RectTransform reelRect;
    [SerializeField] private bool isFisrt = false;
    [SerializeField] private bool isCurrent = false;
    [SerializeField] private bool isLast = false;

    private bool isFinal = false;
    private Vector3 startingPos = new Vector3(0, 1450, 0);
    private Vector3 finalPos = new Vector3(0, 0, 0);
    private Vector3 endingPos = new Vector3(0, -1450, 0);

    public Vector3 StartingPos => startingPos;
    public Vector3 FinalPos => finalPos;
    public Vector3 EndingPos => endingPos;
    public float Speed { get => speed; set => speed = value; }
    public float Delay => delay;

    public bool IsFirst { get => isFisrt; set => isFisrt = value; }
    public bool IsCurrent { get => isCurrent; set => isCurrent = value; }
    public bool IsLast { get => isLast; set => isLast = value; }
    public RectTransform ReelRect => reelRect;

    public bool CanSpin { get => canSpin; set => canSpin = value; }

    private void Start()
    {
        SetItems();
        CanSpin = false;
    }

    public void SetPosition(Vector3 pos)
    {
        transform.localPosition = pos;
    }

    public void RotateReel(float reelSpeed)
    {
        transform.Translate(Vector2.down * Time.deltaTime * reelSpeed);
    }

    public void SetItems()
    {
        foreach (ItemModel item in itemsList)
        {
            Sprite rndSprite = spritesList[Random.Range(0, spritesList.Count)];
            item.Init(rndSprite);
        }
    }

    public void DestroyReel()
    {
        Destroy(gameObject);
    }
}
