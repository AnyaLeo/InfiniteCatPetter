using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float currentCatHappiness = 0;
    public float currentCatHair = 0;
    public float currentMoney = 0;

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
