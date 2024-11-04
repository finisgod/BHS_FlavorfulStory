using UnityEngine;

/// <summary> �����, ����������� ������ ������� ���������. �������� �� ������ ��������� ������ � ��� ����������.
/// ��������� UI �������� ��������� � �������</summary>
public class PlayerInventoryEventManager : MonoBehaviour //�� ������ ������� ���������� �� ������ ��� ������ -> ������� ��������
{
    /// <summary>������ �� ������ UI ��������� ���������.</summary>
    [SerializeField] InventoryManagerUI inventoryManagerUI;
    /// <summary>������ �� ������ ��������� ���������.</summary>
    private InventoryManager manager = null; //�� ���� ������ ����� SerializeField
    /// <summary>����� ��� ������������� ����� ���������.</summary>
    private void Start()
    {
        manager = this.GetComponentInChildren<InventoryManager>(); //�� ���� ������ ����� SerializeField
        manager.ItemAddedEvent += InventoryManager_ItemAddedEvent;
        manager.ItemRemovedEvent += InventoryManager_ItemRemovedEvent;
        manager.ItemCountChangedEvent += InventoryManager_ItemCountChangedEvent;
        inventoryManagerUI.ItemSelectedChangedEvent += InventoryManager_ItemSelectedEvent;
    }
    /// <summary>��������� ���������� ������ � ���������.</summary>
    private void InventoryManager_ItemAddedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent add with itemname: " + newItem.Name + ":COUNT:" + newItem.Count);
        inventoryManagerUI.AddItem(newItem);
    }
    /// <summary>��������� ��������� ���������� ������ � ���������.</summary>
    private void InventoryManager_ItemCountChangedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent new count: " + newItem.Name + ":COUNT:" + newItem.Count);
        inventoryManagerUI.ChangeItemCount(newItem);
    }
    /// <summary>��������� �������� ������ �� ���������.</summary>
    private void InventoryManager_ItemRemovedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent remove with itemname: " + newItem.Name);
        inventoryManagerUI.RemoveItem(newItem);
    }
    /// <summary>��������� ������ �������� ������.</summary>
    private void InventoryManager_ItemSelectedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent selected item with itemname: " + newItem.Name);
        manager.SetCurrentInventoryItem(manager.GetInventoryItemIndex(newItem));
    }
}