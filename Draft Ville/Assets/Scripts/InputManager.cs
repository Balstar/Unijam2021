using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    public static InputManager Instance { get => _instance; private set { _instance = value; } }
    InputManager() { }

    int currentPlayer;
    private int two = 0;
    bool currentPlayerIsSecond = false;
    int one = 0;
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
        two = 0;
        one = 0;
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
        if (currentPlayerIsSecond)
        {
            two++;
        }
        one++;
        Debug.Log(one);
        Debug.Log(two);
        if(one == 5)
        {
            one = 0;
            if (two == 30)
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
