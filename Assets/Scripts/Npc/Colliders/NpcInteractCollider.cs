using UnityEngine;

namespace NPC
{
    /// <summary> ����� ����������� ���������-������� ��� �������������� � ������������� NPC.</summary>
    public class NpcInteractCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
    {
        /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
        /// <param name="other"> ��������� ��������� �������.</param>
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Npc npc = this.GetComponent<Npc>();
                if (npc != null)
                {
                    if (npc is INpcIteractive)
                    {
                        (npc as INpcIteractive).Interact();
                    }
                }
            }
        }
    }
}