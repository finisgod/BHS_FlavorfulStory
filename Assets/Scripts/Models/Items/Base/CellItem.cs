using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary> ������� ����� ������ (��� �������� � UI ���������).</summary>
public class CellItem : MonoBehaviour
{
    Item item = null;
    Cell parentCell = null;
    public Item Item { get { return item; } set { this.item = value; } }

    public void Start()
    {
        parentCell = this.GetComponentInParent<Cell>();
    }
}