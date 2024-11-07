using FlavorfulStory.Stats.PlayerStats;
using UnityEngine;
using UnityEngine.UI;

namespace FlavorfulStory.UI
{
    public class ExpButton : MonoBehaviour
    {
        [SerializeField] private ActivityType _activityType;
        [SerializeField] private GameObject _playerObject;
        private ActivitiesStats _activitiesStats;
        private Button _button;


        private void Awake()
        {
            _activitiesStats = _playerObject.GetComponent<ActivitiesStats>();
            _button = GetComponent<Button>();
        }

        private void Start()
        {
            _button.onClick.AddListener(Clicked);
        }

        private void Clicked()
        {
            _activitiesStats.GetExperience(_activityType, 5);
        }
    }
}