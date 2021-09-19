using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopChildUI : MonoBehaviour
{   

    private void OnMouseDown()
    {
        transform.parent.GetComponent<ShopUI>().childClicked(transform.gameObject);
    }
}
