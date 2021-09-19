using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    private string itemName;
    [SerializeField]
    private int itemPrice;
    [SerializeField]
    private float happinessEffect;
    [SerializeField]
    private float hairGainEffect;
    [SerializeField]
    private float timeTaken;
    [SerializeField]
    private bool isItemBought = false;
    [SerializeField]
    private Color boughtColor;

    public Texture2D cursorTexture;

    private void Start()
    {
        if (isItemBought)
        {
            changeActiveTool();
        }
    }

    public void OnMouseDown()
    {
        if (isItemBought)
        {
            //Debug.Log("Already bought item: " + itemName);
            changeActiveTool();
        }
        else
        {
            //Debug.Log("Buying item: " + itemName);
            BuyItem();
            changeActiveTool();
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
        greyOutBought();
        float happinessDecrease = GameManager.Instance.awayDecreaseRate * timeTaken;

        GameManager.Instance.currentMoney -= itemPrice;
        GameManager.Instance.catHairGainBonus = hairGainEffect;
        Events.Instance.CatHappinessChanged(happinessDecrease);
        Events.Instance.CatHappinessChanged(happinessEffect);

        CatHappiness.Instance.maxHappinessPerLevel += 25f;
    }

    private void greyOutBought()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = boughtColor;
    }

    private void changeActiveTool()
    {
        GameManager.Instance.catHairGainBonus = hairGainEffect;
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
}
