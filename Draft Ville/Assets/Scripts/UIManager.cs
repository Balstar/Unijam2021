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

    [SerializeField]
    private Sprite[] _backgrounds;
    public Sprite[] Backgrounds { get => _backgrounds; private set { _backgrounds = value; } }

    #endregion
    [SerializeField]
    Text remainingCards;

    public Text playerWinner;
    public Text score;
    public Text cardsRemaining;
    public Text playerTurn;
    UIManager() { }

    // Start is called before the first frame update
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        Instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
