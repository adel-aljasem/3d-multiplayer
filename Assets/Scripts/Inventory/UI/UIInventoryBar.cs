using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class UIInventoryBar : MonoBehaviour
{
    [SerializeField] private Sprite blankSprite;
    [SerializeField] private InventorySlot[] inventorySlot;


    private void OnEnable()
    {
        EventHandler.InventoryUpdatedEvent += InventoryUpdated;
    }



    private  void ClearInventorySlots()
    {
        if (inventorySlot.Length > 0)
        {
            for (int i = 0; i < inventorySlot.Length; i++)
            {
                inventorySlot[i].inventorySlotImage.sprite = null;
                inventorySlot[i].amountText.text = "";
                inventorySlot[i].itemDetails = null;
                inventorySlot[i].itemQuantity = 0;
            }
        }
    }


    public  void InventoryUpdated(InventoryLocation inventoryLocation, List<InventoryItem> inventoryList)
    {
        if (inventoryLocation == InventoryLocation.Player)
        {
            ClearInventorySlots();

            if (inventorySlot.Length > 0 && inventoryList.Count > 0)
            {
                for (int i = 0; i < inventorySlot.Length; i++)
                {
                    if (i < inventoryList.Count)
                    {
                        int itemCode = inventoryList[i].itemCode;

                        ItemDetails itemDetails = InventoryManager.Instance.GetItemDetails(itemCode);

                        if (itemDetails != null)
                        {
                            inventorySlot[i].inventorySlotImage.sprite = itemDetails.itemSprite;
                            inventorySlot[i].amountText.text = inventoryList[i].itemQuantity.ToString();
                            inventorySlot[i].itemDetails = itemDetails;
                            inventorySlot[i].itemQuantity = inventoryList[i].itemQuantity;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
}
