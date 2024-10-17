using UnityEngine;
/// <summary> �����, ����������� ����������� �������.</summary>
public class ObjectWithInventory : UsableObject
{
    public ObjectWithInventory(string name) : base(name) { }
    /// <summary> ����� ��� ������� ������� � �������������� ��� � Item.</summary>
    public override void Use()
    {     
        ObjectInventoryManager inventoryManager = this.gameObject.GetComponentInChildren<ObjectInventoryManager>();
        inventoryManager.ToggleInventory();
    }
}