using System.Collections.Generic;
using UnityEngine;

/// <summary> Класс коллекции инвентаря.</summary>
public class InventoryCollection
{
    /// <summary>Лист из предметов типа Item .</summary>
    List<Item> _items = new List<Item>(); //MB do custom collection

    /// <summary> Размер коллекции .</summary>
    public int Count { get { return _items.Count;} }

    /// <summary>Метод для добавления в инвентарь .</summary>
    /// <param name="item"> . Айтем для добавления</param>
    public void Add(Item item)
    {
        _items.Add(item);
    }

    /// <summary>Метод для удаления из инвентаря  .</summary>
    /// <param name="item"> . Айтем для удаления</param>
    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    /// <summary>Метод для получения списка айтемов .</summary>
    public List<Item> GetAll()
    {
        return _items;
    }

    /// <summary>Метод для получения айтема по индексу .</summary>
    /// <param name="index"> . Индекс нужного айтема</param>
    public Item GetItem(int index)
    {
        return _items[index];
    }
    /// <summary>Метод для получения айтема по имени .</summary>
    /// <param name="name"> . Имя нужного айтема</param>
    public Item GetItemByName(string name)
    {
        foreach (Item item in _items)
        {
            if (item.Name == name) return item;
        }
        return null;
    }
    /// <summary>Метод для получения индекса айтема  .</summary>
    /// <param name="item"> . Айтем для получения его индекса</param>
    public int GetIndex(Item item)
    {
        return _items.IndexOf(item);
    }
    /// <summary>Метод для проверки наличия айтема по имени  .</summary>
    /// <param name="name"> . Имя нужного айтема</param>
    public bool ContainsName(string name)
    {
        foreach (Item item in _items)
        {
            if (item.Name == name) return true;
        }
        return false;
    }

}
