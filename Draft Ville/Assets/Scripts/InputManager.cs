using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    public static InputManager Instance { get => _instance; private set { _instance = value; } }
    InputManager() { }

    int currentPlayer;
    int turn = 0;
    bool currentPlayerIsSecond = false;
    int cardsTaken = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    private void Start()
    {
        
    }
    public void clickCard(int cardDisplay)
    {
        CardManager ins = CardManager.Instance;
        ins.cardsPlayer1[turn] = ins.cardDisplays[cardDisplay-1].card.Id;
        currentPlayerIsSecond = !currentPlayerIsSecond;
        ins.cardDisplays[cardDisplay - 1].HideCard();
        if (currentPlayerIsSecond)
        {
            turn++;
        }
        cardsTaken++;
        if(cardsTaken == 5)
        {
            cardsTaken = 0;
            CardManager.Instance.DistributeCards();
            if(turn == 29)
            {
                //CountPoints();
            }
        }
       
        //UIManager
    }
}
