using System;
using System.Collections.Generic;
using UnityEngine;
using FlavorfulStory.Saving;

namespace FlavorfulStory.Stats.PlayerStats
{
    /// <summary> Класс для взаимодействия со статистикой активностей.</summary>
    public class ActivitiesStatsManager : MonoBehaviour, ISaveable
    {
        /// <summary> Событие получения опыта.</summary>
        public event Action OnExperienceGained;
        
        /// <summary>
        /// Список для каждой активности, который содержит граничные значения опыта для перехода на другой уровень.
        /// </summary>
        public List<List<int>> ActivitiesExpToUpgrade;
        
        /// <summary>
        /// Словарь, который на каждую активность хранит текущее значение опыта и номер левела.
        /// </summary>
        public Dictionary<ActivityType, List<int>> ActivitiesExpDict{get; private set;}

        private PlayerDataParser _dataParser;
        
        /// <summary> Инициализация и заполнение списка и словаря.</summary>
        private void Awake()  // тут закинул в эвейк, чтобы быстрее заполнялись значения,
                              // так как в UI скрипте Start() быстрее отрабатывает и вылетает ошибка
        {
            _dataParser = GetComponent<PlayerDataParser>();
            ActivitiesExpToUpgrade = _dataParser.ActivitiesExpToUpgrade;

            ActivitiesExpDict = new Dictionary<ActivityType, List<int>>();
            SetupExp();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GetExperience(ActivityType.Collecting, 10);
                GetExperience(ActivityType.CrystalCultivation, 25);
            }
        }

        /// <summary> Обработка получения опыта на конкретную активность.</summary>
        /// <param name="activityType"> Тип активности.</param>
        /// <param name="amount"> Количество опыта.</param>
        public void GetExperience(ActivityType activityType, int amount)
        {
            ActivitiesExpDict[activityType][0] += amount;
            
            var experience = ActivitiesExpDict[activityType][0];
            var level = ActivitiesExpDict[activityType][1];

            if (level == ActivitiesExpToUpgrade[(int)activityType].Count)
            {
                ActivitiesExpDict[activityType][0] = ActivitiesExpToUpgrade[(int)activityType][^1];
                return;
            }
            
            var expToUpgrade = ActivitiesExpToUpgrade[(int)activityType][level];
            if (experience >= expToUpgrade)
            {
                ActivitiesExpDict[activityType][0] -= expToUpgrade;
                ActivitiesExpDict[activityType][1] += 1;
                
                if (ActivitiesExpDict[activityType][1] == ActivitiesExpToUpgrade[(int)activityType].Count)
                {
                    ActivitiesExpDict[activityType][1] = ActivitiesExpDict[activityType][1];
                    ActivitiesExpDict[activityType][0] = ActivitiesExpToUpgrade[(int)activityType][level];
                }

            }
            
            OnExperienceGained?.Invoke();
        }
        
        /// <summary> Заполнение словаря опыта.</summary>
        private void SetupExp()
        {
            foreach (ActivityType activityType in Enum.GetValues(typeof(ActivityType)))
            {
                ActivitiesExpDict.Add(activityType, new List<int> {0, 0});
            }
        }
        
        #region Saving
        /// <summary>
        /// 
        /// </summary>
        [System.Serializable]
        private struct MoverSaveData
        {
            public List<List<int>> _ActivitiesExpToUpgrade;
            public Dictionary<ActivityType, List<int>> _ActivitiesExpDict;
        }

        /// <summary> Фиксация состояния объекта при сохранении.</summary>
        /// <returns> Возвращает объект, в котором фиксируется состояние.</returns>
        public object CaptureState() => new MoverSaveData()
        {
            _ActivitiesExpToUpgrade = ActivitiesExpToUpgrade,
            _ActivitiesExpDict = ActivitiesExpDict
        };

        /// <summary> Восстановление состояния объекта при загрузке.</summary>
        /// <param name="state"> Объект состояния, который необходимо восстановить.</param>
        public void RestoreState(object state)
        {
            var data = (MoverSaveData)state;
            ActivitiesExpToUpgrade = data._ActivitiesExpToUpgrade;
            ActivitiesExpDict = data._ActivitiesExpDict;
            GetExperience(ActivityType.Collecting, 0);
        }
        #endregion
    }
}