using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButtonUI : MonoBehaviour
{
    void OnMouseDown()
    {   
        Debug.Log("Clicked sell");
        CatHairManager.Instance.ChangeCatHair(CatHairManager.Instance.currentCatHair);
        MoneyManager.Instance.OnCatHairSold();
        

    }
}
