using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardManager : MonoBehaviour
{
    private static CardManager _instance;
    public static CardManager Instance { get; private set; }

    [SerializeField]
    Sprite cultural;
    [SerializeField]
    Sprite religious;
    [SerializeField]
    Sprite military;
    CardManager(){}

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
