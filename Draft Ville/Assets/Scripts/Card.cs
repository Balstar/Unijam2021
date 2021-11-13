using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    [SerializeField]
    private string _id;
    [SerializeField]
    private CardColor _color;
    [SerializeField]
    private string _name;
    [SerializeField]
    private string _effect;
    [SerializeField]
    private Sprite _artwork;
    [SerializeField]
    private CardScarcity _cardScarcity;
    [SerializeField]
    private bool _isCitizen;
    
    public string Id { get => _id; private set { _id = value; } }
    public CardColor Color { get => _color; private set { _color = value; ; } }
    //public int NumberOfCards { get; }
    public string Name { get => _name; private set { _name = value; } }
    public bool isCitizen { get => _isCitizen; private set { _isCitizen = value; ; } }
    public string Effect { get => _effect; private set { _effect = value; } }
    public Sprite Artwork { get => _artwork; private set { _artwork = value; } }
    public CardScarcity CardScarcity { get => _cardScarcity; private set { _cardScarcity = value; } }
    public Card(string id, CardColor color, string name, string effect, CardScarcity cardScarcity) //, int numberOfCards
    {
        this.Id = id ;
        this.Color = color;
        //_numberOfCards = numberOfCards;
        this.Name = name;
        this.Effect = effect;
        this.CardScarcity = cardScarcity;
    }
    
    public override string ToString()
    {
        string colorString = Color == CardColor.MILITARY ? "Military" : Color == CardColor.CULTURAL ? "Religious" : "Agricole";
        return "Name : " + Name + "\nEffect : " + Effect + "\nId : " + Id + "\nColor : " + colorString; 
    }
    
    public int Points()
    {
        return 0;
    }
}
