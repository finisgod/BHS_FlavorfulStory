using UnityEngine;

/// <summary> ����� ���������� ������� ��� ������ Cell.</summary>
public class CellCounter : MonoBehaviour
{
    int _count = 0;
    public int Count { get { return _count; } set { this._count = value; } }
}