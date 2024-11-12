using System.Collections.Generic;
using FlavorfulStory.Stats.CharacterStats;
using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{   
    /// <summary> Менеджер статов игрока.</summary>
    public class PlayerStatsManager : MonoBehaviour, IStatsManager
    {
        /// <summary> Компонент здоровья.</summary>
        private Health _healthComponent;
        
        /// <summary> Компонент стамины.</summary>
        private Energy _energyComponent;
        
        /// <summary> Компонент маны.</summary>
        private Mana _manaComponent;
        
        /// <summary> Компонент силы.</summary>
        private Strength _strengthComponent;

        private PlayerDataParser _dataParser;

        /// <summary> Получение компонентов.</summary>
        private void Awake()
        {
            _dataParser = GetComponent<PlayerDataParser>();
            _healthComponent = GetComponent<Health>();
            _energyComponent = GetComponent<Energy>();
            _manaComponent = GetComponent<Mana>();
            _strengthComponent = GetComponent<Strength>();
        }

        private void Start()
        {
            SetStats();
            ResetStats();
        }
        
        /// <summary> Установка максимальных значений статов.</summary>
        public void SetStats()
        {
            List<PlayerData> data = _dataParser.PlayerData;
            _healthComponent.MaxHealth = data[0].Health;
            _energyComponent.MaxEnergy = data[0].Energy;
            _manaComponent.MaxMana = data[0].Mana;
            _strengthComponent.CurrentStrength = data[0].Strength;
        }
        
        /// <summary> Обновление значений.</summary>
        public void ResetStats()
        {
            _healthComponent.CurrentHealth = _healthComponent.MaxHealth;
            _energyComponent.CurrentEnergy = _energyComponent.MaxEnergy;
            _manaComponent.CurrentMana = _manaComponent.MaxMana;
        }
        
        #region Saving
        /// <summary>
        /// 
        /// </summary>
        [System.Serializable]
        private struct MoverSaveData
        {
            public int Health;
            public int Energy;
            public int Mana;
            public int Strength;
        }

        /// <summary> Фиксация состояния объекта при сохранении.</summary>
        /// <returns> Возвращает объект, в котором фиксируется состояние.</returns>
        public object CaptureState() => new MoverSaveData()
        {
            Health = _healthComponent.CurrentHealth,
            Energy = _energyComponent.CurrentEnergy,
            Mana = _manaComponent.CurrentMana,
            Strength = _strengthComponent.CurrentStrength
        };

        /// <summary> Восстановление состояния объекта при загрузке.</summary>
        /// <param name="state"> Объект состояния, который необходимо восстановить.</param>
        public void RestoreState(object state)
        {
            var data = (MoverSaveData)state;
            _healthComponent.CurrentHealth = data.Health;
            _energyComponent.CurrentEnergy = data.Energy;
            _manaComponent.CurrentMana = data.Mana;
            _strengthComponent.CurrentStrength = data.Strength;
        }
        #endregion
    }
}