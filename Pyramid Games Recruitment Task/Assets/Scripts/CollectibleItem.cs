using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private Collectibles item;

    public void AddToInventory()
    {
        inventory.AddItem(item);
    }
}
