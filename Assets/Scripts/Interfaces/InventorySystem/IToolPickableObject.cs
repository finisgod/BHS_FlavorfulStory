using Assets.Scripts.Items.Instruments;

namespace Assets.Scripts.Interfaces.InventorySystem
{
    public interface IToolPickableObject
    {
        /// <summary> Метод для подбора объекта и преобразования его в айтем.</summary>
        public Item PickByToolAndDestroy(ToolItem tool);
    }
}
