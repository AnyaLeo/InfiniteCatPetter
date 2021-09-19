using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSounds : MonoBehaviour
{
    public AudioSource purr;

    public AudioSource[] meows;

    public float minSecondsBetweenMeows = 10f;
    public float maxSecondsBetweenMeows = 60f;

    float currentTime;
    float currentSecondsBetweenMeows;

    private void Start()
    {
        currentTime = 0;
        currentSecondsBetweenMeows = minSecondsBetweenMeows;
    }

    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivatePurr();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            DeactivatePurr();
        }
#endif

        currentTime += Time.deltaTime;
        if (currentTime >= currentSecondsBetweenMeows)
        {
            currentTime = 0;
            currentSecondsBetweenMeows = Random.Range(minSecondsBetweenMeows, maxSecondsBetweenMeows);

            int randomIndex = Random.Range(0, meows.Length);
            meows[randomIndex].Play();
        }
    }

    public void ActivatePurr()
    {
        if (purr.isPlaying)
            return;

        purr.Play();
        StopAllCoroutines();
        StartCoroutine(LerpPurr(0f, 1f, 2f));
    }

    public void DeactivatePurr()
    {
        StopAllCoroutines();
        StartCoroutine(LerpPurr(purr.volume, 0f, 2f));
    }

    IEnumerator LerpPurr(float startVolume, float endVolume, float duration)
    {
        float currentTime = 0f;

        purr.volume = startVolume;

        while (currentTime < duration)
        {
            float currentVolume = Mathf.Lerp(startVolume, endVolume, currentTime / duration);
            purr.volume = currentVolume;

            currentTime += Time.deltaTime;

            yield return null;
        }

        if (startVolume > endVolume)
        {
            purr.Stop();
        }

        yield return null;
    }
}
