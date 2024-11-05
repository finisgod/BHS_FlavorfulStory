using Assets.Scripts.Models.Objects.GameObjects;
using UnityEngine;
/// <summary> �����, ����������� ������ ������� �������� ��� ���������� ����� � IPickableObject.</summary>
///<remarks> �������� �� ������, ������� ����� ��������� ��� ������� �� ������������ �������.</remarks>
public class PickObjectCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    //
    private Object objectToPick = null;
    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InventoryManager manager = other.GetComponentInChildren<InventoryManager>(); //��������� ��������� ������. ������ ������������ � ���������� ���� �� null
            if (objectToPick == null)
            {
                objectToPick = this.gameObject.GetComponent<Object>();
            }          
            if (Input.GetKeyDown(KeyCode.E)) //ToDo: ������� �� enum.
            {
                if (objectToPick is IPickableObject)
                {
                    Item item = ((IPickableObject)objectToPick).PickAndDestroy();
                    manager.AddToInventory(item);
                }
            }
        }
    }
    /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerExit(Collider other)
    {
        objectToPick = null;
    }
}
