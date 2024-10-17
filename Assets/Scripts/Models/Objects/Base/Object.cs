using UnityEngine;

/// <summary> Базовый класс объекта.</summary>
public class Object : MonoBehaviour
{
    /// <summary> Имя объекта. Должно совпадать с именем соответствующего Item (если pickable).</summary>
    [SerializeField] string _name;
    public Object(string name)
    {
        _name = name;
    }
    public string ObjectName { get { return _name; } }
}


