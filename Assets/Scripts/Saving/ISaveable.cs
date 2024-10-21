namespace FlavorfulStory.Saving
{
    public interface ISaveable
    {
        public object CaptureState();

        public void RestoreState(object state);
    }
}