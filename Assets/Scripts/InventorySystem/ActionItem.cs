using UnityEngine;

namespace FlavorfulStory.InventorySystem
{
    /// <summary> ������� ���������, ������� ����� ������������.</summary>
    /// <remarks> ���� ����� ������� ������������ � �������� ��������. ��������� ������ ������������� ����� `Use`.</remarks>
    [CreateAssetMenu(menuName = ("FlavorfulStory/Inventory/Action Item"))]
    public class ActionItem : InventoryItem
    {
        /// <summary> ����������� �� ������� ��� �������������?</summary>
        [field: Tooltip("����������� �� ������� ��� �������������?")]
        [field: SerializeField] public bool IsConsumable { get; private set; }

        /// <summary> ������������� ��������.</summary>
        /// <remarks> �������������� ��� ����������� ����������������.</remarks>
        public virtual void Use()
        {
            
        }
    }
}