using FlavorfulStory.Saving;
using System.Collections.Generic;
using UnityEngine;

namespace FlavorfulStory.InventorySystem.EquipmentSystem
{
    /// <summary> ��������� ���������, �������� ������� �����. 
    /// �������� �������� � ����������� ������ ����������.</summary>
    /// <remarks>  ���� ��������� ������ ���� �������� �� ������� "Player". </remarks>
    public class Equipment : MonoBehaviour, ISaveable
    {
        /// <summary> ������������� ��������.</summary>
        private Dictionary<EquipmentType, EquipableItem> _equippedItems = new();

        /// <summary> �����������, ����� �������� � ������ ����������� / ���������.</summary>
        public event System.Action EquipmentUpdated;

        /// <summary> �������� ������� ���������� �� ����.</summary>
        /// <param name="equipLocation"> ��� ����������.</param>
        /// <returns> ���������� ������� ���������� �� ����.</returns>
        public EquipableItem GetEquipmentFromType(EquipmentType equipLocation) =>
            _equippedItems.TryGetValue(equipLocation, out var item) ? item : null;

        /// <summary> �������� ������� � ��������� ����� ����������.</summary>
        public void AddItem(EquipmentType slot, EquipableItem item)
        {
            _equippedItems[slot] = item;
            EquipmentUpdated?.Invoke();
        }

        /// <summary> ������� ������� ���������� �� ����.</summary>
        public void RemoveItem(EquipmentType slot)
        {
            _equippedItems.Remove(slot);
            EquipmentUpdated?.Invoke();
        }

        /// <summary> �������� ������ ���� ������������� ���������.</summary>
        public IEnumerable<EquipmentType> GetEquippedItems() => _equippedItems.Keys;

        #region Saving
        /// <summary> �������� ��������� ������� ��� ����������.</summary>
        /// <returns> ���������� ������, � ������� ����������� ���������.</returns>
        public object CaptureState()
        {
            var equippedItemsForSerialization = new Dictionary<EquipmentType, string>();
            foreach (var pair in _equippedItems)
            {
                equippedItemsForSerialization[pair.Key] = pair.Value.ItemID;
            }
            return equippedItemsForSerialization;
        }

        /// <summary> �������������� ��������� ������� ��� ��������.</summary>
        /// <param name="state"> ������ ���������, ������� ���������� ������������.</param>
        public void RestoreState(object state)
        {
            _equippedItems = new Dictionary<EquipmentType, EquipableItem>();

            var equippedItemsForSerialization = state as Dictionary<EquipmentType, string>;
            foreach (var pair in equippedItemsForSerialization)
            {
                var item = InventoryItem.GetItemFromID(pair.Value) as EquipableItem;
                if (item) _equippedItems[pair.Key] = item;
            }
        }
        #endregion
    }
}