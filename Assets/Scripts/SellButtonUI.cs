using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButtonUI : MonoBehaviour
{
    void OnMouseDown()
    {   
        Debug.Log("Clicked sell");
        MoneyManager.Instance.OnCatHairSold();
    }
}
