using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Менеджер работы с инвентарем игрока.</summary>
public class ObjectInventoryManager : MonoBehaviour
{
    /// <summary> Обхект UI игрока.</summary>
    [SerializeField] GameObject _inventoryUi;
    /// <summary> Менеджер коллекции инвентаря.</summary>
    [SerializeField] InventoryManager _inventoryManager;
    /// <summary> Текущий айтем в руке игрока.</summary>
    private Item _selectedItem;

    /// <summary>Метод добавления в инвентарь .</summary>
    /// <param name="item"> .</param>
    public void AddItem(Item item)
    {
        _inventoryManager.AddToInventory(item);
    }
    /// <summary>Методдля включения/выключения инвентаря .</summary>
    public void ToggleInventory()
    {
        Debug.Log("Use toggle");
        _inventoryUi.SetActive(!_inventoryUi.activeSelf);
    }
}