using UnityEngine;
namespace NPC
{
    /// <summary> �����, ����������� ������ �������� NPC � �������� ��������� ��� �������.</summary>
    public class NpcGreetCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
    {
        /// <summary>RigidBody ������������� NPC .</summary>
        [SerializeField] Rigidbody rb;

        /// <summary>�������� �������� NPC .</summary>
        [SerializeField] float rotationSpeed;

        /// <summary>������ NPC.</summary>
        [SerializeField] NpcController npc;

        /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
        /// <param name="other"> ��������� ��������� �������.</param>
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Debug.Log("NPC Hello Collider: " + WorldTime.GetCurrentTime().ToString());
                npc.StopMoving();
                Vector3 dir = other.gameObject.transform.position - this.gameObject.transform.position;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                rb.gameObject.transform.rotation = Quaternion.Lerp(rb.rotation, rotation, rotationSpeed * Time.deltaTime);
            }
        }
        /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
        /// <param name="other"> ��������� ��������� �������.</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                npc.StartMoving();
            }
        }
    }
}