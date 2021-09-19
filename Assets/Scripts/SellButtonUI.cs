using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellButtonUI : MonoBehaviour
{
    void OnMouseDown()
    {   
        Debug.Log("Clicked sell");
        GameObject.Find("MoneyManager").GetComponent<MoneyManager>().OnCatHairSold();
    }
}
