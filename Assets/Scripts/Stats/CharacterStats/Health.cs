using System;
using UnityEngine;

namespace FlavorfulStory.Stats.CharacterStats
{
    /// <summary> Класс, обеспечивающий взаимодействие со здоровьем персонажа.</summary>
    public class Health : BaseStat
    {
        /// <summary> Событие изменения здоровья.</summary>
        public event Action<int> OnHealthChanged;
        
        /// <summary> Присвоение текущего здоровья максимальном.</summary>
        private void Start()
        {
            CurrentValue = MaxValue; // TODO: изменить к системе сохранений
        }
        /// <summary> Метод, вызываемый для увеличения здоровья.</summary>
        /// <param name="healthToRestore"> Значение, на которое увеличивается здоровье.</param>
        public void Heal(int healthToRestore)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + healthToRestore, 0, MaxValue);

            OnHealthChanged?.Invoke(CurrentValue);
        }
        /// <summary> Метод, вызываемый для уменьшения здоровья.</summary>
        /// <param name="damage"> Значение, на которое уменьшается здоровье.</param>
        public void TakeDamage(int damage)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - damage, 0, MaxValue);

            OnHealthChanged?.Invoke(CurrentValue);
        }
    }
}