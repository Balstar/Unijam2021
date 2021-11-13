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
    [SerializeField]
    Image background;
    [SerializeField]
    Image cardScarcity;

    private void ChangeCard(Card card)
    {
        nameText.text = card.Name;
        effect.text = card.Effect;
        artwork.sprite = card.Artwork;
        switch (card.Color)
        {
            case CardColor.MILITARY:
                background.sprite = UIManager.Instance.Military;
                break;
            case CardColor.CULTURAL:
                background.sprite = UIManager.Instance.Cultural;
                break;
            case CardColor.AGRICOLE:
                background.sprite = UIManager.Instance.Agricole;
                break;
        }
        switch (card.CardScarcity)
        {
            case CardScarcity.COMMON:
                background.sprite = UIManager.Instance.Common;
                break;
            case CardScarcity.UNCOMMON:
                background.sprite = UIManager.Instance.Uncommon;
                break;
            case CardScarcity.RARE:
                background.sprite = UIManager.Instance.Rare;
                break;
        }

        //background = card.color == CardColor.MILITARY ? 

    }

}
