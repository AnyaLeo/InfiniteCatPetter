using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    public GameObject petMenuText;
    public GameObject envrMenuText;
    private TextMeshProUGUI petMenuTextMesh;
    private TextMeshProUGUI envrMenuTextMesh;

    public TMP_ColorGradient normalGradient;
    public TMP_ColorGradient fadedGradient;

    public Texture2D initialCursorTexture;

    private bool isShopVisible;
    private bool isEnvVisible;
    private bool isPetVisible;
    

    private void Awake()
    {
        petMenuTextMesh = petMenuText.GetComponent<TextMeshProUGUI>();
        envrMenuTextMesh = envrMenuText.GetComponent<TextMeshProUGUI>();

        foreach(Transform child in shopIconBtn.transform)
        {
            child.gameObject.SetActive(false);
        }

        petMenuText.SetActive(false);
        envrMenuText.SetActive(false);

        isShopVisible = false;

        Cursor.SetCursor(initialCursorTexture, Vector2.zero, CursorMode.Auto);
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

            petMenuText.SetActive(false);
            envrMenuText.SetActive(false);
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

            petMenuText.SetActive(true);
            envrMenuText.SetActive(true);

            petMenuTextMesh.colorGradientPreset = normalGradient;
            envrMenuTextMesh.colorGradientPreset = fadedGradient;
        }
        //Debug.Log("click shop");
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

            petMenuText.SetActive(true);
            envrMenuText.SetActive(true);

            petMenuTextMesh.colorGradientPreset = fadedGradient;
            envrMenuTextMesh.colorGradientPreset = normalGradient;
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

            petMenuText.SetActive(true);
            envrMenuText.SetActive(true);

            petMenuTextMesh.colorGradientPreset = normalGradient;
            envrMenuTextMesh.colorGradientPreset = fadedGradient;
        }
    }


}
