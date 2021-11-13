using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    //[SerializeField]
    //private int _id;
    //[SerializeField]
    //private int _color;
    ////private int _numberOfCards;
    //[SerializeField]
    //private string _name;
    //[SerializeField]
    //private string _effect;
    //[SerializeField]
    //private Sprite _artwork;

    
    public int id;
    public int color;
    //public int NumberOfCards { get; }
    public new string name;
    public string effect;
    public Sprite artwork;
    public Card(int id, int color, string name, string effect) //, int numberOfCards
    {
        this.id = id ;
        this.color = color;
        //_numberOfCards = numberOfCards;
        this.name = name;
        this.effect = effect;
    }
    
    public override string ToString()
    {
        string colorString = color == 0 ? "Military" : color == 1 ? "Religious" : "Agricole";
        return "Name : " + name + "\n" + "\nEffect : " + effect + "\nId : " + id + "\nColor : " + color;
    }
    
    
    
}
