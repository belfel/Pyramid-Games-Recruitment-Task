using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Scriptable Objects/Inventory")]
public class Inventory : ScriptableObject
{
    public GameEvent onInventoryChangedEvent;
    public List<Collectibles> items = new List<Collectibles>();

    public void AddItem(Collectibles item)
    {
        items.Add(item);
        onInventoryChangedEvent.Raise();
    }

    public void RemoveItem(Collectibles item)
    {
        items.Remove(item);
        onInventoryChangedEvent.Raise();
    }

    public void Clear()
    {
        items.Clear();
        onInventoryChangedEvent.Raise();
    }
}
