using UnityEngine;

namespace NPC
{
    /// <summary>����� ����������� ������ ���������� � ����� ��������.</summary>
    ///<remarks> �������� ��������������, ��� ��������� ����� "�����������" .</remarks>
    public class NpcPathPointCollider : MonoBehaviour
    {
        #region Fields
        /// <summary>PathPoint �� ������� ����� ���������.</summary>
        private NpcPathPoint _pathPoint;
        #endregion

        #region Methods
        /// <summary>����� ������������ ��� ������ �������.</summary>
        public void Start()
        {
            _pathPoint = GetComponent<NpcPathPoint>();
        }

        /// <summary>����� ������������ ��� ����� � ��������� ������� �� ������� ���� ������ ����� .</summary>
        /// <param name="other"> ��������� ��������� �������.</param>
        private void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag("Npc"))
            {
                Npc npc = other.gameObject.GetComponent<Npc>();
                _pathPoint.SetNpcAchieved(npc.Name);
            }
        }
        #endregion
    }
}