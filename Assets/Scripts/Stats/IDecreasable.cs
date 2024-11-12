namespace FlavorfulStory.Stats
{
    /// <summary> Интерфейс, позволяющий уменьшать значение определенного параметра.</summary>
    public interface IDecreasable
    {
        /// <summary> Увеличение параметра.</summary>
        /// <param name="amount"> Значение, на которое увеличивается параметр.</param>
        public void InstantDecrease(int amount);
    }
}