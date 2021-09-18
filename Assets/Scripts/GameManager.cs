using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float currentCatHappiness;
    public float currentCatHair;
    public float currentMoney;

    public int currentLevel;
    public int maxLevels = 5;

    public void IncrementCurrentLevel()
    {
        currentLevel++;
        
        if (currentLevel >= maxLevels)
        {
            // trigger the apocalypse
        }
    }
}
