using UnityEngine;

namespace FlavorfulStory.Inventory.UI
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
            for (int i = 0; i < _playerInventory.InventorySize; i++)
            {
                var itemUI = Instantiate(_inventorySlotPrefab, _placeToSpawnSlots);
                itemUI.Setup(_playerInventory, i);
            }
        }
    }
}