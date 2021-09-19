using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopChildUI : MonoBehaviour
{   
    [SerializeField]
    private GameObject popUpDescription;

    private void OnMouseDown()
    {
        transform.parent.GetComponent<ShopUI>().childClicked(transform.gameObject);
    }
}
