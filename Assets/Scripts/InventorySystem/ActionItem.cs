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
        /// <param name="user"> ��������, ������� ���������� ��� ��������.</param>
        public virtual void Use(GameObject user)
        {
            Debug.Log("Using action: " + this);
        }
    }
}