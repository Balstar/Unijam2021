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
    

    
    public string Id { get; private set; }
    public CardColor Color { get; private set; }
    //public int NumberOfCards { get; }
    public string Name { get; private set; }
    public bool isCitizen { get; private set; }
    public string Effect { get; private set; }
    public Sprite Artwork { get; private set; }
    public CardScarcity CardScarcity { get; private set; }
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
        return "Name : " + Name + "\n" + "\nEffect : " + Effect + "\nId : " + Id + "\nColor : " + colorString;
    }
    
    public int Points()
    {
        return 0;
    }
}
