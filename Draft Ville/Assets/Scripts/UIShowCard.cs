using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShowCard : MonoBehaviour
{
    public Card card;
    [SerializeField]
    GameObject fullCard;
    [SerializeField]
    Text nameText;
    [SerializeField]
    Text effect;
    [SerializeField]
    Image artwork;
    [SerializeField]
    Image cardScarcityAndColor;

    public void ChangeCard(Card card)
    {
        nameText.text = card.Name;
        effect.text = card.Effect;
        artwork.sprite = card.Artwork;
        int i = ((int)card.Color) * 3 + ((int)card.CardScarcity) ;
        cardScarcityAndColor.sprite = UIManager.Instance.Sprites[i];
        
    }
    public void ShowCard()
    {
        fullCard.SetActive(true);
    }

    public void HideCard()
    {
        fullCard.SetActive(false);
    }

}
