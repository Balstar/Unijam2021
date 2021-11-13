using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardManager : MonoBehaviour
{
    private static CardManager _instance;
    public static CardManager Instance { get; private set; }

    CardManager(){}

    [SerializeField] private Card[] uniqueCards;

    private GameObject[] cardsPlayer1 = new GameObject[30];
    private GameObject[] cardsPlayer2 = new GameObject[30];
    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    void Start()
    {
         
    }
    
    void Update()
    {
        
    }
    

    private void CreateCards()
    {
        /*for (var i = 0; i < )
        {
            
        }*/
    }
}