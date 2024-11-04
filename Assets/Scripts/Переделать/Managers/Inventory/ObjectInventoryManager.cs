using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �������� ������ � ���������� ������.</summary>
public class ObjectInventoryManager : MonoBehaviour
{
    /// <summary> ������ UI ������.</summary>
    [SerializeField] GameObject _inventoryUi;
    /// <summary> �������� ��������� ���������.</summary>
    [SerializeField] InventoryManager _inventoryManager;
    /// <summary> ������� ����� � ���� ������.</summary>
    private Item _selectedItem;

    /// <summary>����� ���������� � ��������� .</summary>
    /// <param name="item"> .</param>
    public void AddItem(Item item)
    {
        _inventoryManager.AddToInventory(item);
    }
    /// <summary>�������� ���������/���������� ��������� .</summary>
    public void ToggleInventory()
    {
        Debug.Log("Use toggle");
        _inventoryUi.SetActive(!_inventoryUi.activeSelf);
    }
}