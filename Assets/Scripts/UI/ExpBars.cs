using System;
using System.Collections.Generic;
using FlavorfulStory.Stats.PlayerStats;
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

        [SerializeField] private GameObject _player;
        private ActivitiesStats _activitiesStats;

        private void OnEnable()
        {
            _activitiesStats.OnExperienceGained += SetExpText;
        }

        private void OnDisable()
        {
            _activitiesStats.OnExperienceGained += SetExpText;
        }

        private void Awake()
        {
            _activitiesStats = _player.GetComponent<ActivitiesStats>();
        }
        
        private void Start()
        {
            SetExpText();
        }
        
        private void SetExpText()
        {
            int i = 0;
            foreach (ActivityType activityType in Enum.GetValues(typeof(ActivityType)))
            {
                _textObjects[i].text = _activitiesStats.ActivitiesExpDict[activityType][0] + " / " 
                    + _activitiesStats.ActivitiesExpToUpgrade[i][_activitiesStats.ActivitiesExpDict[activityType][1]];
                i += 1;
            }
        }
    }
}