using UnityEngine;
using UnityEngine.AI;

namespace NPC
{
    /// <summary>������� ����� ��� NPC. �������� � ���� ������ UNITY AI NavMeshAgent</summary>
    public class Npc : MonoBehaviour
    {
        #region Fields
        /// <summary>���������� ��� ��� NPC.</summary>
        [SerializeField] private string _name;
        #endregion

        #region Properties
        /// <summary>�������� ��� ��������� ����� NPC.</summary>
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        #endregion

        #region Methods
        #endregion
    }
}