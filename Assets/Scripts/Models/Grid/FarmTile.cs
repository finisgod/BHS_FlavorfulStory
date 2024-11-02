using Assets.Scripts.Models.Objects.GameObjects;
using System;
using UnityEngine;

/// <summary>  ласс €чейки сетки дл€ огорода.</summary>
public class FarmTile : Tile
{
    private bool isAgricultureTaken = false;
    public void Start()
    {
        IsGrown = false;
    }
    /// <summary> ћетод дл€ подписки на эвент созревани€ агрокультуры.</summary>
    public void SubscribeToAgriculture()
    {
        if (TileObject != null)
        {
            AgricultureObject agricultureObject = TileObject as AgricultureObject;
            agricultureObject.AgricultureGrown += AgricultureGrown;
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            IsBisy = true;
            IsGrown = false;
        }
    }
    public bool IsGrown
    {
        get; set;
    }
    public AgricultureObject GetAgriculture() //ToDo
    {
        if (TileObject != null)
        {
            AgricultureObject agricultureObject = TileObject as AgricultureObject;
            agricultureObject.AgricultureGrown -= AgricultureGrown;
            TileObject = null;
            IsBisy = false;
            isAgricultureTaken = true;
            return agricultureObject;
        }
        return null;
    }
    /// <summary> ћетод , вызывающийс€, когда агрокультура созреет.</summary>
    private void AgricultureGrown()
    {
        if (!isAgricultureTaken)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            IsGrown = true;
        }
    }
}