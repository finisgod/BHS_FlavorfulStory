using System;
using System.Collections.Generic;
using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{
    /// <summary> Класс для взаимодействия со статистикой активностей.</summary>
    public class ActivitiesStats : MonoBehaviour
    {
        /// <summary> Событие получения урона.</summary>
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
        private void Awake()  // туу закинул в эвейк, чтобы быстрее заполнялись значения,
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
                GetExperience(ActivityType.Hunting, 5);
                GetExperience(ActivityType.Collecting, 10);
                GetExperience(ActivityType.Fishing, 15);
                GetExperience(ActivityType.Cultivation, 20);
                GetExperience(ActivityType.AnimalFarming, 25);
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
            var expToUpgrade = ActivitiesExpToUpgrade[(int)activityType][level];

            if (experience >= expToUpgrade)
            {
                ActivitiesExpDict[activityType][0] -= expToUpgrade;
                ActivitiesExpDict[activityType][1] += 1;
            }
            
            OnExperienceGained?.Invoke();
        }
        
        /// <summary> Обработка информации из гугл таблиц.</summary>
        private void ParseData()
        {
            for (int i = 0; i < 5; i++)
            {
                ActivitiesExpToUpgrade.Add(new List<int>());
                ActivitiesExpToUpgrade[i].Add(_data.Content.ExpToLevelUps[i].Level_0_1);
                ActivitiesExpToUpgrade[i].Add(_data.Content.ExpToLevelUps[i].Level_1_2);
                ActivitiesExpToUpgrade[i].Add(_data.Content.ExpToLevelUps[i].Level_2_3);
                ActivitiesExpToUpgrade[i].Add(_data.Content.ExpToLevelUps[i].Level_3_4);
                ActivitiesExpToUpgrade[i].Add(_data.Content.ExpToLevelUps[i].Level_4_5);
            }
        }
        
        /// <summary> Заполнение словаря.</summary>
        private void SetupExp()
        {
            foreach (ActivityType activityType in Enum.GetValues(typeof(ActivityType)))
            {
                ActivitiesExpDict.Add(activityType, new List<int> {0, 0});
            }
        }
    }
}