using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    private static InputManager _instance;
    public static InputManager Instance { get => _instance; private set { _instance = value; } }
    InputManager() { }

    public AudioSource cardClick;
    public AudioSource cardShuffle;
    public AudioSource endGame;
    public AudioSource musicLoop;

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
        //Choix de carte
        cardClick.Play();
        CardManager ins = CardManager.Instance;

        ins.addCard(currentPlayerIsSecond,ins.cardDisplays[cardDisplay - 1].card.Id);

        currentPlayerIsSecond = !currentPlayerIsSecond;
        ins.cardDisplays[cardDisplay - 1].HideCard();

        if (currentPlayerIsSecond)
        {
            two++;
        }

        one++;

        if (one == 5)
        {
            one = 0;
            if (two == 30)
            {
                //Fin de partie
                musicLoop.Stop();
                endGame.Play();
                CardManager.Instance.CalculateScore(false);
                CardManager.Instance.CalculateScore(true);

                Debug.Log(CardManager.Instance.ScorePlayer1);
                Debug.Log(CardManager.Instance.ScorePlayer2);

                UIManager.Instance.playerWinner.text = CardManager.Instance.ScorePlayer1 > CardManager.Instance.ScorePlayer2 ? "Player 1 Wins !" : "Player 2";
                UIManager.Instance.score.text = CardManager.Instance.ScorePlayer1.ToString() + " : " + CardManager.Instance.ScorePlayer2.ToString();
                
            }
            else
            {
                //Destribution de nouvelles cartes
                cardShuffle.Play();
                CardManager.Instance.DistributeCards();
            }
        }

        UIManager.Instance.cardsRemaining.text = (60 - two * 2 + (currentPlayerIsSecond ? 1 : 0)).ToString();
        UIManager.Instance.playerTurn.text = currentPlayerIsSecond ? "2" : "1";

        UIManager.Instance.UpdateUI(false, ins.playerOneCards, ins.playerOneRed, ins.playerOneGreen, ins.playerOneBlue, ins.playerOneCitizen, ins.playerOneBuilding);
        UIManager.Instance.UpdateUI(true, ins.playerTwoCards, ins.playerTwoRed, ins.playerTwoGreen, ins.playerTwoBlue, ins.playerTwoCitizen, ins.playerTwoBuilding);

        //UIManager
    }
}
