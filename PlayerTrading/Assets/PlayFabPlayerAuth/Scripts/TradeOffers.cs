using UnityEngine;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public class TradeOfferInfo
{
    public List<string> playerIds;
    public List<string> playerDisplayNames;
    public List<string> tradeIds;
}

public class TradeOffers : MonoBehaviour
{
    public Button[] tradeOfferbuttons;
    public List<TradeInfo> tradeOffers;
    public TradeOfferInfo tradeOfferInfo;
    private int numTradeOffers;
    
    // instance
    public static TradeOffers instance;
    void Awake()
    {
        instance = this;
    }

    public void UpdateTradeOffers()
    {
        DisableAllTradeOfferButtons();
    }

    void DisableAllTradeOfferButtons()
    {

    }

    void GetTradeInfo()
    {

    }

    void UpdateTradeOffersUI()
    {

    }

    public void OnTradeOfferButton(int tradeIndex)
    {

    }
}
