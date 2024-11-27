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

        public ToolbarSlotUI SelectedItem => _slots[_selectedItemIndex];

        /// <summary> Инициализация полей.</summary>
        private void Awake()
        {
            _slots = GetComponentsInChildren<ToolbarSlotUI>();
            _slots[_selectedItemIndex].Select();

            Inventory.GetPlayerInventory().InventoryUpdated += RedrawToolbar;
        }

        /// <summary> При старте перерисовываем инвентарь.</summary>
        private void Start()
        {
            RedrawToolbar();
        }

        /// <summary> Перерисовать инвентарь.</summary>
        private void RedrawToolbar()
        {
            foreach (var slot in _slots)
            {
                slot.Redraw();
            }
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