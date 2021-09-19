using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatHappiness : Singleton<CatHappiness>
{
    [Tooltip("The maximum cat happiness that can be reached at the final level")]
    public float ultimateMaxHappiness = 100f;
    public float maxHappinessPerLevel;
    public float happinessDecreasePerSecond = -0.1f;
    

    float currentHappiness;
    float currentTime;

    public Events eventSystem;

    /** UI **/
    public Slider progressBar;

    void Awake()
    {
        currentHappiness = 0f;
        UpdateProgressBar();

        currentTime = 0f;

        eventSystem.CatHappinessChanged += OnCatHappinessChanged;
        eventSystem.LevelIncreased += increaseMaxHappiness;
    }

    private void OnDisable()
    {
        eventSystem.CatHappinessChanged -= OnCatHappinessChanged;
        eventSystem.LevelIncreased -= increaseMaxHappiness;
    }

    private void OnCatHappinessChanged(float happinessChange)
    {
        AddToCurrentHappiness(happinessChange);
    }

    private void Update()
    {
        if (currentTime >= 1f)
        {
            AddToCurrentHappiness(-happinessDecreasePerSecond);
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

        UpdateProgressBar();
    }

    private void UpdateProgressBar()
    {
        // Set the slider to the actual value
        float currentHappiness0To1Range = currentHappiness / ultimateMaxHappiness;
        progressBar.value = currentHappiness0To1Range;
    }

    private void increaseMaxHappiness() {
        maxHappinessPerLevel += 14f;
    }
}

