using UnityEngine;

namespace FlavorfulStory.Inventory.UI
{
    /// <summary> Инвентарь в UI - управляет созданием всех предметов инвентаря в UI.</summary>
    public class InventoryUI : MonoBehaviour
    {
        /// <summary> Префаб слота инвентаря.</summary>
        [SerializeField] private InventorySlotUI _inventorySlotPrefab;

        /// <summary> Место для спавна слотов инвентаря.</summary>
        [SerializeField] private Transform _placeToSpawnSlots;

        /// <summary> Инвентарь игрока.</summary>
        private Inventory _playerInventory;

        /// <summary> Инициализация объекта.</summary>
        private void Awake()
        {
            _playerInventory = Inventory.GetPlayerInventory();
            _playerInventory.InventoryUpdated += RedrawInventory;
        }

        /// <summary> При старте перерисовываем инвентарь.</summary>
        private void Start()
        {
            RedrawInventory();
        }

        /// <summary> Перерисовать инвентарь.</summary>
        private void RedrawInventory()
        {
            DestroyAllPrefabs();
            SpawnInventorySlots();
        }

        /// <summary> Уничтожить все префабы.</summary>
        private void DestroyAllPrefabs()
        {
            foreach (Transform child in _placeToSpawnSlots)
            {
                Destroy(child.gameObject);
            }
        }

        /// <summary> Создание слотов инвентаря.</summary>
        private void SpawnInventorySlots()
        {
            for (int i = 0; i < _playerInventory.InventorySize; i++)
            {
                var itemUI = Instantiate(_inventorySlotPrefab, _placeToSpawnSlots);
                itemUI.Setup(_playerInventory, i);
            }
        }
    }
}