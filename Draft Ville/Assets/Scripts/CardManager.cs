using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardManager : MonoBehaviour
{
    private static CardManager _instance;
    public static CardManager Instance { get => _instance; private set { _instance = value; } }
    CardManager(){}

    private string[] uniqueCards = new string[] {
        "MC01","MC02","MC03","MC04","MU01","MU02","MU03","MR01","MR02",
        "AC01","AC02","AC03","AC04","AU01","AU02","AU03","AR01","AR02",
        "CC01","CC02","CC03","CC04","CU01","CU02","CU03","CR01","CR02"
    };

    [SerializeField] private UIShowCard[] cardDisplays;

    private List<string> protoDeck = new List<string>();
    private Queue<string> deck = new Queue<string>();

    private string[] cardsPlayer1 = new string[30];
    private string[] cardsPlayer2 = new string[30];



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

        //Debug.Log(protoDeck.Count.ToString());

        while (protoDeck.Count != 0)
        {
            var r = new System.Random();

            int indexVal = r.Next(protoDeck.Count);

            deck.Enqueue(protoDeck[indexVal]);
            protoDeck.Remove(protoDeck[indexVal]);
        }
    }

    private void DistributeCards()
    {
        for (var i = 0; i < 5; i++)
        {
            cardDisplays[i].ChangeCard(Converter.Convert(deck.Dequeue()));
        }

    }
}