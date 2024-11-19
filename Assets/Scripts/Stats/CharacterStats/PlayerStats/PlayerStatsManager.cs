using System;
using System.Collections.Generic;
using FlavorfulStory.Saving;
using FlavorfulStory.Stats.CharacterStats;
using FlavorfulStory.Stats.TableImport;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{   
    /// <summary> Менеджер статов игрока.</summary>
    public class PlayerStatsManager : MonoBehaviour, ISaveable
    {
        /// <summary> Компонент здоровья.</summary>
        private Health _healthComponent;
        
        /// <summary> Компонент стамины.</summary>
        private Stamina _staminaComponent;
        
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
            _staminaComponent = GetComponent<Stamina>();
            _manaComponent = GetComponent<Mana>();
            _strengthComponent = GetComponent<Strength>();
        }

        private void Start()
        {
            SetStats();
        }

        /// <summary> Установка максимальных значений статов.</summary>
        private void SetStats()
        {
            List<PlayerData> data = _dataParser.PlayerData;
            _healthComponent.MaxValue = data[0].Health;
            _staminaComponent.MaxValue = data[0].Energy;
            _manaComponent.MaxValue = data[0].Mana;
            
            _strengthComponent.CurrentStrength = data[0].Strength;
        }
        
        /// <summary> Обновление значений.</summary>
        public void ResetStats()
        {
            _healthComponent.ResetToMaxValue();
            _staminaComponent.ResetToMaxValue();
            _manaComponent.ResetToMaxValue();
        }
        
        #region Saving
        /// <summary> </summary>
        [System.Serializable]
        private struct PlayerStatsSaveData
        {
            public int Health;
            public int Energy;
            public int Mana;
            public int Strength;
        }

        /// <summary> Фиксация состояния объекта при сохранении.</summary>
        /// <returns> Возвращает объект, в котором фиксируется состояние.</returns>
        public object CaptureState() => new PlayerStatsSaveData()
        {
            Health = _healthComponent.CurrentValue,
            Energy = _staminaComponent.CurrentValue,
            Mana = _manaComponent.CurrentValue,
            
            Strength = _strengthComponent.CurrentStrength
        };

        /// <summary> Восстановление состояния объекта при загрузке.</summary>
        /// <param name="state"> Объект состояния, который необходимо восстановить.</param>
        public void RestoreState(object state)
        {
            var data = (PlayerStatsSaveData)state;
            _healthComponent.CurrentValue = data.Health;
            _staminaComponent.CurrentValue = data.Energy;
            _manaComponent.CurrentValue = data.Mana;
            
            _strengthComponent.CurrentStrength = data.Strength;
        }
        #endregion
    }
}