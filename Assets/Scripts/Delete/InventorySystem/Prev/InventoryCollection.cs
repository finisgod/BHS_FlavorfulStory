using System.Collections.Generic;
using UnityEngine;

/// <summary> ����� ��������� ���������.</summary>
public class InventoryCollection
{
    /// <summary>���� �� ��������� ���� Item .</summary>
    List<Item> _items = new List<Item>(); //MB do custom collection

    /// <summary> ������ ��������� .</summary>
    public int Count { get { return _items.Count;} }

    /// <summary>����� ��� ���������� � ��������� .</summary>
    /// <param name="item"> . ����� ��� ����������</param>
    public void Add(Item item)
    {
        _items.Add(item);
    }

    /// <summary>����� ��� �������� �� ���������  .</summary>
    /// <param name="item"> . ����� ��� ��������</param>
    public void Remove(Item item)
    {
        _items.Remove(item);
    }

    /// <summary>����� ��� ��������� ������ ������� .</summary>
    public List<Item> GetAll()
    {
        return _items;
    }

    /// <summary>����� ��� ��������� ������ �� ������� .</summary>
    /// <param name="index"> . ������ ������� ������</param>
    public Item GetItem(int index)
    {
        return _items[index];
    }
    /// <summary>����� ��� ��������� ������ �� ����� .</summary>
    /// <param name="name"> . ��� ������� ������</param>
    public Item GetItemByName(string name)
    {
        foreach (Item item in _items)
        {
            if (item.Name == name) return item;
        }
        return null;
    }
    /// <summary>����� ��� ��������� ������� ������  .</summary>
    /// <param name="item"> . ����� ��� ��������� ��� �������</param>
    public int GetIndex(Item item)
    {
        return _items.IndexOf(item);
    }
    /// <summary>����� ��� �������� ������� ������ �� �����  .</summary>
    /// <param name="name"> . ��� ������� ������</param>
    public bool ContainsName(string name)
    {
        foreach (Item item in _items)
        {
            if (item.Name == name) return true;
        }
        return false;
    }

}
