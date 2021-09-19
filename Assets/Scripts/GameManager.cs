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

    public GameObject doomsday;

    private void Start()
    {
        doomsday.SetActive(false);
    }

    public void IncrementCurrentLevel()
    {
        currentLevel++;
        Debug.Log("increasing level to: " + currentLevel);
        Events.Instance.LevelIncreased();
        
        if (currentLevel >= maxLevels)
        {
            doomsday.SetActive(true);
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            changeCursor(cursorTexture);
        }

        if (currentLevel >= maxLevels)
        {
            doomsday.SetActive(true);
        }
    }

    public void changeCursor(Texture2D texture)
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }
}
