using UnityEngine;
using UnityEngine.UI;

namespace FlavorfulStory.Inventory.UI
{
    /// <summary> Иконка предмета - отображает иконку предмета и его текущее количество в слоте инвентаря.</summary>
    [RequireComponent(typeof(Image))]
    public class InventoryItemIcon : MonoBehaviour
    {
        /// <summary> Картинка иконки.</summary>
        private Image _iconImage;

        /// <summary> Инициализация объекта.</summary>
        private void Awake()
        {
            _iconImage = GetComponent<Image>();
        }

        /// <summary> Установить предмет инвентаря.</summary>
        /// <param name="item"> Предмет инвентаря.</param>
        public void SetItem(InventoryItem item)
        {
            _iconImage.enabled = item != null;
            if (item != null)
            {
                _iconImage.sprite = item.Icon;
            }
        }
    }
}