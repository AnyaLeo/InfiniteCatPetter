using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCat : MonoBehaviour
{
    float mousex1;
    float mousey1;
    Vector3 mousepos;

    public float catHappinessPerPet = 5f;
    public float catHairPerPet = 1f;

    public GameObject catParticles;

    void Awake()
    {
        float mouseXValue = Input.GetAxis("Mouse X");
        float mouseYValue = Input.GetAxis("Mouse Y");
        mousepos = Input.mousePosition;
    }

    private void OnMouseDown()
    {
        mousepos = Input.mousePosition;
        mousex1 = mousepos.x;
        mousey1 = mousepos.y;
    }

    private void OnMouseUp()
    {
        mousepos = Input.mousePosition;
        float dist = Mathf.Sqrt(Mathf.Pow((mousepos.x - mousex1), 2) + Mathf.Pow((mousepos.y - mousey1), 2));
        if (dist > 50)
        {
            print("Working");
            Events.Instance.CatHappinessChanged(catHappinessPerPet);
            GameManager.Instance.currentCatHair += catHairPerPet;

            //GameObject particleSystem = Instantiate(catParticles);
            //particleSystem.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //particleSystem.transform.localPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}

