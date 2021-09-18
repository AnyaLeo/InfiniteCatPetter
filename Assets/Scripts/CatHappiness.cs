using UnityEngine;

public class CatHappiness : MonoBehaviour
{
    [Tooltip("The maximum cat happiness that can be reached at the final level")]
    public float ultimateMaxHappiness;
    public float maxHappinessPerLevel;
    public float happinessDecreasePerSecond = 0.1f;

    float currentHappiness;
    float currentTime;

    public Events eventSystem;

    void Awake()
    {
        currentHappiness = maxHappinessPerLevel;
        currentTime = 0f;

        eventSystem.CatHappinessChanged += OnCatHappinessChanged;
    }

    private void OnDisable()
    {
        eventSystem.CatHappinessChanged -= OnCatHappinessChanged;
    }

    private void OnCatHappinessChanged(float happinessChange)
    {
        AddToCurrentHappiness(happinessChange);
    }

    private void Update()
    {
        if (currentTime >= 1f)
        {
            AddToCurrentHappiness(happinessDecreasePerSecond);
            currentTime = 0f;
        }

        currentTime += Time.deltaTime;
    }

    private void AddToCurrentHappiness(float happinessChange)
    {
        currentHappiness += happinessChange;

        if (currentHappiness <= 0f)
        {
            currentHappiness = 0f;
        }

        if (currentHappiness >= maxHappinessPerLevel)
        {
            currentHappiness = maxHappinessPerLevel;
        }

        GameManager.Instance.currentCatHappiness = currentHappiness;
    }
}
