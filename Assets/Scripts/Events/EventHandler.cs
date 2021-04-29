using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public static class EventHandler 
{
    public static event Action<InventoryLocation, List<InventoryItem>> InventoryUpdatedEvent;

    public static void CallInventoryUpdatedEvent(InventoryLocation inventoryLocation, List<InventoryItem> inventoryItems)
    {
        if(InventoryUpdatedEvent != null)
        {
            InventoryUpdatedEvent(inventoryLocation, inventoryItems);
        }
    }
}
