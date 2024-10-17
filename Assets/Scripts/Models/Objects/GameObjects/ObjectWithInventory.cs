using UnityEngine;
/// <summary> Класс, описывающий подбираемые объекты.</summary>
public class ObjectWithInventory : UsableObject
{
    public ObjectWithInventory(string name) : base(name) { }
    /// <summary> Метод для подбора объекта и преобразования его в Item.</summary>
    public override void Use()
    {     
        ObjectInventoryManager inventoryManager = this.gameObject.GetComponentInChildren<ObjectInventoryManager>();
        inventoryManager.ToggleInventory();
    }
}