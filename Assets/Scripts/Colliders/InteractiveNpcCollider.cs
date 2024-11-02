using UnityEngine;
/// <summary> ����� ����������� ���������-������� ��� �������������� � ������������� NPC.</summary>
public class InteractiveNpcCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Npc npc = this.GetComponent<Npc>(); //ToDo: �������� �� null
            if (npc is IIteractiveNpc)
            {
                (npc as IIteractiveNpc).Interact();
            }
        }
    }
}