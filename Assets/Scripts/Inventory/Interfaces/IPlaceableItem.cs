using UnityEngine;
/// <summary> Интерфейс, размещаемые айтемы инвентаря.</summary>
public interface IPlaceableItem
{
    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="position"> позиция для размещения.</param>
    /// <param name="parent"> Transform объекта в которой спавнится GameObject у PlacebleItem.</param>
    public Object Place(Vector3 position, Transform parent);
}