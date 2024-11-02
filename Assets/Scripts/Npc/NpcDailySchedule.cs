using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC
{
    /// <summary>������� ����� ��� ���������� NPC. �������� � ���� ���� �� ��������� � ��������������� �� List � ��������� �������� ��� ��������� (�� GlobalWorldTime) </summary>
    public class NpcDailySchedule : MonoBehaviour //�������� ��� � ���������� ��������� ��� ����� � 1
    {
        #region Fields
        /// <summary>List �� ���������</summary>
        private List<NpcRoute> _targetRoutesList; //� ���������� ��������� ������ �� ����������� �������
        /// <summary>List � ��������� �������� ��������� ���������(�� GlobalWorldTime).</summary>
        private List<float> _targetRouteTimeList; //� ���������� ��������� ������ �� ����������� �������
        /// <summary> ������������� ������� ����������.</summary>
        [SerializeField] private string _tag;
        /// <summary> ���������� NPC � �������� ����������� ����������.</summary>
        private NpcController _targetNpcController;
        #endregion

        #region Methods
        /// <summary> � ������ ������ �������������� ����� � �������������� � �����������.</summary>
        private void Update()
        {
            NpcRoute route = null;
            if (_targetRouteTimeList.Count > 0)
            {
                float predictedTime = _targetRouteTimeList[0] - NpcRouteTimePredictor.PredictTime(_targetNpcController.Position, _targetRoutesList[0]);
                if (WorldTime.GetCurrentTime() > predictedTime) route = _targetRoutesList[0];        
            }
            if (route != null)
            {
                _targetNpcController.SendNpcOnRoute(route);
                _targetRouteTimeList.RemoveAt(_targetRoutesList.IndexOf(route));
                _targetRoutesList.Remove(route);  
            }
        }
        /// <summary> ����� ��� ������������� ����������.</summary>
        private void Start()
        {
            _targetNpcController = GetComponent<NpcController>();
        }
        /// <summary> ����� ��� ������������� ���������� � ����� ����.</summary>
        public void NewDaySchedule(List<NpcRoute> routes , List<float> times)
        {
            _targetRoutesList = new List<NpcRoute>();
            _targetRouteTimeList = new List<float>();
            foreach (NpcRoute route in routes)
            {
                _targetRoutesList.Add(route);
            }
            foreach (float time in times)
            {
                _targetRouteTimeList.Add(time);
            }
            _targetNpcController.ResetNpcRoute();
        }
        #endregion
    }
}