using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    [SerializeField] private Transform itemContainer;
    [SerializeField] private ItemUI itemUIPrefab;

    public void AdditemUI(Item item)
    {
        ItemUI itemUI = Instantiate(itemUIPrefab, itemContainer);
        itemUI.itemName = item.name;
        itemUI.itemImage.overrideSprite = item.itemImage;
    }

    public void RemoveItemUI(Item item)
    {
        foreach(Transform itemUI in itemContainer)
        {
            if(itemUI.GetComponent<ItemUI>().name == item.name)
            {
                Destroy(itemUI);
                break;
            }
        }
    }
    
    public void ClearItemUI()
    {
        foreach(Transform itemUI in itemContainer)
        {
            Destroy(itemUI);
        }
    }
}
