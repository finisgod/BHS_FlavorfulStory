using UnityEngine;

namespace FlavorfulStory.InventorySystem.EquipmentSystem
{
    /// <summary> ������� ���������, ������� ����� ����� �������������. ������ ����� ���� ��� ����������.</summary>
    [CreateAssetMenu(menuName = ("FlavorfulStory/Inventory/Equipable Item"))]
    public class EquipableItem : InventoryItem
    {
        /// <summary> ���� ����������� ������ ���� �������.</summary>
        [field: Tooltip("���� ��� ����������� ������ ���� �������.")]
        [field: SerializeField] public EquipmentType AllowedEquipmentLocation { get; private set; }
    }
}