using UnityEngine;

public class AgricultureItem : Item, IAgricultureItem
{
    public AgricultureItem() : base() { }
    public AgricultureItem(string name) : base(name) { }
    public Object Plant(Vector3 position, Transform parent)
    {
        GameObject spawnedGameObject = Spawner.instance.Spawn("Object/" + this.Name + "Object", position, parent);
        Object placedObject = null;
        spawnedGameObject.TryGetComponent<Object>(out placedObject);
        return placedObject;
    }
}