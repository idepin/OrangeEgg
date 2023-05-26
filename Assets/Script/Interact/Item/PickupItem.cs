using UnityEngine;

public class PickupItem : MonoBehaviour
{
    #region Fields

    [SerializeField] private Item item;

    #endregion

    #region Methods

    public void Pickup()
    {
        CharacterInventory.Instance.AddItem(item);
    }

    #endregion
}
