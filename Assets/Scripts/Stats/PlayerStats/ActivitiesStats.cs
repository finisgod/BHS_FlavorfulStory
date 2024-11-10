using System;
using System.Collections.Generic;
using System.Linq;
using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{
    /// <summary> Класс для взаимодействия со статистикой активностей.</summary>
    public class ActivitiesStats : MonoBehaviour
    {
        /// <summary> Событие получения опыта.</summary>
        public event Action OnExperienceGained;
        
        /// <summary> Информация из гугл таблицы.</summary>
        [SerializeField] private SpreadsheetContainer _data;
        
        /// <summary>
        /// Список для каждой активности, который содержит граничные значения опыта для перехода на другой уровень.
        /// </summary>
        public List<List<int>> ActivitiesExpToUpgrade;
        
        /// <summary>
        /// Словарь, который на каждую активность хранит текущее значение опыта и номер левела.
        /// </summary>
        public Dictionary<ActivityType, List<int>> ActivitiesExpDict;
        
        /// <summary> Инициализация и заполнение списка и словаря.</summary>
        private void Awake()  // тут закинул в эвейк, чтобы быстрее заполнялись значения,
                              // так как в UI скрипте Start() быстрее отрабатывает и вылетает ошибка
        {
            ActivitiesExpToUpgrade = new List<List<int>>();
            ParseData();

            ActivitiesExpDict = new Dictionary<ActivityType, List<int>>();
            SetupExp();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                GetExperience(ActivityType.Forestry, 25);
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

        /// <summary> Обработка информации из гугл таблиц.</summary>
        private void ParseData()
        {
            var fields = _data.Content.ExpToLevelUps[0].GetType().GetFields();
            ActivitiesExpToUpgrade = new List<List<int>>();
            
            for (int i = 1; i < fields.Length; i++)
            {
                ActivitiesExpToUpgrade.Add(new List<int>());
                foreach (var t in _data.Content.ExpToLevelUps)
                {
                    var info = fields[i].GetValue(t);
                    ActivitiesExpToUpgrade[i-1].Add((int)info);
                }
            }
        }
    }
}