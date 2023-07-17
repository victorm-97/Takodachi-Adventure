using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { HEAL, KEY, DMG }

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item", order = 1)]

public class ItemSC : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon;
    public ItemType type;

    public virtual void Use()
    {
        // this function is supposed to be overriden
    }

    public virtual void Drop()
    {
        Inventory.instance.RemoveItem(this);

        // this function is supposed to be overriden
        // if further functionality is needed
    }
}