using Assets.Scripts.Items.Instruments;
using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;
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
                //Debug.Log("CURRENT TILE OBJ NAME:" + currTileObj.name);
            }
        }
    }

    /// <summary>����� ������������ ��� ���������� � ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerStay(Collider other) //�������� ������ �� �������. 
    {
        _gridTargetManager.gameObject.SetActive(true);
        _gridTargetManager.HighlightTile();
        //if (selectedTile != null) //Debug.Log("Founded tile");
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
            Item interactionItem = null;
            if (Input.GetKeyDown((KeyCode)UserKeys.CommitPlaceObject) && (manager.GetAllInventoryItems().Count > 0))
            {
                interactionItem = manager.GetCurrentInventoryItem();
                Tile interactionTile = _gridTargetManager.GetSelectedTile();
                if (interactionTile is PlaceableTile)
                {
                    //������ ���������� ������                    
                    if (interactionItem is IPlaceableItem)
                    {
                        bool result = _gridTargetManager.PlaceOnGrid((IPlaceableItem)interactionItem, grid, interactionTile as PlaceableTile);
                        if (result) manager.RemoveFromInventory(interactionItem);
                    }
                    //End placing
                    //isPlacing = false;
                    //
                }
                if (interactionTile is FarmTile)
                {
                    FarmTile farmTile = interactionTile as FarmTile;
                    if (interactionItem is IAgricultureItem)
                    {
                        bool result = _gridTargetManager.PlantOnGrid((IAgricultureItem)interactionItem, grid, interactionTile as FarmTile);
                        if (result) manager.RemoveFromInventory(interactionItem);
                    }
                    //������ if'� � ��������� ����� - ��������
                    if (interactionItem is ShovelItem)
                    {
                        //run animation
                        if (farmTile.IsGrown && farmTile.IsBisy)
                        {
                            PlayerAnimationController animationController = other.GetComponent<PlayerAnimationController>();
                            StartCoroutine(MiningAnimationCoroutine(animationController, manager , 200, interactionItem as ShovelItem, farmTile));
                        }
                        //
                    }
                    if (interactionItem is WaterCanItem)
                    {
                        WaterCanItem waterCanItem = interactionItem as WaterCanItem;
                        ToolItemArgs args = new ToolItemArgs();
                        waterCanItem.UseLkm(interactionTile, args);
                    }
                }
                //}
            }
        }
    }
    //Coroutines
    public IEnumerator MiningAnimationCoroutine(PlayerAnimationController controller //���������
        , InventoryManager inventory
        , int timer
        , ShovelItem item
        , FarmTile tile)
    {
        if (!controller.isAnimated)
        {
            controller.SetAnimated(true);
            controller.SetTrigger("miningTrigger");
            for (int i = 0; i < timer; i++)
            {
                //Debug.Log(i.ToString());
                yield return null;
            }
            controller.SetAnimated(false);

            ToolItemArgs args = new ToolItemArgs();
            item.UseLkm(tile, args);
            tile.GetAgriculture();
            inventory.AddToInventory(args.item);
        }
    }

    /// <summary>����� ������������ ��� ������ �� ���������� ������� �� ������� ���� ������ ����� .</summary>
    /// <param name="other"> ��������� ��������� �������.</param>
    private void OnTriggerExit(Collider other)
    {
        _gridTargetManager.gameObject.SetActive(false); //�� ��������
    }
}