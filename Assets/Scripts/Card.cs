using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private float rotSpeed = 0.05f;
    public GameObject frontImage;
    public GameObject backImage;
    private CardGame manager;
    private TextMeshProUGUI text;
    public bool isFront = false;
    public bool isMatched = false;
    [HideInInspector] public int number;

    private void Start()
    {
        manager = FindAnyObjectByType<CardGame>();
    }

    private void Update()
    {
        if (isFront)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180, 0), Time.deltaTime * rotSpeed);
        }

        float yRotation = transform.eulerAngles.y;

        if (yRotation > 90f && yRotation < 270f)
        {
            frontImage.SetActive(false);
            backImage.SetActive(true);
        }
        else
        {
            frontImage.SetActive(true);
            backImage.SetActive(false);
        }
    }
    
    public void ClickCard()
    {
        if (isMatched || isFront) return;
        manager.OnClickCard(this);
    }

    public void SetCardNumber(int num)
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = num.ToString();
        number = num;
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<Image>().color = newColor;
    }
    
    public void SetSprite(Sprite sprite)
    {
        frontImage.GetComponent<Image>().sprite = sprite;
    }
}
