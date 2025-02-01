using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowCard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private TextMeshProUGUI _data;
    [SerializeField] private TextMeshProUGUI _text;

    public void SetData(CardData cardData)
    {
        _priceText.text = cardData.Price.ToString();
        _data.text = cardData.GetCartData();
        _text.text = cardData.GetCardTextData();
    }
}
