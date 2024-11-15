namespace FlavorfulStory.InventorySystem
{
    /// <summary> ������, ����������� ���� ���������, ��������� 
    /// "ItemTooltipSpawner" ���������� ������ ����������.</summary>
    public interface IItemHolder
    {
        public InventoryItem GetItem();
    }
}