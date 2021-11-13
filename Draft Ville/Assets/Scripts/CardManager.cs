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
    private Queue<string> deck = new Queue<string>();

    public List<string> cardsPlayer1 = new List<string>();
    public List<string> cardsPlayer2 = new List<string>();

    private int _scorePlayer1 = 0;
    private int _scorePlayer2 = 0;
    public int ScorePlayer1 { get => _scorePlayer1; private set { _scorePlayer1 = value; } }
    public int ScorePlayer2 { get => _scorePlayer2; private set { _scorePlayer2 = value; } }



    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        //MakeRandomDecks();

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

            deck.Enqueue(protoDeck[indexVal]);
            protoDeck.Remove(protoDeck[indexVal]);
        }
    }

    public void DistributeCards()
    {
        for (var i = 0; i < 5; i++)
        {
            cardDisplays[i].ChangeCard(Converter.Convert(deck.Dequeue()));
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
                    ScoreColorType(secondPlayer,0,true,1);
                    break;

                case "MC04":
                    ScoreDirect(secondPlayer, 12);
                    ScoreColor(secondPlayer, 2, -1);
                    break;

                case "MU01":
                    ScoreColor(secondPlayer, 0, 1);
                    break;

                case "MU02":
                    ScoreDirect(secondPlayer, 4);
                    ScoreColorType(secondPlayer, 0, true, 2);
                    break;

                case "MU03":
                    ScoreType(secondPlayer, false, 1);
                    break;

                case "MR01":
                    ScoreDirect(secondPlayer, 10);
                    ScoreUniqueColor(secondPlayer, 0, 4);
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
                    ScoreColor(secondPlayer, 0, -1);
                    break;

                case "AU01":
                    ScoreColor(secondPlayer, 1, 1);
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
                    ScoreColor(secondPlayer, 1, -1);
                    break;

                case "CU01":
                    ScoreColor(secondPlayer, 2, 1);
                    break;

                case "CU02":
                    ScoreUniqueType(secondPlayer, true, 2);
                    break;

                case "CU03":
                    ScoreColorType(secondPlayer, 2, false, 2);
                    break;

                case "CR01":
                    ScoreUniqueColorType(secondPlayer, 2, false, 6);
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

    private void ScoreColor(bool secondPlayer, int color, int value)
    {
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
        }

        foreach (string id in deck)
        {
            var card = Converter.Convert(id);

            if ((int)card.Color == color)
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreType(bool secondPlayer, bool isCitizen, int value)
    {
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
        }

        foreach (string id in deck)
        {
            var card = Converter.Convert(id);

            if (card.isCitizen == isCitizen)
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreColorType(bool secondPlayer, int color, bool isCitizen, int amount)
    {
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
        }

        var deckColor = new List<Card>();

        foreach (string id in deck)
        {
            var card = Converter.Convert(id);

            if ((int)card.Color == color)
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

    private void ScoreUniqueColorType(bool secondPlayer, int color, bool isCitizen, int value)
    {
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
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

            if (((int)card.Color == color) && (card.isCitizen == isCitizen))
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreUniqueColor(bool secondPlayer, int color, int value)
    {
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
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

            if ((int)card.Color == color)
            {
                ScoreDirect(secondPlayer, value);
            }
        }
    }

    private void ScoreUniqueType(bool secondPlayer, bool isCitizen, int value)
    {
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
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
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
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
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
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
        var count1 = 0;
        var count2 = 0;
        var count3 = 0;
        
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
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
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
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
        if (secondPlayer)
        {
            var deck = cardsPlayer2;
        }
        else
        {
            var deck = cardsPlayer1;
        }

        var red = 0;
        var green = 0;
        var blue = 0;
        

        foreach (string id in deck)
        {
            var crd = Converter.Convert(id);

            switch ((int)crd.Color)
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

        ScoreDirect(secondPlayer, value * Mathf.Min(red, green, blue));
    }
}