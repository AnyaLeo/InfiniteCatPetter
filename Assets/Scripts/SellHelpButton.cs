using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellHelpButton : MonoBehaviour
{
    bool isBlurbVisible;
    GameObject blurb;
    GameObject blurbText;

    private void Awake()
    {   
        isBlurbVisible = false;
        blurb = GameObject.Find("SellButton/SellBlurb");
        blurbText = GameObject.Find("SellButton/BlurbText");
        blurb.SetActive(false);
        blurbText.SetActive(false);
    }

    void OnMouseDown()
    {   
        Debug.Log("Clicked help");
        if (isBlurbVisible)
        {
            blurb.SetActive(false);
            blurbText.SetActive(false);
            isBlurbVisible = false;
        } else
        {
            blurb.SetActive(true);
            blurbText.SetActive(true);
            isBlurbVisible = true;
        }
    }
}
