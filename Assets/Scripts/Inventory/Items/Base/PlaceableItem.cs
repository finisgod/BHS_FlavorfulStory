using UnityEngine;

/// <summary> Класс размещаемого айтема.</summary>
public class PlaceableItem : Item, IPlaceableItem
{
    public PlaceableItem() : base() { }
    public PlaceableItem(string name) : base(name) { }
    /// <summary> Метод для размещения айтема.(размещается префаб-объект с именем айтема)</summary>
    public virtual Object Place(Vector3 position , Transform parent)
    {
        GameObject spawnedGameObject = Spawner.instance.Spawn("Object/" + this.Name + "Object", position , parent);
        Object placedObject = null;
        spawnedGameObject.TryGetComponent<Object>(out placedObject);
        return placedObject;
    }
}
