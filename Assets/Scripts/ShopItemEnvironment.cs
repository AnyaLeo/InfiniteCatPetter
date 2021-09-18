using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItemEnvironment : MonoBehaviour
{
    public float itemPrice;
    public bool isItemBought = false;

    public void BuyItem()
    {
        if (isItemBought)
            return;

        bool doesPlayerHaveEnoughMoney = GameManager.Instance.currentMoney >= itemPrice;
        if (!doesPlayerHaveEnoughMoney)
            return;

        isItemBought = true;
        GameManager.Instance.currentLevel++;
        GameManager.Instance.currentMoney -= itemPrice;
    }
}
