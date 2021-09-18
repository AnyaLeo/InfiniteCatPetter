using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{   
    [SerializeField]
    private GameObject envrMenuBtn;
    [SerializeField]
    private GameObject petMenuBtn;
    [SerializeField]
    private GameObject shopIconBtn;

    private bool isShopVisible;
    private bool isEnvVisible;
    private bool isPetVisible;

    private void Awake()
    {   

        foreach(Transform child in shopIconBtn.transform)
        {
            child.gameObject.SetActive(false);
        }

        isShopVisible = false;
    }

    void OnMouseDown()
    {   
        if (isShopVisible)
        {
            foreach (Transform child in shopIconBtn.transform)
            {
                child.gameObject.SetActive(false);
            }
            isShopVisible = false;
        } else
        {
            foreach (Transform child in shopIconBtn.transform)
            {
                child.gameObject.SetActive(true);
            }
            isShopVisible = true;
        }
        Debug.Log("click shop");
    }
}
