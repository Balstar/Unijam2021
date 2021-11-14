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
    [SerializeField]
    Image background;

    public void ChangeCard(Card card)
    {
        nameText.text = card.Name;
        effect.text = card.Effect;
        artwork.sprite = card.Artwork;
        int i = ((int)card.Color);
        cardScarcityAndColor.sprite = UIManager.Instance.Sprites[i];
        background.sprite = UIManager.Instance.Backgrounds[i];
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
