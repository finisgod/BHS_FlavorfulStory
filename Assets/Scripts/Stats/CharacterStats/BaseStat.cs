using UnityEngine;

namespace FlavorfulStory.Stats.CharacterStats
{
    /// <summary> Базовый класс для всех игровых параметров (здоровье, мана, выносливость).</summary>
    public abstract class BaseStat : MonoBehaviour
    {
        /// <summary> Текущее значение параметра.</summary>
        public int CurrentValue { get; set; }

        /// <summary> Максимальное значение параметра.</summary>
        public int MaxValue { get; set; }
        
        /// <summary> Сброс др максимального значения.</summary>
        public void ResetToMaxValue()
        {
            CurrentValue = MaxValue;
        }
    }
}