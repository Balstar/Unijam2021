using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;
    public static UIManager Instance { get; private set; }

    [SerializeField]
    private Sprite _cultural;
    [SerializeField]
    private Sprite _agricole;
    [SerializeField]
    private Sprite _military;

    [SerializeField]
    private Sprite _common;
    [SerializeField]
    private Sprite _uncommon;
    [SerializeField]
    private Sprite _rare;

    public Sprite Cultural { get; private set; }
    public Sprite Agricole { get; private set; }
    public Sprite Military { get; private set; }

    public Sprite Common { get; private set; }
    public Sprite Uncommon { get; private set; }
    public Sprite Rare { get; private set; }
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
