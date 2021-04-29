using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{

    public Image inventorySlotImage;
    public Text amountText;
    public ItemDetails itemDetails;
    public int itemQuantity;

    private void Start()
    {
        inventorySlotImage = GetComponent<Image>();
        amountText = GetComponentInChildren<Text>();
       
    }
}
