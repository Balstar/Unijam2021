using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardManager : MonoBehaviour
{
    private static CardManager _instance;
    public static CardManager Instance { get; private set; }
    CardManager(){}

    string json;

    [SerializeField]
    private TextAsset jsonFile;

    // Start is called before the first frame update
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
        CreateCards();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void CreateCards()
    {
        ;
    }
}
