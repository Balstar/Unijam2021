using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowCard : MonoBehaviour
{
    [SerializeField]
    Card card;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Text effect;
    [SerializeField]
    Image artwork;
    int color;

    private void Start()
    {
        nameText.text = card.name;
        effect.text = card.effect;
        artwork.sprite = card.artwork;
        color = card.color;
        
    }

}
