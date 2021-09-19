using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopItemEnvironment : MonoBehaviour
{
    public string itemName;
    public float itemPrice;
    [SerializeField]
    int upgradeId;
    public bool isItemBought = false;
    [SerializeField]
    private Color boughtColor;

    [SerializeField]
    private string soldText;
    [SerializeField]
    private GameObject priceTextUI;

    private void Awake()
    {
        priceTextUI.GetComponentInParent<TextMeshProUGUI>().text = "$" + (int)itemPrice;
    }

    public void OnMouseDown()
    {
        if (isItemBought)
        {
            Debug.Log("Already bought item: " + itemName);
            // change active tool to item
        }
        else if (upgradeId >= GameManager.Instance.currentLevel + 1)
        {
            Debug.Log("Can't buy this item yet: " + itemName);
        }
        else
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
        priceTextUI.GetComponentInParent<TextMeshProUGUI>().text = "SOLD!";
        greyOutBought();
        GameManager.Instance.IncrementCurrentLevel();
        GameManager.Instance.currentMoney -= itemPrice;
    }


    private void greyOutBought()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = boughtColor;
    }
}