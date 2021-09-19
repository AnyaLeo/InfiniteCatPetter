using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CatHappiness : MonoBehaviour
{
    [Tooltip("The maximum cat happiness that can be reached at the final level")]
    public float ultimateMaxHappiness = 100f;
    public float maxHappinessPerLevel;
    public float happinessDecreasePerSecond = -0.1f;

    float currentHappiness;
    float currentTime;

    public Events eventSystem;

    /** UI **/
    public TextMeshProUGUI happinessText;
    public Slider progressBar;

    void Awake()
    {
        currentHappiness = 0f;
        happinessText.text = "0";
        UpdateProgressBar();

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
}

public static class ExtensionMethods
{
    public static float Remap(this float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}

