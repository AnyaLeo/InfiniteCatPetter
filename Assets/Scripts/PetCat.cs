using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetCat : MonoBehaviour
{
    float mousex1;
    float mousey1;
    Vector3 mousepos;
    private Vector3 objectPos;

    public float catHappinessPerPet = 5f;
    public float catHairPerPet = 1f;

    public GameObject FloatingText;

    private float lastTimePetHappened;
    [Tooltip("How long we wait since the last pet to cancel the purr")]
    public float timeBetweenPetsPurrThreshold = 3f;

    CatSounds catSounds;

    void Awake()
    {
        float mouseXValue = Input.GetAxis("Mouse X");
        float mouseYValue = Input.GetAxis("Mouse Y");
        mousepos = Input.mousePosition;
    }

    private void Start()
    {
        catSounds = FindObjectOfType<CatSounds>();
    }

    private void Update()
    {
        float timeSinceLastPet = Time.time - lastTimePetHappened;
        if (timeSinceLastPet > timeBetweenPetsPurrThreshold && catSounds != null)
        {
            catSounds.DeactivatePurr();
        }

        // TODO: There's probably a better way for this
        catHairPerPet = 1f + GameManager.Instance.catHairGainBonus;
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
        mousepos.z = 2.0f;
        objectPos = Camera.main.ScreenToWorldPoint(mousepos);
        float dist = Mathf.Sqrt(Mathf.Pow((mousepos.x - mousex1), 2) + Mathf.Pow((mousepos.y - mousey1), 2));
        if (dist > 50)
        {
            lastTimePetHappened = Time.time;
            if (catSounds != null)
            {
                catSounds.ActivatePurr();
            }

            Events.Instance.CatHappinessChanged(catHappinessPerPet);
            CatHairManager.Instance.ChangeCatHair(catHairPerPet);
            Instantiate(FloatingText, objectPos, Quaternion.identity);

        }
    }
}

