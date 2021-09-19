using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemEnvironment : MonoBehaviour
{
    public float itemName;
    public float itemPrice;
    public bool isItemBought = false;

    public void OnMouseDown()
    {
        if (isItemBought)
        {
            Debug.Log("Already bought item: " + itemName);
            // change active tool to item
        } else 
        {
            Debug.Log("Buying item: " + itemName);
            BuyItem();
        }
    }

    public void BuyItem()
    {
        bool doesPlayerHaveEnoughMoney = GameManager.Instance.currentMoney >= itemPrice;
        if (!doesPlayerHaveEnoughMoney)
        {
            Debug.Log("Not enough money to buy item: " + itemName + " " + GameManager.Instance.currentMoney);
            return;
        }

        isItemBought = true;
        GameManager.Instance.currentLevel++;
        GameManager.Instance.currentMoney -= itemPrice;
        // TODO: implement item effects - see pet items
    }
}
