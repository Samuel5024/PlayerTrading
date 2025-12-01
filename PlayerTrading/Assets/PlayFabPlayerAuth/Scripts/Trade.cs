using UnityEngine;
using System.Collections.Generic;
using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine.Events;

public class Trade : MonoBehaviour
{
    public GameObject tradeCanvas;
    public TextMeshProUGUI inventoryText;

    [HideInInspector]
    public List<ItemInstance> inventory;
    
    [HideInInspector]
    public List<CatalogItem> catalog;

    // OnRefreshUI will be called when we want to update the updated info
    public UnityEvent onRefreshUI;

    
    // Create an instance of the script to use throuhgout project
    public static Trade instance;
    void Awake() { instance = this; }

    public void OnLoggedIn() 
    {
        tradeCanvas.SetActive(true);

        if(onRefreshUI != null)
        {
            onRefreshUI.Invoke();
        }
    } 

    //GetInventory & GetCatalog are called when we want to refresh UI
    public void GetInventory()
    {
        inventoryText.text ="";

        // request to get the player's inventory
        GetPlayerCombinedInfoRequest getInvRequest = new GetPlayerCombinedInfoRequest
        {
            PlayFabId = LoginRegister.instance.playFabId,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
            {
                GetUserInventory = true
            }
        };

        // send off request to API
        PlayFabClientAPI.GetPlayerCombinedInfo(getInvRequest,
            result =>
            {
                inventory = result.InfoResultPayload.UserInventory;

                foreach(ItemInstance item in inventory)
                {
                    inventoryText.text += item.DisplayName + ", ";
                }
            },
            error => Debug.Log(error.ErrorMessage)
        );
    }

    public void GetCatalog()
    {
        GetCatalogItemsRequest getCatalogRequest = new GetCatalogItemsRequest
        {
            CatalogVersion = "PlayerItems"
        };

        // send off request to API
        PlayFabClientAPI.GetCatalogItems(getCatalogRequest,
            result => catalog = result.Catalog,
            error => Debug.Log(error.ErrorMessage)
        );

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
