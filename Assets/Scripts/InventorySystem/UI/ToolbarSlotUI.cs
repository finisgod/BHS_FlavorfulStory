using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace FlavorfulStory.InventorySystem.UI
{
    [RequireComponent(typeof(Image))]
    public class ToolbarSlotUI : MonoBehaviour, IItemHolder,
        IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary> Инонка слота инвентаря.</summary>
        [SerializeField] private InventoryItemIcon _icon;

        /// <summary> Текст клавиши.</summary>
        [SerializeField] private TMP_Text _keyText;

        /// <summary> Индекс слота в HUD.</summary>
        private int _index;

        private Toolbar _toolbar;
        private bool _isSelected;
        private Image _image;

        /// <summary> Инвентарь.</summary>
        private Inventory _inventory;

        private void Awake()
        {
            _inventory = Inventory.GetPlayerInventory();

            _index = transform.GetSiblingIndex();
            _keyText.text = $"{_index + 1}";
            _image = GetComponent<Image>();
            _toolbar = transform.parent.GetComponent<Toolbar>();
        }

        public void Redraw()
        {
            _icon.SetItem(_inventory.GetItemInSlot(_index), _inventory.GetNumberInSlot(_index));
        }

        /// <summary> Получить предмет, который в данный момент находится в этом источнике.</summary>
        /// <returns> Возвращает предмет, который в данный момент находится в этом источнике.</returns>
        public InventoryItem GetItem() => _inventory.GetItemInSlot(_index);

        public void Select()
        {
            _isSelected = true;
            FadeToColor(Color.gray);
        }

        public void ResetSelection()
        {
            _isSelected = false;
            FadeToColor(Color.white);
        }
        private void FadeToColor(Color color)
        {
            const float FadeDuration = 0.2f;
            _image.CrossFadeColor(color, FadeDuration, true, true);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            _toolbar.SelectItem(_index);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            FadeToColor(Color.gray);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!_isSelected) FadeToColor(Color.white);
        }
    }
}