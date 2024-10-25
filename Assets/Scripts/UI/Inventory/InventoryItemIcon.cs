using UnityEngine;
using UnityEngine.UI;

namespace FlavorfulStory.UI.Inventory
{
    /// <summary> Иконка размещенная в слоте, представляющая предмет инвентаря. 
    /// Позволяет в слоте отображать иконку и количество.</summary>
    [RequireComponent(typeof(Image))]
    public class InventoryItemIcon : MonoBehaviour
    {
        private Image _iconImage;

        private void Awake()
        {
            _iconImage = GetComponent<Image>();
        }

        public void SetItem(Sprite item)
        {
            if (item == null)
            {
                _iconImage.enabled = false;
            }
            else
            {
                _iconImage.enabled = true;
                _iconImage.sprite = item;
            }
        }
         
        public Sprite GetItem()
        {
            if (!_iconImage.enabled)
            {
                return null;
            }
            return _iconImage.sprite;
        }
    }
}