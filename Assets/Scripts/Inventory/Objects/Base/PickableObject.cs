/// <summary> Класс, описывающий подбираемые объекты.</summary>
public class PickableObject : Object, IPickableObject, IItemProduceable
{
    public PickableObject(string name) : base(name) { }
    /// <summary> Метод для подбора объекта и преобразования его в Item.</summary>
    public Item PickAndDestroy()
    {
        Destroy(this.gameObject);
        return GetComponentInParent<ItemObjectFactory>().ProduceItem(this);
    }
}