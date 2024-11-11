using Unity.VisualScripting;
using UnityEngine;
/// <summary> Класс для спавна объектов.</summary>
public class Spawner : MonoBehaviour //Singleton
{
    public static Spawner instance;
    private void Start()
    {
        instance = this;
    }
    public GameObject Spawn(string name, Vector3 position, Transform parent)
    {
        string prefabName = "Prefabs/GameObjects/" + name;
        Debug.Log(prefabName);
        UnityEngine.Object spawnedObject = Instantiate(Resources.Load(prefabName), position, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f), parent);
        GameObject gameObject = spawnedObject.GameObject();
        return gameObject;
    }
}