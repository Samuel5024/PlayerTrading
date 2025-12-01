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

    }

    public void GetCatalog()
    {

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
