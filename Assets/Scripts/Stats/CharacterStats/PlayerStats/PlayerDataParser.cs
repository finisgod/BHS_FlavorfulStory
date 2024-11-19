using System.Collections.Generic;
using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{
    /// <summary> Класс для обработки информации из таблиц.</summary>
    public class PlayerDataParser : MonoBehaviour
    {
        /// <summary> Информация из гугл таблицы.</summary>
        [SerializeField] private SpreadsheetContainer _data;
        
        /// <summary> Набор значений опыта для получения нового уровня для каждой активности.</summary>
        public List<List<int>> ActivitiesExpToUpgrade { get; set; }

        /// <summary> Параметры игрока.</summary>
        public List<PlayerData> PlayerData { get; set; }
        
        private void Awake() // если делать через старт, то изначально вылетает ошибка и текст на ЭкспБары не ставится
        {
            GetPlayerActivitiesData();
            PlayerData = _data.Content.PlayerData;
        }

        /// <summary> Обработка информации из гугл таблиц.</summary>
        private void GetPlayerActivitiesData()
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