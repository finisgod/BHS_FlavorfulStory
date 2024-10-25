using FlavorfulStory.UI.Dragging;
using UnityEngine;

namespace FlavorfulStory.UI.Inventory
{
    public class InventorySlotUI : MonoBehaviour, IDragContainer<Sprite>
    {
        [SerializeField] private InventoryItemIcon _icon;

        public int GetMaxAcceptableItemsNumber(Sprite item)
        {
            if (GetItem() == null) return int.MaxValue;
            return 0;
        }

        public void AddItems(Sprite item, int number)
        {
            _icon.SetItem(item);
        }

        public Sprite GetItem()
        {
            return _icon.GetItem();
        }

        public int GetNumber()
        {
            return 1;
        }

        public void RemoveItems(int number)
        {
            _icon.SetItem(null);
        }
    }
}