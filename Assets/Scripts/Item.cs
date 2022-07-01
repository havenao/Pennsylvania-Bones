using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : GridObject
{
    public static Action<Item> OnGetItem;

    protected override void PlayerPickup()
    {
        AddItemToInventory();
        // Todo: Add Item To Inventory  
    }

    private void AddItemToInventory()
    {
        LevelManager.Instance.CurrentLevel.Grid.RemoveObject(this);
        OnGetItem?.Invoke(this);
    }

    public abstract void Use();
}
