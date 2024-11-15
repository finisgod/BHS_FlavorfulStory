using FlavorfulStory.Saving;
using System;
using UnityEngine;

namespace FlavorfulStory.InventorySystem
{
    /// <summary> Класс обеспечивает хранение инвентаря игрока. Доступно настраиваемое количество слотов.
    /// Этот компонент должен быть размещен на игровом объекте с тегом "Игрок".</summary>
    public class Inventory : MonoBehaviour, ISaveable
    {
        /// <summary> Количество слотов в инвентаре.</summary>
        [Tooltip("Количество слотов в инвентаре.")]
        [SerializeField] private int _inventorySize = 16;

        /// <summary> Предметы инвентаря.</summary>
        private InventoryItem[] _slots;

        /// <summary> Количество слотов в инвентаре.</summary>
        public int InventorySize => _inventorySize;

        /// <summary> Событие, которое срабатывает, когда предметы в инвентаре добавляются / удаляются.</summary>
        public event Action InventoryUpdated;

        /// <summary> Инициализация полей.</summary>
        private void Awake()
        {
            _slots = new InventoryItem[_inventorySize];
        }

        /// <summary> Получить инвентарь игрока.</summary>
        public static Inventory GetPlayerInventory() =>
            GameObject.FindWithTag("Player").GetComponent<Inventory>();

        /// <summary> Может ли этот предмет поместиться где-нибудь в инвентаре?</summary>
        public bool HasSpaceFor(InventoryItem item) => FindSlot(item) >= 0;

        /// <summary> Найти слот, в который можно поместить данный предмет.</summary>
        /// <returns> Возвращает индекс слота предмета. Если предмет не найден, возвращает -1.</returns>
        private int FindSlot(InventoryItem item)
        {
            return FindEmptySlot();
        }

        /// <summary> Найти индекс свободного слота в инвентаре.</summary>
        /// <returns> Возвращает индекс свободного слота в инвентаре.
        /// Если все слоты заполнены, то возвращает -1.</returns>
        private int FindEmptySlot()
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                if (_slots[i] == null) return i;
            }
            return -1;
        }

        /// <summary> Есть ли экземпляр этого предмета в инвентаре?</summary>
        /// <param name="item"> Предмет.</param>
        /// <returns> Возвращает True - если предмет есть в инвентаре, False - в противном случае.</returns>
        public bool HasItem(InventoryItem item)
        {
            foreach (var slot in _slots)
            {
                if (ReferenceEquals(slot, item)) return true;
            }
            return false;
        }

        /// <summary> Получить предмет инвентаря в заданном слоте.</summary>
        /// <param name="slotIndex"> Индекс слота, из которого нужно получить предмет.</param>
        /// <returns> Возвращает предмет инвентаря в заданном слоте.</returns>
        public InventoryItem GetItemInSlot(int slotIndex) => _slots[slotIndex];

        /// <summary> Извлечь предмет из указанного слота.</summary>
        /// <param name="slotIndex"> Индекс слота в инвентаре.</param>
        public void RemoveFromSlot(int slotIndex)
        {
            _slots[slotIndex] = null;
            InventoryUpdated?.Invoke();
        }

        /// <summary> Попробовать добавить предмет в указанный слот.</summary>
        /// <remarks> Если такой стак уже существует, он будет добавлен в существующий стак.
        /// В противном случае он будет добавлен в первый пустой слот.</remarks>
        /// <param name="slotIndex"> Индекс слота, в который нужно попытаться добавить предмет.</param>
        /// <param name="item"> Предмет, который нужно добавить.</param>
        /// <returns> Возвращает True, если предмет был добавлен в любое место инвентаря.</returns>
        public bool TryAddItemToSlot(int slotIndex, InventoryItem item)
        {
            if (_slots[slotIndex] != null) return TryAddToFirstEmptySlot(item);

            _slots[slotIndex] = item;
            InventoryUpdated?.Invoke();
            return true;
        }

        /// <summary> Попробовать добавить предмет в первый доступный слот.</summary>
        /// <param name="item"> Предмет, который нужно добавить.</param>
        /// <returns> Возвращает True, если предмет можно добавить, False - в противном случае.</returns>
        public bool TryAddToFirstEmptySlot(InventoryItem item)
        {
            int slotIndex = FindSlot(item);

            if (slotIndex < 0) return false;

            _slots[slotIndex] = item;
            InventoryUpdated?.Invoke();
            return true;
        }

        #region Saving
        /// <summary> Фиксация состояния объекта при сохранении.</summary>
        /// <returns> Возвращает объект, в котором фиксируется состояние.</returns>
        public object CaptureState()
        {
            var slotStrings = new string[_inventorySize];
            for (int i = 0; i < _inventorySize; i++)
            {
                if (_slots[i] != null)
                {
                    slotStrings[i] = _slots[i].ItemID;
                }
            }
            return slotStrings;
        }

        /// <summary> Восстановление состояния объекта при загрузке.</summary>
        /// <param name="state"> Объект состояния, который необходимо восстановить.</param>
        public void RestoreState(object state)
        {
            var slotStrings = state as string[];
            for (int i = 0; i < _inventorySize; i++)
            {
                _slots[i] = InventoryItem.GetItemFromID(slotStrings[i]);
            }
            InventoryUpdated?.Invoke();
        }
        #endregion
    }
}