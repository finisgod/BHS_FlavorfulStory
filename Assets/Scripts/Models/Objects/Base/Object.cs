using UnityEngine;

/// <summary> ������� ����� �������.</summary>
public class Object : MonoBehaviour
{
    /// <summary> ��� �������. ������ ��������� � ������ ���������������� Item (���� pickable).</summary>
    [SerializeField] string _name;
    public Object(string name)
    {
        _name = name;
    }
    public string ObjectName { get { return _name; } }
}


