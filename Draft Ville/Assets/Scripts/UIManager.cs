using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get; private set; }
    #region CardColor
    [SerializeField]
    private Sprite _cultural;
    [SerializeField]
    private Sprite _agricole;
    [SerializeField]
    private Sprite _military;
    public Sprite Cultural { get; private set; }
    public Sprite Agricole { get; private set; }
    public Sprite Military { get; private set; }
    #endregion
    #region CardScarcity
    [SerializeField]
    private Sprite _common;
    [SerializeField]
    private Sprite _uncommon;
    [SerializeField]
    private Sprite _rare;
    public Sprite Common { get; private set; }
    public Sprite Uncommon { get; private set; }
    public Sprite Rare { get; private set; }
    #endregion
    [SerializeField]
    Text remainingCards;
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
