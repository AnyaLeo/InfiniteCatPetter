using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : Singleton<MoneyManager>
{
    public Events eventSystem;
    

    void Awake()
    {
        eventSystem.CatHairSold += OnCatHairSold;
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
        float happinessDecrease = -8f * 1f;

        AddToMoney(moneyEarned);
        eventSystem.CatHappinessChanged?.Invoke(happinessDecrease);
        removeCatHair(catHairSold);

        Debug.Log("Selling cat hair, gained " + moneyEarned);
        Debug.Log("Cat happiness decreased " + happinessDecrease);
    }

    private void AddToMoney(float moneyEarned)
    {
        GameManager.Instance.currentMoney += moneyEarned;
    }

    private void removeCatHair(float catHairSold)
    {
        CatHairManager.Instance.currentCatHair -= catHairSold;
    }

}
