using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace NPC
{
    /// <summary>Ѕазовый класс дл€ расписаний NPC. ¬ключает в себ€ Ћист из ћаршрутов и соответствующий им List с ожидаемым временем его окончани€ (по GlobalWorldTime) </summary>
    public class NpcDailySchedule : MonoBehaviour //ѕодумать как в инспекторе соединить два листа в 1
    {
        #region Fields
        /// <summary>List из ћаршрутов</summary>
        private List<NpcRoute> _targetRoutesList; //¬ инспекторе создавать строго по возрастанию времени
        /// <summary>List с ожидаемым временем окончани€ маршрутов(по GlobalWorldTime).</summary>
        private List<float> _targetRouteTimeList; //¬ инспекторе создавать строго по возрастанию времени
        /// <summary> идентификатор данного расписани€.</summary>
        [SerializeField] private string _tag;
        /// <summary> контроллер NPC к которому прикреплено расписание.</summary>
        private NpcController _targetNpcController;
        #endregion

        #region Methods
        /// <summary> ¬ данном методе контролируетс€ врем€ и сопоставл€етс€ с расписанием.</summary>
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
        /// <summary> ћетод дл€ инициализации расписани€.</summary>
        private void Start()
        {
            _targetNpcController = GetComponent<NpcController>();
        }
        /// <summary> ћетод дл€ инициализации расписани€ в новый день.</summary>
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