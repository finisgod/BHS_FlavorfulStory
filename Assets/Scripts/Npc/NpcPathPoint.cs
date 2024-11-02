using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    /// <summary>����� - ����� ��� ��������� NPC. �� ��������� �������� "�����" �� 1 �����</summary>
    public class NpcPathPoint : MonoBehaviour
    {
        #region Fields
        /// <summary>�������� �� ����� �������� ��� ����������� ����� ���������� (����).</summary>
        [SerializeField] private bool _isInstancePortal; //� ������� ������ ������ �������� � ��������� �����
        /// <summary>��� �������� �� ������� ����������� ��� �����.</summary>
        [SerializeField] private string _instanceName; //� ������� ������ ������ �������� � ��������� �����
        /// <summary>���������� �����.</summary>
        private Vector3 _coordinate;
        /// <summary>������������ ������ �� ���� NPC, ��� ������ ��� �����. ����� ���������� �������� ������ NPC �������� �� ������</summary>
        private List<string> _achievedByNpcList;
        #endregion

        #region Properties
        /// <summary>�������� ��� ��������� ���������� �����. Readonly .</summary>
        public Vector3 Coordinate
        {
            get
            {
                return _coordinate;
            }
            set
            {
                _coordinate = value;
            }
        }
        /// <summary>�������� ������������ true/false � ����������� �� ����, �������� �� ����� �������� ����� ����������. Readonly .</summary>
        public bool IsInstancePortal
        {
            get
            {
                return _isInstancePortal;
            }
        }
        /// <summary>�������� ������������ ����� ���������� ������� ����� ����������. Readonly .</summary>
        public NpcPathPoint PortalDestination //� ������� ������ ������ �������� � ��������� �����
        {
            get
            {
                if (IsInstancePortal) return GetComponent<InstancePortalCollider>().Destination;
                return null;
            }
        }
        /// <summary>��� �������� �� ������� ����������� �����. Readonly .</summary>
        public string InstanceName //� ������� ������ ������ �������� � ��������� �����
        {
            get
            {
                return _instanceName;
            }
        }
        #endregion

        #region Methods
        /// <summary>����� ������ �������. ��� �������������.</summary>
        private void Awake() //Awake ��� ����, ����� � ������� Start() ��� ������ �� PathPoint �������� ��� ������������������ �������
        {
            _coordinate = this.transform.position;
        }
        private void Start()
        {
            _achievedByNpcList = new List<string>();
        }
        /// <summary>����� ������������ true/false � ����������� �� ���������� ����� NPC.</summary>
        public bool IsNpcAchieved(string npcIdentifier)
        {
            return _achievedByNpcList.Contains(npcIdentifier);
        }
        /// <summary>����� ��� �������� NPC �� ������ ��������� ����� (���������� ����� ���������� ��������).</summary>
        public bool RemoveNpcAchieved(string npcIdentifier)
        {
            return _achievedByNpcList.Remove(npcIdentifier);
        }
        /// <summary>����� ��� ���������� NPC � ������ ��������� ����� (���������� ����� ���������� ��������).</summary>
        public bool SetNpcAchieved(string npcIdentifier)
        {
            if (_achievedByNpcList.Contains(npcIdentifier)) return false;

            _achievedByNpcList.Add(npcIdentifier);
            return true;
        }
        #endregion
    }
}