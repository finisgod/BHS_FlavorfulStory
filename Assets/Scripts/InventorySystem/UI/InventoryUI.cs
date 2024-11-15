using UnityEngine;

namespace FlavorfulStory.InventorySystem.UI
{
    /// <summary> ��������� � UI - ��������� ��������� ���� ��������� ��������� � UI.</summary>
    public class InventoryUI : MonoBehaviour
    {
        /// <summary> ������ ����� ���������.</summary>
        [SerializeField] private InventorySlotUI _inventorySlotPrefab;

        /// <summary> ����� ��� ������ ������ ���������.</summary>
        [SerializeField] private Transform _placeToSpawnSlots;

        /// <summary> ��������� ������.</summary>
        private Inventory _playerInventory;

        /// <summary> ������������� �������.</summary>
        private void Awake()
        {
            _playerInventory = Inventory.GetPlayerInventory();
            _playerInventory.InventoryUpdated += RedrawInventory;
        }

        /// <summary> ��� ������ �������������� ���������.</summary>
        private void Start()
        {
            RedrawInventory();
        }

        /// <summary> ������������ ���������.</summary>
        private void RedrawInventory()
        {
            DestroyAllPrefabs();
            SpawnInventorySlots();
        }

        /// <summary> ���������� ��� �������.</summary>
        private void DestroyAllPrefabs()
        {
            foreach (Transform child in _placeToSpawnSlots)
            {
                Destroy(child.gameObject);
            }
        }

        /// <summary> �������� ������ ���������.</summary>
        private void SpawnInventorySlots()
        {
            for (int index = 0; index < _playerInventory.InventorySize; index++)
            {
                var itemUI = Instantiate(_inventorySlotPrefab, _placeToSpawnSlots);
                itemUI.Setup(_playerInventory, index);
            }
        }
    }
}