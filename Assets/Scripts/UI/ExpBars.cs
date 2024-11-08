using System;
using System.Collections.Generic;
using FlavorfulStory.Stats.PlayerStats;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

namespace FlavorfulStory.UI
{
    /// <summary>
    /// 
    /// </summary>
    public class ExpBars : MonoBehaviour
    {
        [SerializeField] private List<TMP_Text> _textObjects;
        [SerializeField] private List<Image> _imageObjects;
        
        [SerializeField] private GameObject _player;
        private ActivitiesStats _activitiesStats;

        private void OnEnable()
        {
            _activitiesStats.OnExperienceGained += SetExpBar;
        }

        private void OnDisable()
        {
            _activitiesStats.OnExperienceGained += SetExpBar;
        }

        private void Awake()
        {
            _activitiesStats = _player.GetComponent<ActivitiesStats>();
        }

        private void Start()
        {
            SetExpBar();
        }
        
        
        private void SetExpBar()
        {
            int i = 0;
            foreach (ActivityType activityType in Enum.GetValues(typeof(ActivityType)))
            {
                var level = _activitiesStats.ActivitiesExpDict[activityType][1];
                if (level == _activitiesStats.ActivitiesExpToUpgrade[i].Count)
                {
                    _textObjects[i].text = "Max level";
                    _imageObjects[i].fillAmount = 1;
                }
                else
                {
                    _textObjects[i].text = _activitiesStats.ActivitiesExpDict[activityType][0] + " / " 
                        + _activitiesStats.ActivitiesExpToUpgrade[i][level];
                    
                    _imageObjects[i].fillAmount = Mathf.Clamp01(
                        (float)_activitiesStats.ActivitiesExpDict[activityType][0] / 
                        _activitiesStats.ActivitiesExpToUpgrade[i][level]
                    );
                }
                i += 1;
            }
        }
    }
}