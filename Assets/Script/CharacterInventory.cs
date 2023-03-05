using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventory : Singleton<CharacterInventory>
{
    [SerializeField] private int maxCapacity = 3;
    public List<Item> items = new List<Item>();


    public void AddItem(Item item)
    {
        if(items.Count >= maxCapacity)
        {
            return;
        }
        if (!items.Contains(item))
        {
            items.Add(item);
            InventoryUI.Instance.AdditemUI(item);
            Debug.Log("Item " + item.itemName + " Has been Added");
        } 
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            InventoryUI.Instance.RemoveItemUI(item);
            Debug.Log("Item " + item.itemName + " Has been Removed");
        }
    }

    public bool Hasitem(Item item)
    {
        return items.Contains(item);
    }
}
