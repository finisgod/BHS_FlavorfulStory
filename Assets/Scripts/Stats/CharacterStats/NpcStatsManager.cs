using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.CharacterStats
{
    /// <summary> Менеджер статов персонажа.</summary>
    public class NpcStatsManager : MonoBehaviour, IStatsManager
    {
        /// <summary> Имя NPC.</summary>
        [SerializeField] private string _name;
        
        /// <summary> Информация из гугл таблицы.</summary>
        [SerializeField] private SpreadsheetContainer _data;
        
        /// <summary> Компонент здоровья.</summary>
        private Health _healthComponent;
        
        /// <summary> Компонент силы.</summary>
        private Strength _strengthComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<Health>();
            _strengthComponent = GetComponent<Strength>();
        }

        private void Start()
        {
            SetStats();
        }

        /// <summary> Установка статов для персонажа.</summary>
        public void SetStats()
        {
            foreach (var data in _data.Content.NpcData)
            {
                if (data.Name == _name)
                {
                    _healthComponent.MaxHealth = data.Health;
                    _strengthComponent.CurrentStrength = data.Strength;
                    break;
                }
            }
        }

        public void ResetStats()
        {
            _healthComponent.CurrentHealth = _healthComponent.MaxHealth;
        }
    }
}