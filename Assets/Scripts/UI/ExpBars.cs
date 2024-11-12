using System;
using System.Collections.Generic;
using FlavorfulStory.Stats.PlayerStats;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace FlavorfulStory.UI
{
    /// <summary> </summary>
    public class ExpBars : MonoBehaviour
    {
        /// <summary> Текстовые объекты. </summary>
        [SerializeField] private List<TMP_Text> _textObjects;
        
        /// <summary> Заполняемые изображения. </summary>
        [SerializeField] private List<Image> _imageObjects;
        
        /// <summary> Игрок.</summary>
        [SerializeField] private GameObject _player;
        
        /// <summary> Менеджер активностей.</summary>
        private ActivitiesStatsManager _activitiesStatsManager;

        /// <summary> Подписка на событие.</summary>
        private void OnEnable()
        {
            _activitiesStatsManager.OnExperienceGained += SetExpBars;
        }

        /// <summary> Отписка от события.</summary>
        private void OnDisable()
        {
            _activitiesStatsManager.OnExperienceGained -= SetExpBars;
        }

        /// <summary> Получение компонента.</summary>
        private void Awake()
        {
            _activitiesStatsManager = _player.GetComponent<ActivitiesStatsManager>();
        }
        
        private void Start()
        {
            SetExpBars();
        }
        
        /// <summary> Заполнение полосок опыта.</summary>
        private void SetExpBars()
        {
            var i = 0;
            foreach (ActivityType activityType in Enum.GetValues(typeof(ActivityType)))
            {
                var level = _activitiesStatsManager.ActivitiesExpDict[activityType][1];
                var maxLevel = _activitiesStatsManager.ActivitiesExpToUpgrade[i].Count;
                
                if (level == maxLevel)
                {
                    _textObjects[i].text = "Max level";
                    _imageObjects[i].fillAmount = 1;
                }
                else
                {
                    _textObjects[i].text = _activitiesStatsManager.ActivitiesExpDict[activityType][0] + " / " 
                        + _activitiesStatsManager.ActivitiesExpToUpgrade[i][level];
                    
                    _imageObjects[i].fillAmount = Mathf.Clamp01(
                        (float)_activitiesStatsManager.ActivitiesExpDict[activityType][0] / 
                        _activitiesStatsManager.ActivitiesExpToUpgrade[i][level]
                    );
                }
                i += 1;
            }
        }
    }
}