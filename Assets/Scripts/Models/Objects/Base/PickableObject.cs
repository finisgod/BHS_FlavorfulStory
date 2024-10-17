using Assets.Scripts.Interfaces.InventorySystem;

/// <summary> �����, ����������� ����������� �������.</summary>
public class PickableObject : Object, IPickableObject, IItemProduceable
{
    public PickableObject(string name) : base(name) { }
    /// <summary> ����� ��� ������� ������� � �������������� ��� � Item.</summary>
    public Item PickAndDestroy()
    {
        Destroy(this.gameObject);
        return GetComponentInParent<ItemObjectFactory>().ProduceItem(this);
    }
}