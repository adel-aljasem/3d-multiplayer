using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class InventoryManager : SingletonMonoBehavior<InventoryManager>
{
    public Dictionary<int, ItemDetails> itemDetailsDictionary;
    public List<InventoryItem>[] inventoryList;

    [SerializeField]
    private SO_ItemList itemList;


    protected override void Awake()
    {
        base.Awake();

        CreateItemDetailsDictionary();
        CreateIventoryList();
    }

    private void CreateIventoryList()
    {
        inventoryList = new List<InventoryItem>[(int)InventoryLocation.count];
        for (int i = 0; i < (int)InventoryLocation.count; i++)
        {
            inventoryList[i] = new List<InventoryItem>();
        }

    }


    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach (ItemDetails itemDetail in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemDetail.itemCode, itemDetail);
        }
    }

    public void AddItem(InventoryLocation inventoryLocation, ICollectable item, GameObject gameObjectToDelete)
    {
        AddItem(inventoryLocation, item);

        Destroy(gameObjectToDelete);
    }


    public void AddItem(InventoryLocation inventoryLocation, ICollectable item)
    {
        int itemCode = item.IdItem;
       ;

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);
        if (itemPosition != -1)
        {
            // if there is item make it stackable
            AddItemAtPosition(inventoryList[(int)inventoryLocation], itemCode, itemPosition);
        }
        else
        {
            // add new item
            AddItemAtPosition(inventoryList[(int)inventoryLocation], itemCode);
        }


        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryList[(int)inventoryLocation]);

    }

    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int position)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQuantity + 1;

        inventoryItem.itemQuantity = quantity;
        inventoryItem.itemCode = itemCode;
        inventoryList[position] = inventoryItem;
        WebApi.Post(inventoryItem);

    }

    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {
        InventoryItem inventoryItems = new InventoryItem();
        inventoryItems.itemCode = itemCode;
        inventoryItems.itemQuantity = 1;
        inventoryList.Add(inventoryItems);
        
       WebApi.Post(inventoryItems);

    }

    private int FindItemInInventory(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryLists = inventoryList[(int)inventoryLocation];
        for (int i = 0; i < inventoryLists.Count; i++)
        {
            if (itemCode == inventoryLists[i].itemCode)
            {
                return i;
            }
        }
        return -1;
    }

    public void RemoveItem(int itemCode , InventoryLocation inventoryLocation)
    {
        List<InventoryItem> inventoryItems = inventoryList[(int)inventoryLocation];

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

        if(itemPosition != -1)
        {
            RemoveItemAtPosition(inventoryItems, itemCode, itemPosition);
        }

    }

    private void RemoveItemAtPosition(List<InventoryItem> inventoryList,int itemCode, int position)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[position].itemQuantity - 1;
        if(quantity > 0)
        {
            inventoryItem.itemQuantity = quantity;
            inventoryItem.itemCode = itemCode;
            inventoryList[position] = inventoryItem;
        }
        else
        {
            inventoryList.RemoveAt(position);
        }
    }

    public ItemDetails GetItemDetails(int itemCode)
    {
        ItemDetails itemDetails;

        if (itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            return itemDetails;
        }
        else
        {
            return null;
        }
    }
}
