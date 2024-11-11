using UnityEngine;

/// <summary> Менеджер работы с инвентарем игрока.</summary> 
public class PlayerInventoryInputController : MonoBehaviour //Сделать контроллером. Переместить в Scripts/Controllers
{
    /// <summary> Объект UI игрока.</summary>
    [SerializeField] GameObject _inventoryUi;
    /// <summary> Менеджер коллекции инвентаря.</summary>
    [SerializeField] InventoryManager _inventoryManager;
    /// <summary>Инициализация менеджера.</summary>
    private void Start()
    {
        //_inventoryUi.GetComponent<InventoryManagerUI>().ToggleFull();
    }
    private void Update()
    {
        if (!LockActionsManager.IsLock)
        {
            //Tests section
            if (Input.GetKeyDown(KeyCode.H))
            {
                _inventoryManager.AddToInventory(new ShovelItem("Shovel"));
                //_inventoryManager.AddToInventory(new DigItem("Dig"));
                _inventoryManager.AddToInventory(new PourItem("Pour"));
                _inventoryManager.AddToInventory(new AgricultureItem("Potato"));
            }

            //Select current item. Now relized only 1 2 3 keys
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _inventoryUi.GetComponent<InventoryManagerUI>().SetCurrentInventoryItem(0);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _inventoryUi.GetComponent<InventoryManagerUI>().SetCurrentInventoryItem(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _inventoryUi.GetComponent<InventoryManagerUI>().SetCurrentInventoryItem(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                _inventoryUi.GetComponent<InventoryManagerUI>().SetCurrentInventoryItem(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                _inventoryUi.GetComponent<InventoryManagerUI>().SetCurrentInventoryItem(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                _inventoryUi.GetComponent<InventoryManagerUI>().SetCurrentInventoryItem(5);
            }
            //OpenInventory
            if (Input.GetKeyDown((KeyCode)UserKeys.PlayerInventory))
            {
                //_inventoryUi.SetActive(!_inventoryUi.activeSelf);
                _inventoryUi.GetComponent<InventoryManagerUI>().ToggleFull();
            }
        }
    }
}

