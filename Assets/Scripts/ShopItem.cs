using UnityEngine;

public class ShopItem : MonoBehaviour
{
    [SerializeField]
    private readonly string itemName;
    [SerializeField]
    private readonly int itemPrice;
    [SerializeField]
    private float happinessEffect;
    [SerializeField]
    private float hairGainEffect;
    [SerializeField]
    private float timeTaken;
    [SerializeField]
    private bool isLocked;
}
