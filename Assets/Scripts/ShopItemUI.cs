using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private float popupHeight;
    private float popupWidth;

    public void Awake()
    {
        popupHeight = popUpDescription.transform.GetComponent<RectTransform>().sizeDelta.x;
        popupWidth = popUpDescription.transform.GetComponent<RectTransform>().sizeDelta.y;
    }

    private void OnMouseEnter()
    {
        popUpDescription.SetActive(true);
        itemTitleUI.GetComponentInParent<TextMeshProUGUI>().text = itemTitle;
        itemdescriptorUI.GetComponentInParent<TextMeshProUGUI>().text = itemDescription;
        Vector3 cursorVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 popUpvector = new Vector3(cursorVector.x + 1, cursorVector.y + 1, 0);
        popUpDescription.transform.SetPositionAndRotation(popUpvector, popUpDescription.transform.rotation);
    }

    private void OnMouseExit()
    {
        popUpDescription.SetActive(false);
    }
}
