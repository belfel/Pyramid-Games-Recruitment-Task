using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RequiresItem : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private Collectibles item;

    public UnityEvent gotItem;
    public UnityEvent lostItem;

    private UnityAction action;
    private bool hasItem = false;

    private void Awake()
    {
        SetupListener();
    }

    private void Start()
    {
        CheckInventoryForItem();
    }

    private void SetupListener()
    {
        var listener = gameObject.AddComponent<GameEventListener>();
        inventory.onInventoryChangedEvent.RegisterListener(listener);
        action += CheckInventoryForItem;
        listener.Event = inventory.onInventoryChangedEvent;
        listener.Response = new UnityEvent();
        listener.Response.AddListener(action);
    }

    public void CheckInventoryForItem()
    {
        bool itemInInventory = inventory.items.Contains(item);

        if (itemInInventory)
        {
            if (!hasItem)
            {
                gotItem.Invoke();
                hasItem = true;
            }
        }

        else
        {
            if (hasItem)
            {
                lostItem.Invoke();
                hasItem = false;
            }
        }
    }
}
