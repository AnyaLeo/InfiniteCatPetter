using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    public Events eventSystem;

    public TextMeshProUGUI moneyText;

    void Awake()
    {
        eventSystem.CatHairSold += OnCatHairSold;
    }

    private void Start()
    {
        moneyText.text = GameManager.Instance.currentMoney.ToString("f0");
    }

    private void OnDisable()
    {
        eventSystem.CatHairSold -= OnCatHairSold;;
    }
    
    public void OnCatHairSold()
    {
        // Current cat hair price is 1 piece of hair to 10 in money
        // Selling all current cat hair takes 8 hours, decreasing at 1 pt/hour
        // May want to add bonus based on current cat happiness
        float catHairSold = CatHairManager.Instance.currentCatHair;
        float moneyEarned = catHairSold * 10f;
        float happinessDecrease = GameManager.Instance.awayDecreaseRate * 8f;

        AddToMoney(moneyEarned);
        eventSystem.CatHappinessChanged?.Invoke(happinessDecrease);
        removeCatHair(catHairSold);

        Debug.Log("Selling cat hair, gained " + moneyEarned);
        Debug.Log("Cat happiness decreased " + happinessDecrease);
    }

    public void AddToMoney(float moneyEarned)
    {
        Debug.Log("help " + moneyEarned + " " + GameManager.Instance.currentMoney);
        GameManager.Instance.currentMoney += moneyEarned;
        Debug.Log("help1 " + GameManager.Instance.currentMoney);
        moneyText.text = GameManager.Instance.currentMoney.ToString("f0");
    }

    private void removeCatHair(float catHairSold)
    {
        CatHairManager.Instance.ChangeCatHair(-catHairSold);
    }

}
