using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatHairManager : Singleton<CatHairManager> 
{
    public float currentCatHair;

    public TextMeshProUGUI catHairText;

    private void Start()
    {
        catHairText.text = currentCatHair.ToString("f0");
    }

    public void ChangeCatHair(float difference)
    {
        currentCatHair += difference;

        catHairText.text = currentCatHair.ToString("f0");
    }

   
}
