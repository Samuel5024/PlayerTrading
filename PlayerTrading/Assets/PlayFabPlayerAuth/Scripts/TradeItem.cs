using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class TradeItem : MonoBehaviour
{
    public string itemName;
    public int value;
    public TextMeshProUGUI displayText; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // UpdateDisplayText gets called whenever the value is changed
    void UpdateDisplayText()
    {
        displayText.text = string.Format("{0} ({1})", itemName, value);
    }

    public void OnAddItemButton()
    {
        value++;
        UpdateDisplayText();
    }

    public void OnRemoveItemButton()
    {
        if(value > 0)
        {
            value--;
        }

        UpdateDisplayText();
    }

    public void ResetValue()
    {
        value = 0;
        UpdateDisplayText();
    }
}
