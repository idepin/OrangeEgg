using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    #region Fields

    [SerializeField] private Transform itemContainer;
    
    [SerializeField] private ItemUI itemUIPrefab;

    #endregion

    #region Methods

    public void AddItemUI(Item item)
    {
        ItemUI itemUI = Instantiate(itemUIPrefab, itemContainer);
        itemUI.itemName = item.name;
        itemUI.itemImage.overrideSprite = item.itemImage;
    }

    public void RemoveItemUI(Item item)
    {
        foreach(Transform itemUI in itemContainer)
        {
            if (itemUI.GetComponent<ItemUI>().name != item.name) continue;
            
            Destroy(itemUI);
            break;
        }
    }
    
    public void ClearItemUI()
    {
        foreach(Transform itemUI in itemContainer)
        {
            Destroy(itemUI);
        }
    }

    #endregion
}
