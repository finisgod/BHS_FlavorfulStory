using Assets.Scripts.Items.Instruments;
using UnityEngine;

/// <summary> ������� ����� ��� ������������ ������� (�����).</summary>
public class Drop : PickableObject
{
    public Drop(string name) : base(name) { }
    /// <summary> ����� ��� ������� ������� � �������������� ��� � Item.</summary>
    public new Item PickAndDestroy()
    {
        Destroy(this.gameObject);
        return GetComponentInParent<ItemObjectFactory>().ProduceItem(this);
    }

    //RotationAnimation
    public void Update()
    {
        this.gameObject.transform.Rotate(0, 10 * Time.deltaTime, 0);
    }
}