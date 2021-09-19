using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvManager : MonoBehaviour
{
    public GameObject[] envEffects;
    public GameObject[] skyEffects;
    public Events eventSystem;

    private void Awake()
    {
        eventSystem.LevelIncreased += AdjustEnvEffects;
    }

    private void OnDisable()
    {
        eventSystem.LevelIncreased -= AdjustEnvEffects;
    }

    private void AdjustEnvEffects()
    {
        Debug.Log("Changing environment");
        int newLevel = GameManager.Instance.currentLevel;
        //for (int i = 0; i < envEffects.Length; i++)
        //{
        //    if (newLevel <= i)
        //    {
        //        envEffects[i].SetActive(true);
        //        Debug.Log("Set active " + envEffects[i].name + " index " + i);
        //    }
        //}

        envEffects[newLevel - 1].SetActive(true);
        for (int i = 0; i < skyEffects.Length; i++)
        {
            if (i == newLevel - 1)
            {
                skyEffects[i].SetActive(false);
                return;
            }
        }
    }
}
