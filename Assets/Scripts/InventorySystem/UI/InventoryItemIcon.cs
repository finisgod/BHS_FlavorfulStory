using UnityEngine;
using UnityEngine.UI;

namespace FlavorfulStory.InventorySystem.UI
{
    /// <summary> Иконка предмета - отображает иконку предмета и его текущее количество в слоте инвентаря.</summary>
    [RequireComponent(typeof(Image))]
    public class InventoryItemIcon : MonoBehaviour
    {
        /// <summary> Установить предмет инвентаря.</summary>
        /// <param name="item"> Предмет инвентаря.</param>
        public void SetItem(InventoryItem item)
        {
            var iconImage = GetComponent<Image>();
            iconImage.enabled = item != null;
            if (item != null)
            {
                iconImage.sprite = item.Icon;
            }
        }
    }
}