using UnityEngine;

namespace FlavorfulStory.InventorySystem.UI
{
    /// <summary> Панель инструментов.</summary>
    public class Toolbar : MonoBehaviour
    {
        /// <summary> Массив слотов панели инструментов.</summary>
        private ToolbarSlotUI[] _slots;

        /// <summary> Индекс выбранного предмета.</summary>
        private int _selectedItemIndex = 0;

        /// <summary> Инициализация полей.</summary>
        private void Awake()
        {
            _slots = GetComponentsInChildren<ToolbarSlotUI>();
            _slots[_selectedItemIndex].Select();
        }

        public ToolbarSlotUI GetSelectedItem()
        {
            return _slots[_selectedItemIndex];
        }

        /// <summary> Выбрать предмет на панели.</summary>
        /// <param name="index"> Индекс предмета, который нужно выбрать.</param>
        public void SelectItem(int index)
        {
            _slots[_selectedItemIndex].ResetSelection();

            _selectedItemIndex = index;
            _slots[_selectedItemIndex].Select();
        }
    }
}