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
    private List<Sprite> _sprites;
    public Sprite[] Sprites { get; private set; }

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
