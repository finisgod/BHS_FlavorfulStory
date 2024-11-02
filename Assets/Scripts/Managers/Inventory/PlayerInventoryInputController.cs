using Assets.Scripts.Items.Instruments;
using UnityEngine;

/// <summary> Менеджер работы с инвентарем игрока.</summary> 
public class PlayerInventoryInputController : MonoBehaviour //Сделать контроллером. Переместить в Scripts/Controllers
{
    /// <summary> Объект UI игрока.</summary>
    [SerializeField] GameObject _inventoryUi;
    /// <summary> Менеджер коллекции инвентаря.</summary>
    [SerializeField] InventoryManager _inventoryManager;
    /// <summary> Текущий айтем в руке игрока.</summary>
    Item _selectedItem;
    [SerializeField] GameObject _player;
    /// <summary>Инициализация менеджера.</summary>
    private void Start()
    {
        _inventoryUi.GetComponent<InventoryManagerUI>().ToggleFull();
    }
    private void Update()
    {
        //Tests section
        if (Input.GetKeyDown(KeyCode.H))
        {
            _inventoryManager.AddToInventory(new ShovelItem());
            _inventoryManager.AddToInventory(new WaterCanItem());
            _inventoryManager.AddToInventory(new AgricultureItem("Beet"));
        }
        //Move To Another Manager
        if (Input.GetKeyDown(KeyCode.G))
        {
            Item item = _inventoryUi.GetComponent<InventoryManagerUI>().GetCurrentInventoryItem();
            if (item != null)
            {
                _inventoryManager.RemoveFromInventory(item);
                Spawner.instance.SpawnToWorld("Drop/" + item.Name + "Drop", _player.transform.position);
            }
        }
        //Tests section end

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
        //OpenInventory
        if (Input.GetKeyDown((KeyCode)UserKeys.PlayerInventory))
        {
            //_inventoryUi.SetActive(!_inventoryUi.activeSelf);
            _inventoryUi.GetComponent<InventoryManagerUI>().ToggleFull();
        }
    }
}

