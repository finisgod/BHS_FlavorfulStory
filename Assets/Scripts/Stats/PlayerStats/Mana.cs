using System;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{
    /// <summary> Класс, обеспечивающий взаимодействие с энергией персонажа.</summary>
    public class Mana : MonoBehaviour, IIncreasable, IDecreasable
    {
        /// <summary> Событие, вызываемое при изменении маны.</summary>
        public event Action<int> OnManaChanged;
        
        /// <summary> Метод, устанавливающий и возвращающий текущее значение маны.</summary>
        public int CurrentMana { get ; set ; }
        
        /// <summary> Метод, устанавливающий и возвращающий максимальное значение маны.</summary>
        public int MaxMana { get ;  set; }
        
        /// <summary> Присвоение текущей маны максимальной.</summary>
        private void Start()
        {
            CurrentMana = MaxMana;
        }
        
        /// <summary>  Метод, вызываемый при увеличении маны.</summary>
        /// <param name="amount">Значение, на которое увеличивается мана.</param>
        public void InstantIncrease(int amount)
        {
            CurrentMana = Mathf.Clamp(CurrentMana + amount, 0, MaxMana);

            OnManaChanged?.Invoke(CurrentMana);
        }
        
        /// <summary> Метод, вызываемый при уменьшении маны.</summary>
        /// <param name="amount">Значение, на которое уменьшается мана.</param>
        public void InstantDecrease(int amount)
        {
            CurrentMana = Mathf.Clamp(CurrentMana - amount, 0, MaxMana);

            OnManaChanged?.Invoke(CurrentMana);
        }
    }
}