using UnityEngine;

namespace FlavorfulStory.InventorySystem.UI
{
    /// <summary> ������ ������������.</summary>
    public class Toolbar : MonoBehaviour
    {
        /// <summary> ������ ������ ������ ������������.</summary>
        private ToolbarSlotUI[] _slots;

        /// <summary> ������ ���������� ��������.</summary>
        private int _selectedItemIndex = 0;

        /// <summary> ������������� �����.</summary>
        private void Awake()
        {
            _slots = GetComponentsInChildren<ToolbarSlotUI>();
            _slots[_selectedItemIndex].Select();
        }

        public ToolbarSlotUI GetSelectedItem()
        {
            return _slots[_selectedItemIndex];
        }

        /// <summary> ������� ������� �� ������.</summary>
        /// <param name="index"> ������ ��������, ������� ����� �������.</param>
        public void SelectItem(int index)
        {
            _slots[_selectedItemIndex].ResetSelection();

            _selectedItemIndex = index;
            _slots[_selectedItemIndex].Select();
        }
    }
}