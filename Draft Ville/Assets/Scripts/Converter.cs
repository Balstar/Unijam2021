using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    [SerializeField]
    private string[] slots;
    [SerializeField]
    private Card[] cards;
    private Dictionary<string, Card> _dictionnary;
    
    public Dictionary<string, Card> Dictionnary { get; private set; }
    private static Converter _instance;
    public static Converter Instance { get; private set; }
    
    Converter() { }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
        Dictionnary = new Dictionary<string, Card>();
    }
    
    void Start()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            Dictionnary.Add(slots[i], cards[i]);
        }
        
    }

    public static Card Convert(string id)
    {
        return Instance.Dictionnary[id];
    }
    
    void Update()
    {
        
    }
}
