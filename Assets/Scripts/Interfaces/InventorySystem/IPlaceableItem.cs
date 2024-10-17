using UnityEngine;
/// <summary> ���������, ����������� ������ ���������.</summary>
public interface IPlaceableItem
{
    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="position"> ������� ��� ����������.</param>
    /// <param name="parent"> Transform ������� � ������� ��������� GameObject � PlacebleItem.</param>
    public Object Place(Vector3 position, Transform parent);
}