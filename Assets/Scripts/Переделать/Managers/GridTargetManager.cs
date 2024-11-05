using Unity.Burst.CompilerServices;
using UnityEngine;

/// <summary> �����, ����������� �������������� � ������ GridObject.</summary>
public class GridTargetManager : MonoBehaviour //ToDo: Create + GridGetTileManager to get Tile
{
    /// <summary> ������ ������.</summary>
    [SerializeField] Camera _camera;
    /// <summary> ���� ��� ��������.</summary>
    [SerializeField] LayerMask _layerMask;
    /// <summary> ������� ��� ���������� �� �����.</summary>
    private Vector3 _position;
    /// <summary> ������������ ������ �����.</summary>
    private GameObject highlightedTile = null;

    public void HighlightTile() //���������
    {
        //Debug.Log("GET SELECTED TILE");
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = _camera.nearClipPlane; //�������� ��-�� ����� ������ ������ � �� ������ �������� �� ������ ������
        Ray ray = _camera.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, _layerMask))
        {
            Tile selectedTile = null;
            _position = hit.point;
            if (hit.transform.CompareTag("Tile"))
            {
                Vector3 tilePos = hit.transform.gameObject.transform.position;
                if (highlightedTile != null)
                {
                    if (!highlightedTile.Equals(hit.transform.gameObject))
                    {
                        highlightedTile.TryGetComponent<Tile>(out selectedTile);
                        if (selectedTile != null)
                        {
                            if (!selectedTile.IsBisy)
                            {
                                highlightedTile.GetComponent<MeshRenderer>().material.color = Color.black;
                            }
                        }
                        highlightedTile = hit.transform.gameObject;
                    }
                }
                else
                {
                    highlightedTile = hit.transform.gameObject;
                }
                highlightedTile.TryGetComponent<Tile>(out selectedTile);
                if (selectedTile != null)
                {
                    if (!selectedTile.IsBisy)
                    {
                        hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    }
                }

                // Call SetColor using the shader property name "_Color" and setting the color to red
            }
        }
    }

    /// <summary> ����� ��� ��������� ��������� ��� ��������� �� �����.</summary>
    public Tile GetSelectedTile()
    {
        Tile selectedTile = null;
        highlightedTile.TryGetComponent<Tile>(out selectedTile);
        return selectedTile;
    }
    /// <summary> ����� ��� ��������� �� ����� grid.</summary>
    public bool PlaceOnGrid(IPlaceableItem item, ObjectGrid grid, PlaceableTile gridTile) //������� � ������ ����� Tile
    {
        PlaceableTile tile = gridTile;
        if (tile.TileObject == null)
        {
            tile.TileObject = item.Place(new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z), grid.gameObject.transform.parent);
            return true;
        }
        return false;
    }

    /// <summary> ����� ��� ��������� �� ����� grid.</summary>
    public bool PlantOnGrid(IAgricultureItem item, ObjectGrid grid, FarmTile gridTile) //������� � ������ ����� Tile
    {
        FarmTile tile = gridTile;
        if (tile.TileObject == null)
        {
            tile.TileObject = item.Plant(new Vector3(tile.transform.position.x, tile.transform.position.y, tile.transform.position.z), grid.gameObject.transform.parent);
            tile.SubscribeToAgriculture();
            return true;
        }
        return false;
    }
}