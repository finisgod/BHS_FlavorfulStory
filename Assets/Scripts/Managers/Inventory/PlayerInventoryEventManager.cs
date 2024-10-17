using UnityEngine;

/// <summary> Класс, описывающий логику эвентов инвентаря. Вешается на объект инвентаря вместе с его менеджером.
/// Соединяет UI менеджер инвентаря и обычный</summary>
public class PlayerInventoryEventManager : MonoBehaviour //Мб сможет закрыть функционал не только для игрока -> обощить название
{
    /// <summary>Ссылка на объект UI менеджера инвентаря.</summary>
    [SerializeField] InventoryManagerUI inventoryManagerUI;
    /// <summary>Ссылка на объект менеджера инвентаря.</summary>
    private InventoryManager manager = null; //Мб тоже просто через SerializeField
    /// <summary>Метод для инициализации эвент менеджера.</summary>
    private void Start()
    {
        manager = this.GetComponentInChildren<InventoryManager>(); //Мб тоже просто через SerializeField
        manager.ItemAddedEvent += InventoryManager_ItemAddedEvent;
        manager.ItemRemovedEvent += InventoryManager_ItemRemovedEvent;
        manager.ItemCountChangedEvent += InventoryManager_ItemCountChangedEvent;
        inventoryManagerUI.ItemSelectedChangedEvent += InventoryManager_ItemSelectedEvent;
    }
    /// <summary>Обработка добавления айтема в инвентарь.</summary>
    private void InventoryManager_ItemAddedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent add with itemname: " + newItem.Name + ":COUNT:" + newItem.Count);
        inventoryManagerUI.AddItem(newItem);
    }
    /// <summary>Обработка измненеия количества айтема в инвентаре.</summary>
    private void InventoryManager_ItemCountChangedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent new count: " + newItem.Name + ":COUNT:" + newItem.Count);
        inventoryManagerUI.ChangeItemCount(newItem);
    }
    /// <summary>Обработка удаления айтема из инвентаря.</summary>
    private void InventoryManager_ItemRemovedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent remove with itemname: " + newItem.Name);
        inventoryManagerUI.RemoveItem(newItem);
    }
    /// <summary>Обработка выбора текущего айтема.</summary>
    private void InventoryManager_ItemSelectedEvent(Item newItem)
    {
        Debug.Log("TriggeredEvent selected item with itemname: " + newItem.Name);
        manager.SetCurrentInventoryItem(manager.GetInventoryItemIndex(newItem));
    }
}