using UnityEngine;
/// <summary> �����, ����������� ������ ������� �������.</summary>
///<remarks> �������� �� �����, ������� ����� ���������. ��� ���������� ����� � ������� ��� ������ ������������� � ������.</remarks>
public class DropTakeCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary> �������� � ������� ����� ������������� � ���������.</summary>
    private int speed = 70;
    /// <summary> ����������� ���������� ��� ������������ ��������.</summary>
    private double distance = 0.10;

    /// <summary> ������� ��� ���������� � ����������, ������������� � �������. ����������� ������������ ������</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 targetDirection = other.transform.position - transform.position;
            this.gameObject.transform.position += targetDirection / speed;
            if ((gameObject.transform.position - other.transform.position).magnitude < distance)
            {
                InventoryManager manager = other.GetComponentInChildren<InventoryManager>();
                IPickableObject obj = this.gameObject.GetComponent<IPickableObject>();
                Item item = obj.PickAndDestroy();
                manager.AddToInventory(item);
            }
        }
    }
}