using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField] private Item item;
    public void Pickup()
    {
        CharacterInventory.Instance.AddItem(item);
    }
}
