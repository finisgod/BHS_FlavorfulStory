using System;
using FlavorfulStory.Stats;
using UnityEngine;

namespace FlavorfulStory.Stats.PlayerStats
{
    /// <summary>  Класс, обеспечивающий взаимодействие с энергией персонажа. </summary>
    public class Energy : MonoBehaviour, IIncreasable, IDecreasable
    {
        /// <summary> Событие, вызываемое при изменении энергии.</summary>
        public event Action<int> OnEnergyChanged;

        /// <summary> Метод, устанавливающий и возвращающий текущее значение энергии.</summary>
        public int CurrentEnergy { get; set; }
        
        /// <summary> Метод, устанавливающий и возвращающий максимальное значение энергии.</summary>
        public int MaxEnergy { get; set; }
        
        /// <summary> Присвоение текущей энергии максимальной.</summary>
        private void Start()
        {
            CurrentEnergy = MaxEnergy;
        }
        
        /// <summary> Метод, вызываемый при увеличении энергии.</summary>
        /// <param name="amount"> Значение, на которое увеличивается энергия.</param>
        public void InstantIncrease(int amount)
        {
            CurrentEnergy = Mathf.Clamp(CurrentEnergy + amount, 0, MaxEnergy);

            OnEnergyChanged?.Invoke(CurrentEnergy);
        }
        
        /// <summary> Метод, вызываемый при уменьшении энергии.</summary>
        /// <param name="amount"> Значение, на которое уменьшается энергия.</param>
        public void InstantDecrease(int amount)
        {
            CurrentEnergy = Mathf.Clamp(CurrentEnergy - amount, 0, MaxEnergy);

            OnEnergyChanged?.Invoke(CurrentEnergy);
        }
    
    }
}