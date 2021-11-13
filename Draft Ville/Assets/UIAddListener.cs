using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAddListener : MonoBehaviour
{
    [SerializeField]
    Button button;
    [SerializeField]
    int number;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(click);
    }

    // Update is called once per frame
    void click()
    {
        InputManager.Instance.clickCard(number);
    }
}
