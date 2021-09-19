using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHairManager : Singleton<CatHairManager> 
{
    public float currentCatHair;
    

    public void ChangeCatHair(float difference)
    {
        currentCatHair += difference;
    }

   
}
