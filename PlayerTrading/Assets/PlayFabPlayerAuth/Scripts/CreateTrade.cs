using UnityEngine;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
public class CreateTrade : MonoBehaviour
{
    public TradeItem[] offeringItems;
    public TradeItem[] requestingItems;

    // instance
    public static CreateTrade instance;
    void Awake()
    {
        instance = this;
    }

    public void OnCreateTradeButton()
    {
        // Create a temporary list to hold a copy of our inventory
        List<ItemInstance> tempInventory = Trade.instance.inventory;
        List<string> itemsToOffer = new List<string>();

        // loop through each offering & add their respecitve item names and values to offer list
        foreach (TradeItem item in offeringItems)
        {
            for (int x = 0; x < item.value; x++)
            {
                ItemInstance i = tempInventory.Find(y => y.DisplayName == item.itemName);

                if(i == null)
                {
                    Debug.Log("You don't have the offered items in your inventory!");
                    return;
                }
                else
                {
                    itemsToOffer.Add(i.ItemInstanceId);
                    tempInventory.Remove(i);
                }
            }
        }

        // check if we're trading nothing
        if(itemsToOffer.Count == 0)
        {
            Debug.Log("You can't trade nothing.");
            return;
        }

        // get the requested items
        List<string> itemsToRequest = new List<string>();
        foreach(TradeItem item in requestingItems)
        {
            string itemId = Trade.instance.catalog.Find(y => y.DisplayName == item.itemName).ItemId;
            for(int x = 0; x < item.value; x++)
            {
                itemsToRequest.Add(itemId);
            }
        }

        // create new open trade request
        OpenTradeRequest tradeRequest = new OpenTradeRequest
        {
            OfferedInventoryInstanceIds = itemsToOffer,
            RequestedCatalogItemIds = itemsToRequest
        };

        // send request off to the API
        PlayFabClientAPI.OpenTrade(tradeRequest,
            result => AddTradeToGroup(result.Trade.TradeId),
            error => Debug.Log(error.ErrorMessage)
        );
    }

    void AddTradeToGroup(string tradeId)
    {

    }
}
