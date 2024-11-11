using System;
using UnityEngine;

namespace FlavorfulStory.Stats.CharacterStats
{
    /// <summary> Класс, обеспечивающий взаимодействие со здоровьем персонажа.</summary>
    public class Health : MonoBehaviour, IIncreasable, IDecreasable
    {
        /// <summary> Событие, вызываемое при изменении здоровья.</summary>
        public event Action<int> OnHealthChanged;
        
        /// <summary> Метод, устанавливающий и возвращающий текущее значение здоровья.</summary>
        public int CurrentHealth { get; set; }
        
        /// <summary> Метод, устанавливающий и возвращающий максимальное значение здоровья.</summary>
        public int MaxHealth { get; set; }

        /// <summary> Присвоение текущего здоровья максимальном.</summary>
        private void Start()
        {
            CurrentHealth = MaxHealth;
        }
        /// <summary> Метод, вызываемый для увеличения здоровья.</summary>
        /// <param name="amount"> Значение, на которое увеличивается здоровье.</param>
        public void InstantIncrease(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth + amount, 0, MaxHealth);

            OnHealthChanged?.Invoke(CurrentHealth);
        }
        /// <summary>  Метод, вызываемый для уменьшения здоровья.</summary>
        /// <param name="amount"> Значение, на которое уменьшается здоровье.</param>
        public void InstantDecrease(int amount)
        {
            CurrentHealth = Mathf.Clamp(CurrentHealth - amount, 0, MaxHealth);

            OnHealthChanged?.Invoke(CurrentHealth);
        }
    }
}