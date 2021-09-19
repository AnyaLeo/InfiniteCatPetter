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
    private GameObject envrMenuBtnOff;
    [SerializeField]
    private GameObject petMenuBtnOff;
    [SerializeField]
    private GameObject shopIconBtn;
    [SerializeField]
    private GameObject shopBoxUI;

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
            envrMenuBtn.SetActive(false);
            envrMenuBtnOff.SetActive(true);
            petMenuBtn.SetActive(true);
            petMenuBtnOff.SetActive(false);
            isShopVisible = true;
        }
        Debug.Log("click shop");
    }

    public void childClicked(GameObject gameObject)
    {   
        // click envrMenubtn
        if (gameObject.Equals(envrMenuBtnOff))
        {   
            foreach (Transform child in petMenuBtn.transform)
            {
                child.gameObject.SetActive(false);
            }
            foreach (Transform child in envrMenuBtn.transform)
            {
                child.gameObject.SetActive(true);
            }
            envrMenuBtn.SetActive(true);
            envrMenuBtnOff.SetActive(false);
            petMenuBtn.SetActive(false);
            petMenuBtnOff.SetActive(true);

        }

        // click petMenuBtn
        if (gameObject.Equals(petMenuBtnOff))
        {
            foreach (Transform child in envrMenuBtn.transform)
            {
                child.gameObject.SetActive(false);
            }
            foreach (Transform child in petMenuBtn.transform)
            {
                child.gameObject.SetActive(true);
            }
            envrMenuBtn.SetActive(false);
            envrMenuBtnOff.SetActive(true);
            petMenuBtn.SetActive(true);
            petMenuBtnOff.SetActive(false);
        }
    }
}
