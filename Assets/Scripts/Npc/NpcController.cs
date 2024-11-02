using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

namespace NPC
{
    /// <summary>����� ����������� ������ ������������ NPC.</summary>
    public class NpcController : MonoBehaviour
    {
        #region Fields
        /// <summary>������� ����� ��� ������ UNITY AI NavMeshAgent (����� ������).</summary>
        [SerializeField] private NpcPathPoint _basePoint;
        /// <summary> NPC � �������� ���������� ����������.</summary>
        private Npc _targetNpc;
        /// <summary> ������� ������� NPC.</summary>
        private NpcRoute _targetNpcRoute;
        /// <summary>����� UNITY AI NavMeshAgent.</summary>
        private NavMeshAgent _navMeshAgent;
        #endregion

        #region Properties
        /// <summary>�������� ��� ��������� ���������� ������ UNITY AI NavMeshAgent. Readonly .</summary>
        public NavMeshAgent NavMeshAgent
        {
            get
            {
                return _navMeshAgent;
            }
        }
        /// <summary>�������� ��� ��������� ������� ����� NPC.</summary>
        public Vector3 BasePoint
        {
            get
            {
                return _basePoint.Coordinate;
            }
            set
            {
                _basePoint.Coordinate = value;
            }
        }
        /// <summary>���������� ������� ������� NPC.</summary>
        public Vector3 Position
        {
            get
            {
                return this.gameObject.transform.position;
            }
        }
        #endregion

        #region Methods
        /// <summary> ����� ��� ������������� NPC ����������� .</summary>
        private void Start()
        {
            _targetNpc = GetComponent<Npc>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            this.ToBasePoint();
        }
        /// <summary> ����� ��� ���������� ����������� .</summary>
        private void Update()
        {
            //Debug.Log(WorldTime.GetCurrentTime().ToString());
            //OffMeshLink logic
            if (NavMeshAgent.isOnOffMeshLink)
            {
                OffMeshLinkData data = NavMeshAgent.currentOffMeshLinkData;
                Vector3 endPos = data.endPos + Vector3.up * NavMeshAgent.baseOffset;
                Vector3 destination = NavMeshAgent.destination;
                NavMeshAgent.Warp(endPos);
                NavMeshAgent.CompleteOffMeshLink();
                NavMeshAgent.SetDestination(destination);
            }
            //Route logic
            if (_targetNpcRoute)
            {
                NpcPathPoint point = _targetNpcRoute.GetRoutePoint(_targetNpc.Name);
                if (point != null)
                {
                    if (NavMeshAgent.destination != point.Coordinate)
                        SetDestination(point.Coordinate);
                }
            }
        }
        /// <summary> ����� ��� �������� NPC �� ��������.</summary>
        public void SendNpcOnRoute(NpcRoute route)
        {            
            if (_targetNpcRoute != null) _targetNpcRoute.Commit(_targetNpc.Name);
            _targetNpcRoute = route;
        }
        /// <summary> ����� ��� �������� NPC �� ��������.</summary>
        public void ResetNpcRoute()
        {
            _targetNpcRoute = null;
        }
        /// <summary>����� �������� ����� ��� �������� NPC.</summary>
        public NpcAgentResult SetDestination(Vector3 transform)
        {
            if (!NavMeshAgent.enabled) return NpcAgentResult.eAgentIsDisabled;
            if (NavMeshAgent.isStopped) return NpcAgentResult.eAgentIsStopped;

            bool setDestinationResult = NavMeshAgent.SetDestination(transform);

            if (setDestinationResult) return NpcAgentResult.eStartedMoving;
            else return NpcAgentResult.eInvalidDestination;
        }

        /// <summary>����� ��� ����������� NPC � ������ ��������� �����.</summary>
        public void Warp(Vector3 position)
        {
            Vector3 destination = NavMeshAgent.destination;
            NavMeshAgent.Warp(position);
            NavMeshAgent.SetDestination(destination);
        }

        /// <summary>����� ��� ����������� NPC � ������� �����.</summary>
        public void ToBasePoint()
        {
            this.Warp(BasePoint);
        }

        /// <summary>����� ��������� NPC.</summary>
        public void StopMoving()
        {
            if (NavMeshAgent.enabled)
            {
                NavMeshAgent.isStopped = true;
            }
        }

        /// <summary>����� ����������� �������� NPC.</summary>
        public void StartMoving()
        {
            if (NavMeshAgent.enabled)
            {
                NavMeshAgent.isStopped = false;
            }
        }
        #endregion
    }
}