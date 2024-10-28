using System.Collections.Generic;
using UnityEngine;

/// <summary> Клас-менеджер отвечающий за инвентарь. </summary>
public class InventoryManager : MonoBehaviour
{
    /// Ссылка на коллекцию с айтемами .</summary>
    private InventoryCollection _inventory;
    /// <summary>текущий выбранный айтем .</summary>
    private Item _selectedItem = null;
    /// <summary>Метод , вызывающийся при активации объекта на котором висит скрипт .</summary>
    private void Start()
    {
        _inventory = new InventoryCollection();
    }
    /// <summary>Метод добавления Item в инвентарь .</summary>
    /// <param name="item"> .</param>
    public void AddToInventory(Item item)
    {
        //AddLogic for item prefab
        Debug.Log("From InventoryManager / Added: " + item.Name);
        if (!_inventory.ContainsName(item.Name))
        {
            item.Count = 1;
            _inventory.Add(item);
            ItemAddedEvent?.Invoke(item);
        }
        else
        {
            Item inventoryItem = _inventory.GetItemByName(item.Name);
            inventoryItem.Count++;
            ItemCountChangedEvent?.Invoke(inventoryItem);
        }
        if (_inventory.Count == 1)
        {
            _selectedItem = this.GetInventoryItem(0);
        }
    }
    /// <summary>Метод удаления из инвентаря .</summary>
    /// <param name="item"> .</param>
    public void RemoveFromInventory(Item item)
    {
        //DropLogic
        Item inventoryItem = _inventory.GetItemByName(item.Name);
        if (inventoryItem != null)
        {
            if (inventoryItem.Count == 1)
            {
                _inventory.Remove(item);
                ItemRemovedEvent?.Invoke(item);
            }
            else
            {
                inventoryItem.Count--;
                ItemCountChangedEvent?.Invoke(inventoryItem);
            }
        }
        //Selected item logic
        if (_inventory.Count == 0)
        {
            _selectedItem = null;
        }
        else
        {
            _selectedItem = _inventory.GetItem(0);
        }
    }
    /// <summary> Метод для получения листа айтемов.</summary>
    public List<Item> GetAllInventoryItems()
    {
        return _inventory.GetAll();
    }
    /// <summary> Метод для получения айтема по индексу.</summary>
    public Item GetInventoryItem(int index)
    {
        return _inventory.GetItem(index);
    }
    /// <summary> Метод для получения индекса айтема в коллекции.</summary>
    public int GetInventoryItemIndex(Item item)
    {
        return _inventory.GetIndex(item);
    }
    /// <summary> Метод для получения выбанного айтема.</summary>
    public Item GetCurrentInventoryItem()
    {
        return _selectedItem;
    }
    /// <summary> Метод для выбора текущего айтема.</summary>
    public void SetCurrentInventoryItem(int index)
    {
        Debug.Log("Set current inventory item: " + index);
        if (index < _inventory.Count && index > 0)
        {
            //DropLogic
            _selectedItem = GetInventoryItem(index);
        }
    }
    /// <summary> Хендлер для эвента, отражающего событие добавления нового айтема в инвентарь.</summary>
    public delegate void ItemAddedHandler(Item newItem);
    public event ItemAddedHandler ItemAddedEvent;
    /// <summary> Хендлер для эвента, отражающего событие изменения счетчика айтема в инвентаре.</summary>
    public delegate void ItemCountChangedHandler(Item newItem);
    public event ItemCountChangedHandler ItemCountChangedEvent;
    /// <summary> Хендлер для эвента, отражающего удаление айтема из инвентаря.</summary>
    public delegate void ItemRemovedHandler(Item newItem);
    public event ItemRemovedHandler ItemRemovedEvent;
}
