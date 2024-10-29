using FlavorfulStory.Inventory.PickupSystem;
using System.Collections.Generic;
using UnityEngine;

namespace FlavorfulStory.Inventory
{
    /// <summary> ScriptableObject, представляющий любой предмет, 
    /// который может быть помещен в инвентарь.</summary>
    [CreateAssetMenu(menuName = ("FlavorfulStory/Inventory/Item"))]
    public class InventoryItem : ScriptableObject, ISerializationCallbackReceiver
    {
        #region Private Fields
        /// <summary> Автоматически сгенерированный ID для сохранения/загрузки.</summary>
        [Tooltip("Автоматически сгенерированный ID для сохранения/загрузки. Очистите это поле, если вы хотите создать новое.")]
        [SerializeField] private string _itemID;

        /// <summary> Название предмета, которое будет отображаться в UI.</summary>
        [Tooltip("Название предмета, которое будет отображаться в UI.")]
        [SerializeField] private string _displayItemName;

        /// <summary> Описание предмета, которое будет отображаться в UI.</summary>
        [Tooltip("Описание предмета, которое будет отображаться в UI.")]
        [SerializeField][TextArea] private string _description;

        /// <summary> Иконка в UI для обозначения этого предмета в инвентаре.</summary>
        [Tooltip("Иконка в UI для обозначения этого предмета в инвентаре.")]
        [SerializeField] private Sprite _icon;

        /// <summary> Префаб, который должен появиться при выпадении этого предмета.</summary>
        [Tooltip("Префаб, который должен появиться при выпадении этого предмета.")]
        [SerializeField] private Pickup _pickup;

        /// <summary> Можно ли поместить несколько предметов одного типа в один слот инвентаря?</summary>
        [Tooltip("Можно ли поместить несколько предметов одного типа в один слот инвентаря?")]
        [SerializeField] private bool _isStackable;

        //[SerializeField] private int _count;

        /// <summary> База данных всех предметов игры.</summary>
        private static Dictionary<string, InventoryItem> _itemDatabase;
        #endregion

        #region Properties
        /// <summary> Автоматически сгенерированный UUID для сохранения/загрузки.</summary>
        public string ItemID => _itemID;

        /// <summary> Название предмета, которое будет отображаться в UI.</summary>
        public string DisplayName => _displayItemName;

        /// <summary> Описание предмета, которое будет отображаться в UI.</summary>
        public string Description => _description;

        /// <summary> Иконка в UI для обозначения этого предмета в инвентаре.</summary>
        public Sprite Icon => _icon;

        /// <summary> Возможно ли, что несколько предметов одного типа могут быть помещены в одну ячейку инвентаря?</summary>
        public bool IsStackable => _isStackable;
        #endregion

        /// <summary> Заспавнить предмет Pickup на сцене.</summary>
        /// <param name="spawnPosition"> Позиция на сцене, где нужно заспавнить.</param>
        /// <returns> Возвращает ссылку на заспавненный предмет Pickup.</returns>
        public Pickup SpawnPickup(Vector3 spawnPosition)
        {
            var pickup = Instantiate(_pickup);
            pickup.transform.position = spawnPosition;
            pickup.Setup(this);
            return pickup;
        }

        /// <summary> Получить экземпляр предмета инвентаря по его ID.</summary>
        /// <param name="itemID"> ID предмета инвентаря.</param>
        /// <returns> Экземпляр Inventoryitem, соответствующий ID.</returns>
        public static InventoryItem GetItemFromID(string itemID)
        {
            if (_itemDatabase == null) CreateItemDatabase();

            if (itemID == null || !_itemDatabase.ContainsKey(itemID)) return null;
            return _itemDatabase[itemID];
        }

        /// <summary> Создать базу данных предметов.</summary>
        private static void CreateItemDatabase()
        {
            _itemDatabase = new();

            // Загрузка все ресурсов с типом InventoryItem по всему проекту.
            var items = Resources.LoadAll<InventoryItem>("");
            foreach (var item in items)
            {
                if (_itemDatabase.ContainsKey(item._itemID))
                {
                    Debug.LogError("Присутствует дубликат ID InventoryItem для объектов: " +
                        $"{_itemDatabase[item._itemID]} и {item}. Замените ID у данного объекта.");
                    continue;
                }
                _itemDatabase[item._itemID] = item;
            } 
        }

        #region ISerializationCallbackReceiver
        /// <summary> Генерация и сохранение нового GUID, если он пустой.</summary>
        public void OnBeforeSerialize()
        {
            if (string.IsNullOrWhiteSpace(_itemID))
            {
                _itemID = System.Guid.NewGuid().ToString();
            }
        }

        /// <summary> Требуется для ISerializationCallbackReceiver, 
        /// но нам не нужно ничего с ним делать.</summary>
        public void OnAfterDeserialize() { }
        #endregion
    }
}