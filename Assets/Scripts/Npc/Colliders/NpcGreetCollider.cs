using UnityEngine;

namespace NPC
{
    /// <summary> �����, ����������� ������ �������� NPC � �������� ��������� ��� �������.</summary>
    public class FaceToFaceCollider : MonoBehaviour //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
    {
        /// <summary>RigidBody ������������� NPC .</summary>
        [SerializeField] private Rigidbody _rb;

        /// <summary>�������� �������� NPC .</summary>
        [SerializeField] private float _rotationSpeed;

        /// <summary>���������� NPC.</summary>
        [SerializeField] private NpcController _npc;

        /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
        /// <param name="other"> ��������� ��������� �������.</param>
        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                //Debug.Log("NPC Hello Collider: " + WorldTime.GetCurrentTime().ToString());
                _npc.StopMoving();
                Vector3 dir = other.gameObject.transform.position - this.gameObject.transform.position;
                float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.Euler(0, angle, 0);
                _rb.gameObject.transform.rotation = Quaternion.Lerp(_rb.rotation, rotation, _rotationSpeed * Time.deltaTime);
            }
        }
        /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
        /// <param name="other"> ��������� ��������� �������.</param>
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                _npc.StartMoving();
            }
        }
    }
}