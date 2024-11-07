namespace FlavorfulStory.Stats
{
    /// <summary> Интерфейс, позволяющий увеличить значение определенного параметра..</summary>
    public interface IIncreasable
    {
        /// <summary> Увеличение параметра.</summary>
        /// <param name="amount"> Значение, на которое уменьшается параметр.</param>
        public void InstantIncrease(int amount);
    }
}