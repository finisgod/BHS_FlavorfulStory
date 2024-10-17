using Assets.Scripts.Interfaces.InventorySystem;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary> ����� - "�������" ��� �������� ������ �� �������.</summary>
public class ItemObjectFactory : MonoBehaviour
{
    /// <summary> ������� �������� - ��� ��� �������� ������� ������.</summary>
    static Dictionary<string, Type> _factoryTypeDict = new Dictionary<string, Type>();
    private void Start() //ToDo: ������� � ����������������� ����� - �������
    {
        if (_factoryTypeDict.Count == 0)
        {
            _factoryTypeDict.Add("SwordFish", typeof(PlaceableItem));
            _factoryTypeDict.Add("Beet", typeof(AgricultureItem));
        }
    }
    /// <summary> �������� ������� ���� ������ ������ �� ��� �����������.</summary>
    public Item ProduceItem(IItemProduceable obj)
    {
        Object unboxedObject = (Object)obj;
        Type objectType = _factoryTypeDict[unboxedObject.ObjectName];
        //Item Item = (Item)FormatterServices.GetUninitializedObject(objectType);
        Item Item = (Item)Activator.CreateInstance(objectType); // �������� �� ����� ���������������� �������
        //this.gameObject.AddComponent(objectType);
        Item.Name = unboxedObject.ObjectName;
        return Item;
    }
}