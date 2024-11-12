using UnityEngine;

namespace FlavorfulStory.Stats.CharacterStats
{
    /// <summary> Класс, обеспечивающий взаимодействие с силой персонажа.</summary>
    public class Strength : MonoBehaviour, IIncreasable, IDecreasable
    {

        /// <summary> Метод, устанавливающий и возвращающий максимальное значение силы.</summary>
        public int CurrentStrength { get; set; } 

        /// <summary> Метод, вызываемый при увеличении силы.</summary>
        /// <param name="amount"> Значение, на которое увеличивается сила.</param>
        public void InstantIncrease(int amount)
        {
            CurrentStrength = Mathf.Clamp(CurrentStrength + amount, 0, CurrentStrength);
        }
        
        /// <summary> Метод, вызываемый при уменьшении силы.</summary>
        /// <param name="amount"> Значение, на которое уменьшается сила.</param>
        public void InstantDecrease(int amount)
        {
            CurrentStrength = Mathf.Clamp(CurrentStrength - amount, 0, CurrentStrength);
        }
    }
}