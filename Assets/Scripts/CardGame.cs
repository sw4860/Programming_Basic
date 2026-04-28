using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardGame : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform cardContainer;
    public TMP_InputField inputField;
    public int pairCount = 8;
    [HideInInspector] public List<Card> cards;
    private Sprite[] sprites;
    private Card firstCard = null;
    private Card secondCard = null;
    private bool isChecking = false;

    void Start()
    {
        sprites = Resources.LoadAll<Sprite>("Sprites");
        StartGame();
    }

    void StartGame()
    {
        List<int> newCardNumbers = GeneratePairNumbers();

        for (int i = 0; i < pairCount*2; i++)
        {
            GameObject GO = Instantiate(cardPrefab, cardContainer);
            cards.Add(GO.GetComponent<Card>());
            cards[i].SetCardNumber(newCardNumbers[i]);
            if (sprites.Length > newCardNumbers[i])
            {
                cards[i].SetSprite(sprites[newCardNumbers[i]]);
            }
            else
            {
                cards[i].SetSprite(null);
            }
            cards[i].isFront = false;
        }
    }

    void CheckCard()
    {
        if (firstCard.number == secondCard.number)
        {
            firstCard.ChangeColor(Color.red);
            secondCard.ChangeColor(Color.red);

            firstCard.isMatched = true;
            secondCard.isMatched = true;

            firstCard = null;
            secondCard = null;
            
            isChecking = false;
        }
        else
        {
            Invoke("HideCard", 1.0f);
        }
    }

    public void OnClickCard(Card card)
    {
        if (isChecking) return;

        if (firstCard == null)
        {
            firstCard = card;
            card.isFront = true;
        }
        else if (secondCard == null)
        {
            secondCard = card;
            card.isFront = true;
        }

        if (firstCard != null && secondCard != null)
        {
            isChecking = true;
            CheckCard();
        }
    }

    void HideCard()
    {
        firstCard.isFront = false;
        secondCard.isFront = false;

        firstCard = null;
        secondCard = null;

        isChecking = false;
    }

    private List<int> GeneratePairNumbers()
    {
        List<int> newCardNumbers = new();

        for (int i = 0; i < pairCount; i++)
        {
            newCardNumbers.Add(i);
            newCardNumbers.Add(i);
        }

        for (int i = 0; i < pairCount * 2; i++)
        {
            int temp = newCardNumbers[i];
            int randomIndex = Random.Range(0, pairCount*2 - 1);
            newCardNumbers[i] = newCardNumbers[randomIndex];
            newCardNumbers[randomIndex] = temp;
        }

        return newCardNumbers;
    }

    public void Restart()
    {
        cards.Clear();
        GameObject[] cardgos = GameObject.FindGameObjectsWithTag("Card");
        
        for (int i = 0; i < cardgos.Length; i++)
        {
            Destroy(cardgos[i]);
        }
        
        if (inputField.text != "" && int.TryParse(inputField.text, out int result))
        {
            if (result < 1)
            {
                pairCount = 5;
                StartGame();
                return;
            }
            pairCount = result;
        }
        else
        {
            pairCount = 5;
        }
        StartGame();
    }
}