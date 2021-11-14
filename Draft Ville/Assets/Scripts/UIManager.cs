using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get => _instance; private set {_instance = value; } }
    #region CardColor
    [SerializeField]
    private Sprite[] _sprites;
    public Sprite[] Sprites { get => _sprites; private set { _sprites = value; } }

    #endregion
    [SerializeField]
    Text remainingCards;

    public Text playerWinner;
    public Text score;
    public Text cardsRemaining;
    public Text playerTurn;
    UIManager() { }

    [Header("Player 1")]
    [SerializeField] private Text PlayerOneTotalCards;
    [SerializeField] private Text PlayerOneRedCards;
    [SerializeField] private Text PlayerOneGreenCards;
    [SerializeField] private Text PlayerOneBlueCards;
    [SerializeField] private Text PlayerOneCitizenCards;
    [SerializeField] private Text PlayerOneBuildingCards;

    [Header("Player 2")]
    [SerializeField] private Text PlayerTwoTotalCards;
    [SerializeField] private Text PlayerTwoRedCards;
    [SerializeField] private Text PlayerTwoGreenCards;
    [SerializeField] private Text PlayerTwoBlueCards;
    [SerializeField] private Text PlayerTwoCitizenCards;
    [SerializeField] private Text PlayerTwoBuildingCards;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }

    public void UpdateUI(bool playerTwo, int cards, int red, int green, int blue, int citizen, int building)
    {
        if (playerTwo)
        {
            PlayerTwoTotalCards.text = "Joueur 2 : " + cards.ToString() + " cartes";
            PlayerTwoRedCards.text = "Cartes rouges " + red.ToString();
            PlayerTwoGreenCards.text = "Cartes vertes " + green.ToString();
            PlayerTwoBlueCards.text = "Cartes bleues : " + blue.ToString();
            PlayerTwoCitizenCards.text = "Cartes citoyen : " + citizen.ToString();
            PlayerTwoBuildingCards.text = "Cartes bâtiment : " + building.ToString();
        }
        else
        {
            PlayerOneTotalCards.text = "Joueur 1 : " + cards.ToString() + " cartes";
            PlayerOneRedCards.text = "Cartes rouges " + red.ToString();
            PlayerOneGreenCards.text = "Cartes vertes " + green.ToString();
            PlayerOneBlueCards.text = "Cartes bleues : " + blue.ToString();
            PlayerOneCitizenCards.text = "Cartes citoyen : " + citizen.ToString();
            PlayerOneBuildingCards.text = "Cartes bâtiment : " + building.ToString();
        }
    }
}
