/// <summary> Интерфейс, описывающий подбираемые объекты.</summary>
public interface IPickableObject
{
    /// <summary> Метод для подбора объекта и преобразования его в айтем.</summary>
    public Item PickAndDestroy();
}