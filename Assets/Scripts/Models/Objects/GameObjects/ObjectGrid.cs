using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary> �����, ����������� ����� ��� ���������� ��������.</summary>
public class ObjectGrid : MonoBehaviour
{
    /// <summary> ������ �����.</summary>
    [SerializeField] int Width;
    /// <summary> ����� �����.</summary>
    [SerializeField] int Length;
    /// <summary> ������ ������ �����.</summary>
    [SerializeField] int TileSize;
    /// <summary> ������ �����.</summary>
    [SerializeField] GameObject _gridPrefab;
    /// <summary> ������ ������.</summary>
    [SerializeField] GameObject _tilePrefab;
    /// <summary> ������� ������ ����� ��� ����������.</summary>
    private Grid grid;
    /// <summary> ������ �����.</summary>
    public GameObject[,] tiles;

    /// <summary> ��� �����.</summary>
    public Grid.GridType GridType;
    /// <summary> ������� ����� �����.</summary>
    private Dictionary<Grid.GridType, Type> _tyleTypes = new Dictionary<Grid.GridType, Type> {
        {Grid.GridType.Placeable , typeof(PlaceableTile) },
        {Grid.GridType.Farm , typeof(FarmTile) }
    };

    /// <summary> ����� ��� ������������� �����. ���������� ��� ��������� �������.</summary>
    private void Start()
    {
        grid = new Grid(Width, Length, TileSize, _tyleTypes[GridType]);
        tiles = new GameObject[Width, Length];
        int currLine = 0;
        int currVert = 0;
        this.transform.localScale = new Vector3(Width, 0.1f, Length);
        float deltaX = this.transform.localScale.x;
        float deltaZ = this.transform.localScale.z;
        foreach (var tile in grid.GetTiles())
        {
            GameObject TileObj = Instantiate(_tilePrefab);
            tiles[currLine, currVert] = TileObj;
            float tileX = TileObj.transform.lossyScale.x;
            float tileZ = TileObj.transform.lossyScale.z;
            TileObj.transform.parent = this.transform;
            TileObj.transform.position = TileObj.transform.parent.position + new Vector3(currLine - deltaX / 2 + tileX / 2, 0, currVert - deltaZ / 2 + tileZ / 2);
            if (currLine < Width - 1) currLine++;
            else { currVert++; currLine = 0; }
        }
    }
}