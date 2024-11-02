using UnityEngine;

/// <summary> Интерфейс, описывающий интерактивные айтемы.</summary>
public interface IUsableItem
{
    void UseLkm(object sender , IUsableItemArgs args);
    void UsePkm(object sender, IUsableItemArgs args);
}