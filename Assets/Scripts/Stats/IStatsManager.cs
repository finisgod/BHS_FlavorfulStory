namespace FlavorfulStory.Stats
{
    /// <summary> Интерфейс для взаимодействия со статами персонажа.</summary>
    public interface IStatsManager
    {
        /// <summary> Установка базовых значений.</summary>
        public void SetStats();
        
        /// <summary> Обновление значений.</summary>
        public void ResetStats();
    }
}