using FlavorfulStory.Stats.CharacterStats;
using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{   
    /// <summary> Менеджер статов игрока.</summary>
    public class PlayerStatsManager : MonoBehaviour, IStatsManager
    {
        /// <summary> Информация из гугл таблицы.</summary>
        [SerializeField] private SpreadsheetContainer _data;
        /// <summary> Компонент здоровья.</summary>
        private Health _healthComponent;
        
        /// <summary> Компонент стамины.</summary>
        private Energy _energyComponent;
        
        /// <summary> Компонент маны.</summary>
        private Mana _manaComponent;
        
        /// <summary> Компонент силы.</summary>
        private Strength _strengthComponent;
    
        /// <summary> Получение компонентов.</summary>
        private void Awake()
        {
            _healthComponent = GetComponent<Health>();
            _energyComponent = GetComponent<Energy>();
            _manaComponent = GetComponent<Mana>();
            _strengthComponent = GetComponent<Strength>();
        }

        private void Start()
        {
            SetStats();
        }
        
        /// <summary> Установка максимальных значений статов.</summary>
        public void SetStats()
        {
            _healthComponent.MaxHealth = _data.Content.PlayerData[0].Health;
            _energyComponent.MaxEnergy = _data.Content.PlayerData[0].Energy;
            _manaComponent.MaxMana = _data.Content.PlayerData[0].Mana;
            _strengthComponent.CurrentStrength = _data.Content.PlayerData[0].Strength;
        }
    }
}