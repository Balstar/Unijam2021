using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardManager : MonoBehaviour
{
    private static CardManager _instance;
    public static CardManager Instance { get => _instance; private set { _instance = value; } }
    CardManager() { }

    private string[] uniqueCards = new string[] {
        "MC01","MC02","MC03","MC04","MU01","MU02","MU03","MR01","MR02",
        "AC01","AC02","AC03","AC04","AU01","AU02","AU03","AR01","AR02",
        "CC01","CC02","CC03","CC04","CU01","CU02","CU03","CR01","CR02"
    };

    [SerializeField] public UIShowCard[] cardDisplays;

    private List<string> protoDeck = new List<string>();
    private Queue<string> randomisedDeck = new Queue<string>();

    private List<string> cardsPlayer1 = new List<string>();
    private List<string> cardsPlayer2 = new List<string>();

    public int playerOneCards { get; private set; } = 0;
    public int playerOneRed { get; private set; } = 0;
    public int playerOneGreen { get; private set; } = 0;
    public int playerOneBlue { get; private set; } = 0;
    public int playerOneCitizen { get; private set; } = 0;
    public int playerOneBuilding { get; private set; } = 0;

    public int playerTwoCards { get; private set; } = 0;
    public int playerTwoRed { get; private set; } = 0;
    public int playerTwoGreen { get; private set; } = 0;
    public int playerTwoBlue { get; private set; } = 0;
    public int playerTwoCitizen { get; private set; } = 0;
    public int playerTwoBuilding { get; private set; } = 0;

    private int _scorePlayer1 = 0;
    private int _scorePlayer2 = 0;
    public int ScorePlayer1 { get => _scorePlayer1; private set { _scorePlayer1 = value; } }
    public int ScorePlayer2 { get => _scorePlayer2; private set { _scorePlayer2 = value; } }

    public void addCard(bool playerTwo, string cardId)
    {
        var test = Converter.Convert(cardId);

        if (playerTwo)
        {
            cardsPlayer2.Add(cardId);

            playerTwoCards++;

            if (test.isCitizen)
            {
                playerTwoCitizen++;
            }
            else
            {
                playerTwoBuilding++;
            }

            if (test.Color == CardColor.MILITARY)
            {
                playerTwoRed++;
            }
            else if (test.Color == CardColor.AGRICOLE)
            {
                playerTwoGreen++;
            }
            else
            {
                playerTwoBlue++;
            }
        }
        else
        {
            cardsPlayer1.Add(cardId);

            playerOneCards++;

            if (test.isCitizen)
            {
                playerOneCitizen++;
            }
            else
            {
                playerOneBuilding++;
            }

            if (test.Color == CardColor.MILITARY)
            {
                playerOneRed++;
            }
            else if (test.Color == CardColor.AGRICOLE)
            {
                playerOneGreen++;
            }
            else
            {
                playerOneBlue++;
            }
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        CreateCards();

        DistributeCards();
    }

    private void CreateCards()
    {
        foreach(string id in uniqueCards)
        {
            var multiple = 1;
            
            switch (Converter.Instance.Dictionnary[id].CardScarcity)
            {
                case CardScarcity.COMMON:
                    multiple = 3;
                    break;

                case CardScarcity.UNCOMMON:
                    multiple = 2;
                    break;

                case CardScarcity.RARE:
                    break;
            }

            for(var j = 0; j < multiple; j++)
            {
                protoDeck.Add(id);
            }
        }

        while (protoDeck.Count != 0)
        {
            int indexVal = UnityEngine.Random.Range(0,protoDeck.Count);

            randomisedDeck.Enqueue(protoDeck[indexVal]);
            protoDeck.Remove(protoDeck[indexVal]);
        }
    }

    public void DistributeCards()
    {
        for (var i = 0; i < 5; i++)
        {
            cardDisplays[i].ChangeCard(Converter.Convert(randomisedDeck.Dequeue()));
            cardDisplays[i].ShowCard();
        }
    }

    private void MakeRandomDecks()
    {
        foreach (string id in uniqueCards)
        {
            var multiple = 1;

            switch (Converter.Instance.Dictionnary[id].CardScarcity)
            {
                case CardScarcity.COMMON:
                    multiple = 3;
                    break;

                case CardScarcity.UNCOMMON:
                    multiple = 2;
                    break;

                case CardScarcity.RARE:
                    break;
            }

            for (var j = 0; j < multiple; j++)
            {
                protoDeck.Add(id);
            }
        }

        int yeet = 0;

        while (protoDeck.Count != 0)
        {
            int indexVal = UnityEngine.Random.Range(0, protoDeck.Count);

            if (yeet < 30)
            {
                cardsPlayer1[yeet] = protoDeck[indexVal];
            }
            else
            {
                cardsPlayer2[yeet - 30] = protoDeck[indexVal];
            }

            protoDeck.Remove(protoDeck[indexVal]);

            yeet++;
        }
    }

    public void CalculateScore(bool secondPlayer)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        Debug.Log("Player 1 " + cardsPlayer1.Count);
        Debug.Log("Player 2 " + cardsPlayer2.Count);
        
        foreach (string id in deck)
        {
            
            switch(id)
            {
                case "MC01":
                    ScoreDirect(secondPlayer, 2);
                    break;

                case "MC02":
                    ScoreDirect(secondPlayer, 3);
                    break;

                case "MC03":
                    ScoreColorType(secondPlayer, CardColor.MILITARY, true,1);
                    break;

                case "MC04":
                    ScoreDirect(secondPlayer, 12);
                    ScoreColor(secondPlayer, CardColor.CULTURAL, -1);
                    break;

                case "MU01":
                    ScoreColor(secondPlayer, CardColor.MILITARY, 1);
                    break;

                case "MU02":
                    ScoreDirect(secondPlayer, 4);
                    ScoreColorType(secondPlayer, CardColor.MILITARY, true, 2);
                    break;

                case "MU03":
                    ScoreType(secondPlayer, false, 1);
                    break;

                case "MR01":
                    ScoreDirect(secondPlayer, 10);
                    ScoreUniqueColor(secondPlayer, CardColor.MILITARY, 4);
                    break;

                case "MR02":
                    ScoreDirect(secondPlayer, -20);
                    ScoreType(secondPlayer, false, 3);
                    break;

                case "AC01":
                    ScoreDirect(secondPlayer, 2);
                    break;

                case "AC02":
                    ScoreDirect(secondPlayer, 3);
                    break;

                case "AC03":
                    ScoreDirect(secondPlayer, 2);
                    ScoreLimitType(secondPlayer, true, 10, 3);
                    break;

                case "AC04":
                    ScoreDirect(secondPlayer, 12);
                    ScoreColor(secondPlayer, CardColor.MILITARY, -1);
                    break;

                case "AU01":
                    ScoreColor(secondPlayer, CardColor.AGRICOLE, 1);
                    break;

                case "AU02":
                    ScoreDirect(secondPlayer, 4);
                    ScoreType(secondPlayer, true, 1);
                    break;

                case "AU03":
                    ScoreDirect(secondPlayer, 5);
                    ScoreAmountId(secondPlayer, "AC02", 2);
                    ScoreAmountId(secondPlayer, "AC03", 2);
                    break;

                case "AR01":
                    ScoreDirect(secondPlayer, 5 + MinCountId(secondPlayer,"AC01","AC02","AC04")*20);
                    break;

                case "AR02":
                    ScoreDirect(secondPlayer, -20);
                    ScoreType(secondPlayer, true, 4);
                    break;

                case "CC01":
                    ScoreDirect(secondPlayer, 2);
                    break;

                case "CC02":
                    ScoreDirect(secondPlayer, 3);
                    break;

                case "CC03":
                    ScoreDiversity(secondPlayer, 5);
                    break;

                case "CC04":
                    ScoreDirect(secondPlayer, 12);
                    ScoreColor(secondPlayer, CardColor.AGRICOLE, -1);
                    break;

                case "CU01":
                    ScoreColor(secondPlayer, CardColor.CULTURAL, 1);
                    break;

                case "CU02":
                    ScoreUniqueType(secondPlayer, true, 2);
                    break;

                case "CU03":
                    ScoreColorType(secondPlayer, CardColor.CULTURAL, false, 2);
                    break;

                case "CR01":
                    ScoreUniqueColorType(secondPlayer, CardColor.CULTURAL, false, 6);
                    break;

                case "CR02":
                    ScoreMinColor(secondPlayer, 4);
                    break;

            }
        }
    }

    private void ScoreDirect(bool secondPlayer, int value)
    {
        if (secondPlayer)
        {
            ScorePlayer2 += value;
        }
        else
        {
            ScorePlayer1 += value;
        }
    }

    private void ScoreColor(bool secondPlayer, CardColor color, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        foreach (string id in deck)
        {
            var card = Converter.Convert(id);

            if (card.Color == color)
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreType(bool secondPlayer, bool isCitizen, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }
        Debug.Log("Scoretype");
        foreach (string id in deck)
        {
            Debug.Log(id);
            var card = Converter.Convert(id);

            if (card.isCitizen == isCitizen)
            {
                ScoreDirect(secondPlayer, value);
            }
            Debug.Log("ça marche");
        }
    }

    private void ScoreColorType(bool secondPlayer, CardColor color, bool isCitizen, int amount)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var deckColor = new List<Card>();

        foreach (string id in deck)
        {
            var card = Converter.Convert(id);

            if (card.Color == color)
            {
                deckColor.Add(card);
            }
        }

        var value = 0;

        foreach(Card card in deckColor)
        {
            if (card.isCitizen == isCitizen)
            {
                value += amount;
            }
        }

        ScoreDirect(secondPlayer, value);
    }

    private void ScoreUniqueColorType(bool secondPlayer, CardColor color, bool isCitizen, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var deckUnique = new List<string>();

        foreach (string id in deck)
        {
            if (!deckUnique.Contains(id))
            {
                deckUnique.Add(id);
            }
        }

        foreach (string id in deckUnique)
        {
            var card = Converter.Convert(id);

            if ((card.Color == color) && (card.isCitizen == isCitizen))
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreUniqueColor(bool secondPlayer, CardColor color, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var deckUnique = new List<string>();

        foreach (string id in deck)
        {
            if (!deckUnique.Contains(id))
            {
                deckUnique.Add(id);
            }
        }

        foreach (string id in deckUnique)
        {
            var card = Converter.Convert(id);

            if (card.Color == color)
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreUniqueType(bool secondPlayer, bool isCitizen, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var deckUnique = new List<string>();

        foreach (string id in deck)
        {
            if (!deckUnique.Contains(id))
            {
                deckUnique.Add(id);
            }
        }

        foreach (string id in deckUnique)
        {
            var card = Converter.Convert(id);

            if (card.isCitizen == isCitizen)
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreLimitType(bool secondPlayer, bool isCitizen, int limit, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var typeAmount = 0;

        foreach(string id in deck)
        {
            if (Converter.Convert(id).isCitizen == isCitizen)
            {
                typeAmount++;
            }
        }

        if (typeAmount >= limit)
        {
            ScoreDirect(secondPlayer, value);
        }
    }

    private void ScoreAmountId(bool secondPlayer, string targetId, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var idAmount = 0;

        foreach (string id in deck)
        {
            if (id == targetId)
            {
                idAmount++;
            }
        }

        ScoreDirect(secondPlayer,idAmount * value);
    }

    private int MinCountId(bool secondPlayer, string id1, string id2, string id3)
    {
        List<string> deck;

        var count1 = 0;
        var count2 = 0;
        var count3 = 0;
        
        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        foreach(string id in deck)
        {
            if (id == id1)
            {
                count1++;
            }

            if (id == id2)
            {
                count2++;
            }

            if (id == id3)
            {
                count3++;
            }
        }

        return Mathf.Min(count1,count2,count3);
    }

    private void ScoreDiversity(bool secondPlayer, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var red = 0;
        var green = 0;
        var blue = 0;

        List<Card> citizens = new List<Card>();

        foreach(string id in deck)
        {
            var crd = Converter.Convert(id);

            if (crd.isCitizen == true)
            {
                citizens.Add(crd);
            }
        }

        foreach(Card card in citizens)
        {
            switch((int)card.Color)
            {
                case 0:
                    red++;
                    break;
                case 1:
                    green++;
                    break;
                case 2:
                    blue++;
                    break;
            }
        }

        if(Mathf.Min(red,green,blue) > 0)
        {
            ScoreDirect(secondPlayer, value);
        }
    }

    private void ScoreMinColor(bool secondPlayer, int value)
    {
        List<string> deck;

        if (secondPlayer)
        {
            deck = cardsPlayer2;
        }
        else
        {
            deck = cardsPlayer1;
        }

        var red = 0;
        var green = 0;
        var blue = 0;
        

        foreach (string id in deck)
        {
            var crd = Converter.Convert(id);

            switch (crd.Color)
            {
                case CardColor.MILITARY:
                    red++;
                    break;
                case CardColor.AGRICOLE:
                    green++;
                    break;
                case CardColor.CULTURAL:
                    blue++;
                    break;
            }
        }

        ScoreDirect(secondPlayer, value * Mathf.Min(red, green, blue));
    }

    private void DebugStringList(List<string> test)
    {
        for(var i=0; i < test.Count; i++)
        {
            Debug.Log(test[i]);
        }
    }
}