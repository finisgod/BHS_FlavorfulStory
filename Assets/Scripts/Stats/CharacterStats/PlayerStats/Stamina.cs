using System;
using FlavorfulStory.Stats;
using FlavorfulStory.Stats.CharacterStats;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{
    /// <summary>  Класс, обеспечивающий взаимодействие с выносливостью персонажа. </summary>
    public class Stamina : BaseStat
    {
        /// <summary> Событие изменения выносливости.</summary>
        public event Action<int> OnStaminaChanged;

        
        /// <summary> Присвоение текущей выносливости максимальной.</summary>
        private void Start()
        {
            CurrentValue = MaxValue;
        }
        
        /// <summary> Увеличение выносливости.</summary>
        /// <param name="amount"> Значение, на которое увеличивается выносливость.</param>
        public void IncreaseStamina(int amount)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + amount, 0, MaxValue);

            OnStaminaChanged?.Invoke(CurrentValue);
        }
        
        /// <summary> Уменьшение выносливости.</summary>
        /// <param name="amount"> Значение, на которое уменьшается выносливость.</param>
        public void DecreaseStamina(int amount)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - amount, 0, MaxValue);

            OnStaminaChanged?.Invoke(CurrentValue);
        }
    }
}