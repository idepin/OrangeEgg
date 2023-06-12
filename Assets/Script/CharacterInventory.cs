using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharacterInventory : Singleton<CharacterInventory>
{
    #region Fields

    [SerializeField] private int maxCapacity = 3;

    private readonly List<Item> items = new List<Item>();
    
    private StringBuilder builder;
    
    #endregion

    #region Properties

    public IReadOnlyCollection<Item> Items => items;

    #endregion

    #region Methods

    public void AddItem(Item item)
    {
        if (Items.Count >= maxCapacity)
            return;

        if (HasItem(item))
            return;
        
        items.Add(item);
        InventoryUI.Instance.AddItemUI(item);

        builder.Clear();
        builder.Append("Item ");
        builder.Append(item.itemName);
        builder.Append(" Has been Added");
        Debug.Log(builder);
    }

    public void RemoveItem(Item item)
    {
        if (!items.Remove(item))
            return;
        
        InventoryUI.Instance.RemoveItemUI(item);

        builder.Clear();
        builder.Append("Item ");
        builder.Append(item.itemName);
        builder.Append(" Has been Removed");
        Debug.Log(builder);
    }

    private bool HasItem(Item item)
    {
        return items.Contains(item);
    }

    #endregion
}
