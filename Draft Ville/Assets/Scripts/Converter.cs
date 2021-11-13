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
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < slots.Length; i++)
        {
            Dictionnary.Add(slots[0], cards[0]);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
