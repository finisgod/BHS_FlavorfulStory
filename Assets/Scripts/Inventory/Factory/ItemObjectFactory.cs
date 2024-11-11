using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary> Класс - "фабрика" для создания айтема из объекта.</summary>
public class ItemObjectFactory : MonoBehaviour
{
    /// <summary> Словарь название - тип для создания нужного айтема.</summary>
    static Dictionary<string, Type> _factoryTypeDict = new Dictionary<string, Type>();
    private void Start() //ToDo: вынести в инициализационный класс - стартер
    {
        if (_factoryTypeDict.Count == 0)
        {
            _factoryTypeDict.Add("SwordFish", typeof(PlaceableItem));
            _factoryTypeDict.Add("Beet", typeof(AgricultureItem));
            _factoryTypeDict.Add("Potato", typeof(AgricultureItem));
        }
    }
    /// <summary> Создание нужного типа айтема исходя из его интерфейсов.</summary>
    public Item ProduceItem(IItemProduceable obj)
    {
        Object unboxedObject = (Object)obj;
        Type objectType = _factoryTypeDict[unboxedObject.ObjectName];
        //Item Item = (Item)FormatterServices.GetUninitializedObject(objectType);
        Item Item = (Item)Activator.CreateInstance(objectType); // Заменить на более производительный вариант
        //this.gameObject.AddComponent(objectType);
        Item.Name = unboxedObject.ObjectName;
        return Item;
    }
}