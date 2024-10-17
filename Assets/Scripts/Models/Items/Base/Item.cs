using UnityEngine;

/// <summary> ������� ����� ������ (��� �������� � ���������).</summary>
public class Item
{
    public Item() { Count = 0; Name = "BaseItem"; }
    public Item(string name) { Count = 0; Name = name; }
    public int Count { get; set; }
    public string Name { get; set; }
}
