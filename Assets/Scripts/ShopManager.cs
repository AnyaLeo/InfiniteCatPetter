using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{   
    [SerializeField]
    private ArrayList shopItems;

    private void Awake()
    {
        shopItems = new ArrayList();

        foreach (Transform child in transform)
        {   
            if (child.GetComponent<ShopItem>() != null)
            {
                shopItems.Add(child);
            }
        }

        foreach (var item in shopItems)
        {
            Debug.Log(item);
        }
    }
}
