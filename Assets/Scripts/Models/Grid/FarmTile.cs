using Assets.Scripts.Items.Instruments;
using Assets.Scripts.Models.Objects.GameObjects;
using System;
using System.Collections;
using System.Xml.Schema;
using UnityEngine;

/// <summary> Класс ячейки сетки для огорода.</summary>
public class FarmTile : Tile
{
    private bool _isAgricultureTaken = false;
    private bool _isPour = false;
    public void Start()
    {
        IsGrown = false;
        IsNeedToHighlight = true;
    }

    public FarmTile() : base()
    {
        IsNeedToHighlight = true;
    }

    /// <summary> Метод для подписки на эвент созревания агрокультуры.</summary>
    public void SubscribeToAgriculture()
    {
        if (TileObject != null)
        {
            AgricultureObject agricultureObject = TileObject as AgricultureObject;
            agricultureObject.AgricultureGrown += AgricultureGrown;
            IsBisy = true;
            IsNeedToHighlight = false;
            IsGrown = false;
            if (_isPour)
            {
                agricultureObject.IsCanGrow = true;
            }
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
    }
    public bool IsGrown
    {
        get; set;
    }
    public bool IsPour
    {
        get { return _isPour; }
        set { _isPour = value; }
    }
    public AgricultureObject GetAgriculture() //ToDo
    {
        if (TileObject != null)
        {
            AgricultureObject agricultureObject = TileObject as AgricultureObject;
            agricultureObject.AgricultureGrown -= AgricultureGrown;
            TileObject = null;
            IsBisy = false;
            IsNeedToHighlight = true;
            _isAgricultureTaken = true;
            return agricultureObject;
        }
        return null;
    }

    public void Pour(double pourDuration)
    {
        StartCoroutine(PourTimerCoroutine(pourDuration));
    }

    /// <summary> Метод , вызывающийся, когда агрокультура созреет.</summary>
    private void AgricultureGrown()
    {
        if (!_isAgricultureTaken)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            IsGrown = true;
        }
    }

    //Coroutines
    public IEnumerator PourTimerCoroutine(double pourDuration) //Много цветовых затычек для наглядности
    {
        //Debug.Log("Pour started");
        Color baseColor = this.gameObject.GetComponent<MeshRenderer>().material.color;
        _isPour = true;
        IsNeedToHighlight = false;

        AgricultureObject agricultureObject = null;
        if (TileObject != null)
        {
            agricultureObject = TileObject as AgricultureObject;
            agricultureObject.IsCanGrow = true;
        }

        if (!IsBisy || baseColor == Color.yellow) { this.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue; };

        double startTime = WorldTime.GetCurrentTime();
        double deltaTime = 0;
        while (deltaTime < pourDuration)
        {
            deltaTime = WorldTime.GetCurrentTime() - startTime;
            yield return null;
        }
        _isPour = false;

        if (agricultureObject != null)
        {
            agricultureObject.IsCanGrow = false;
        }

        if (!IsBisy)
        {
            this.gameObject.GetComponent<MeshRenderer>().material.color = Color.black;
            IsNeedToHighlight = true;
        }
        else
        {
            if (agricultureObject != null)
            {
                if (!agricultureObject.IsGrown)
                {
                    this.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                }
                else
                {
                    this.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                }
            }
        }
        //Debug.Log("Pour ended");
    }
}