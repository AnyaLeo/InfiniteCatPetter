using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{
    [SerializeField]
    private GameObject popUpDescription;
    [SerializeField]
    private GameObject itemTitleUI;
    [SerializeField]
    private GameObject itemdescriptorUI;
    [SerializeField]
    private string itemTitle;
    [SerializeField]
    private string itemDescription;

    private void OnMouseEnter()
    {
        popUpDescription.SetActive(true);
        itemTitleUI.GetComponentInParent<Text>().text = itemTitle;
        itemdescriptorUI.GetComponentInParent<Text>().text = itemDescription;
        Vector3 cursorVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 popUpvector = new Vector3(cursorVector.x, cursorVector.y, 0);
        popUpDescription.transform.SetPositionAndRotation(popUpvector, popUpDescription.transform.rotation);
    }

    private void OnMouseExit()
    {
        popUpDescription.SetActive(false);
    }
}
