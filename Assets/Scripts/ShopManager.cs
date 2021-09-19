using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{   
    [SerializeField]
    private ArrayList shopItems;
    private ArrayList shopItemsEnv;
    private int[] petItemsBought;
    private int[] envItemsBought;

    private void Awake()
    {
        Debug.Log("Shop manager is awake");
        shopItems = new ArrayList();
        shopItemsEnv = new ArrayList();

        GameObject shopObject = GameObject.Find("Canvas/ShopIcon");
        Transform transform = shopObject.GetComponent<Transform>();

        foreach (Transform child in transform)
        {   
            foreach (Transform grandchild in child)
            {   
                foreach (Transform greatGrandchild in grandchild)
                {   
                    // Debug.Log("greatgrandchild " + greatGrandchild);
                    if (greatGrandchild.GetComponent<ShopItem>() != null)
                    {
                        shopItems.Add(greatGrandchild);
                        // Debug.Log("Found pet item");
                    } else if (greatGrandchild.GetComponent<ShopItemEnvironment>() != null)
                    {
                        shopItemsEnv.Add(greatGrandchild);
                        // Debug.Log("Found env item");
                    }
                }
            }
        }

        envItemsBought = new int[shopItemsEnv.Count];
        Debug.Log("test " + petItemsBought);

        foreach (var item in shopItems)
        {
            Debug.Log("Pet item: " + item);
        }
        foreach (var item in shopItemsEnv)
        {
            Debug.Log("Env Item: " + item);
        }
    }

    public bool isAllowedToBuy(GameObject gameObject)
    {
        return true;
    }
}
