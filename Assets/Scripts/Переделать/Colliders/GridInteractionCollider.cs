using Assets.Scripts.Items.Instruments;
using FlavorfulStory.Control;
using System.Collections;
using UnityEngine;
/// <summary> ����� ����������� ������ ����������� ��������� �� ����� ObjectGrid.</summary>
///<remarks> �������� �� ������ - ����� �������� ��� ���������� ��������� ��� ������ ��������� ����.</remarks>

//���������� ���� �����

public class GridInteractionCollider : MonoBehaviour //�������� ������ �� ������ ������ //��� ���������� ��������������. ����� ������ �������� � OnTriggerEnter / Stay
{
    /// <summary> �������� ����� Grid.</summary>
    [SerializeField] GridTargetManager _gridTargetManager;

    /// <summary> ���� ������ ���������.</summary>
    //bool isPlacing = false; //ToDo: ->property
    private Tile selectedTile = null;
    public Tile CurrentTile { get { return selectedTile; } }

    public void Update()
    {
        if (CurrentTile != null)
        {
            Object currTileObj = CurrentTile.TileObject;
            if (currTileObj != null)
            {
                Debug.Log("CURRENT TILE OBJ NAME:" + currTileObj.name);
            }
        }
    }

    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other) //�������� ������ �� �������. 
    {
        _gridTargetManager.gameObject.SetActive(true);
        _gridTargetManager.HighlightTile();
        //if (selectedTile != null) Debug.Log("Founded tile");
        ObjectGrid grid = this.gameObject.GetComponent<ObjectGrid>();
        if (other.gameObject.tag == "Player")
        {
            InventoryManager manager = other.GetComponentInChildren<InventoryManager>();
            //if (Input.GetKeyDown((KeyCode)UserKeys.StartPlaceObject)) //ToDo: ������ ��� ������� � ��������� �����
            //{
            //    {
            //        isPlacing = true;
            //    }
            //}
            //if (isPlacing)
            //{
            Item itemToPlace = null;
            if (Input.GetKeyDown((KeyCode)UserKeys.CommitPlaceObject) && (manager.GetAllInventoryItems().Count > 0))
            {
                itemToPlace = manager.GetCurrentInventoryItem();
                Tile tileToPlace = _gridTargetManager.GetSelectedTile();
                if (tileToPlace is PlaceableTile)
                {
                    //������ ���������� ������                    
                    if (itemToPlace is IPlaceableItem)
                    {
                        bool result = _gridTargetManager.PlaceOnGrid((IPlaceableItem)itemToPlace, grid, tileToPlace as PlaceableTile);
                        if (result) manager.RemoveFromInventory(itemToPlace);
                    }
                    //End placing
                    //isPlacing = false;
                    //
                }
                if (tileToPlace is FarmTile)
                {
                    FarmTile farmTile = tileToPlace as FarmTile;
                    if (itemToPlace is IAgricultureItem)
                    {
                        bool result = _gridTargetManager.PlantOnGrid((IAgricultureItem)itemToPlace, grid, tileToPlace as FarmTile);
                        if (result) manager.RemoveFromInventory(itemToPlace);
                    }
                    if (itemToPlace is ShovelItem)
                    {
                        //run animation
                        if (farmTile.IsGrown && farmTile.IsBisy)
                        {
                            //PlayerAnimationController animationController = other.GetComponent<PlayerAnimationController>();
                            StartCoroutine(MiningAnimationCoroutine(manager, 200, itemToPlace as ShovelItem, farmTile));
                            //animationController,

                        }
                        //
                    }
                }
                //}
            }
        }
    }
    //Coroutines
    public IEnumerator MiningAnimationCoroutine(   //PlayerAnimationController controller //���������
        InventoryManager inventory
        , int timer
        , ShovelItem item
        , FarmTile tile)
    {
        //if (!controller.isAnimated)
        //{
            //controller.SetAnimated(true);
          //  controller.SetTrigger("miningTrigger");
            for (int i = 0; i < timer; i++)
            {
                Debug.Log(i.ToString());
                yield return null;
            }
            //controller.SetAnimated(false);

            ToolItemArgs args = new ToolItemArgs();
            item.UseLkm(tile, args);
            tile.GetAgriculture();
            inventory.AddToInventory(args.item);
        //}
    }

    /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerExit(Collider other)
    {
        _gridTargetManager.gameObject.SetActive(false); //�� ��������
    }
}