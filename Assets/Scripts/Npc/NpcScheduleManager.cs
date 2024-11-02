using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    /// <summary>������� ����� ��� ���������� NPC. �������� � ���� ���� �� ��������� � ��������������� �� List � ��������� �������� ��� ��������� (�� GlobalWorldTime) </summary>
    public class NpcScheduleManager : MonoBehaviour //�������� ��� � ���������� ��������� ��� ����� � 1
    {
        #region Fields
        /// <summary>List �� ���������</summary>
        [SerializeField] private List<NpcRoute> _targetRoutesList; //� ���������� ��������� ������ �� ����������� �������
        /// <summary>List � ��������� �������� ��������� ���������(�� GlobalWorldTime).</summary>
        [SerializeField] private List<float> _targetRouteTimeList; //� ���������� ��������� ������ �� ����������� �������
        /// <summary> NPC � �������� ����������� ����������.</summary>
        private Npc _targetNpc;
        /// <summary>.</summary>
        private NpcDailySchedule _dailySchedule; //� ���������� ��������� ������ �� ����������� �������
        #endregion

        #region Methods
        /// <summary> � ������ ������ �������������� ����� � �������������� � �����������.</summary>
        private void Start()
        {
            _targetNpc = GetComponent<Npc>();
            _dailySchedule = GetComponent<NpcDailySchedule>();
            WorldTime.DayEndedEvent += OnDayChanged;
            _dailySchedule.NewDaySchedule(_targetRoutesList, _targetRouteTimeList);
        }
        /// <summary> ���������� ��� ������ ������ ���.</summary>
        public void OnDayChanged() 
        {
            foreach (var route in _targetRoutesList)
            {
                route.Commit(_targetNpc.Name);
            }
            _dailySchedule.NewDaySchedule(_targetRoutesList, _targetRouteTimeList);
        }
        #endregion
    }
}
  