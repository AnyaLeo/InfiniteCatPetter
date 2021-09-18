using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    private readonly string itemName;
    [SerializeField]
    private readonly int itemPrice;
    [SerializeField]
    private float happinessEffect;
    [SerializeField]
    private float hairGainEffect;
    [SerializeField]
    private float timeTaken;
    [SerializeField]
    private bool isItemBought = false;

    public void BuyItem()
    {
        if (isItemBought)
            return;

        bool doesPlayerHaveEnoughMoney = GameManager.Instance.currentMoney >= itemPrice;
        if (!doesPlayerHaveEnoughMoney)
            return;

        isItemBought = true;
        GameManager.Instance.currentMoney -= itemPrice;
    }
}
