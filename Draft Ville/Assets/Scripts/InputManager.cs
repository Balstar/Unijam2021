using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    public static InputManager Instance { get => _instance; private set { _instance = value; } }
    InputManager() { }

    bool currentPlayerIsSecond = false;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    public void clickCard(int cardDisplay)
    {
        
        CardManager ins = CardManager.Instance;
        if (!currentPlayerIsSecond)
        {
            ins.cardsPlayer1.Add(ins.cardDisplays[cardDisplay - 1].card.Id);
        }
        else
        {
            ins.cardsPlayer2.Add(ins.cardDisplays[cardDisplay - 1].card.Id);
        }
        currentPlayerIsSecond = !currentPlayerIsSecond;
        ins.cardDisplays[cardDisplay - 1].HideCard();

        var cardsTaken = 5;

        foreach(UIShowCard card in ins.cardDisplays)
        {
            if (card.gameObject.activeInHierarchy)
            {
                cardsTaken--;
            }
        }
        


        Debug.Log(cardsTaken);
        Debug.Log(ins.cardsPlayer2.Count);

        if(cardsTaken == 5)
        {
            if (ins.cardsPlayer2.Count == 30)
            {
                CardManager.Instance.CalculateScore(false);
                CardManager.Instance.CalculateScore(true);

                Debug.Log(CardManager.Instance.ScorePlayer1);
                Debug.Log(CardManager.Instance.ScorePlayer2);                
            }
            CardManager.Instance.DistributeCards();
        }
       
        //UIManager
    }
}
