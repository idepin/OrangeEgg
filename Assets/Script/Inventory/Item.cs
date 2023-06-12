using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "OrangeEgg/Item", order = 1)]
public class Item : ScriptableObject
{
    #region Fields

    public string itemName;
    
    public int amount;
    
    public Sprite itemImage;
    
    public GameObject itemObject;

    #endregion
}
