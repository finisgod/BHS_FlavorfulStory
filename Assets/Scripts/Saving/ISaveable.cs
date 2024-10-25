namespace FlavorfulStory.Saving
{
    /// <summary> ���������, ����������� ��������� � ��������� ������ �������.</summary>
    public interface ISaveable
    {
        /// <summary> �������� ��������� ������� ��� ����������.</summary>
        /// <returns> ���������� ������, � ������� ����������� ���������.</returns>
        public object CaptureState();

        /// <summary> �������������� ��������� ������� ��� ��������.</summary>
        /// <param name="state"> ������ ���������, ������� ���������� ������������.</param>
        public void RestoreState(object state);
    }
}