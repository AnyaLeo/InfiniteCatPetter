using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public float currentCatHappiness;
    public float currentMoney;

    public float catHairGainBonus = 0f;
    public float awayDecreaseRate = -1f;

    public int currentLevel = 0;
    public int maxLevels = 5;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public void IncrementCurrentLevel()
    {
        currentLevel++;
        Events.Instance.LevelIncreased();
        
        if (currentLevel >= maxLevels)
        {
            // trigger the apocalypse
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            changeCursor(cursorTexture);
        }
    }

    public void changeCursor(Texture2D texture)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
