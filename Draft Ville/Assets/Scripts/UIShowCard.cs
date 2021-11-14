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

    public void ChangeCard(Card newCard)
    {
        card = newCard;

        nameText.text = newCard.Name;
        effect.text = newCard.Effect;
        artwork.sprite = newCard.Artwork;
        int i = ((int)newCard.Color) * 3 + ((int)newCard.CardScarcity) ;
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
