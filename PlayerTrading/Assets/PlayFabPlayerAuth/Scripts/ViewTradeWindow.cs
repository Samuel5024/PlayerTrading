using UnityEngine;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using TMPro;

public class ViewTradeWindow : MonoBehaviour
{
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI offeredItemsText;
    public TextMeshProUGUI requestItemsText;

    private TradeOfferInfo curTradeOffer;

    // instance
    public static ViewTradeWindow instance;
    void Awake()
    {
        instance = this;
    }

}
