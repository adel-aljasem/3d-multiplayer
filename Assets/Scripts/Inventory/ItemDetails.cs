using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemDetails
{
    public int itemCode;
    public ItemType itemtype;
    public string itemName;
    public Sprite itemSprite;
    public bool canBroke;
    public bool canBeEaten;
    public bool canBeGatherd;
}
