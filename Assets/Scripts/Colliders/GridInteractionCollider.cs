using Assets.Scripts.Items.Instruments;
using FlavorfulStory.Control;
using System.Collections;
using UnityEngine;
/// <summary> Класс описывающий логику расстановки предметов по сетке ObjectGrid.</summary>
///<remarks> Вешается на объект - сетку объектов для размещения предметов при помощи указателя мыши.</remarks>

//Переписать этот позор

public class GridInteractionCollider : MonoBehaviour //Разнести логику по разным сеткам //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary> Менеджер сетки Grid.</summary>
    [SerializeField] GridTargetManager _gridTargetManager;

    /// <summary> Флаг режима установки.</summary>
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

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other) //Разнести логику по классам. 
    {
        _gridTargetManager.gameObject.SetActive(true);
        _gridTargetManager.HighlightTile();
        //if (selectedTile != null) Debug.Log("Founded tile");
        ObjectGrid grid = this.gameObject.GetComponent<ObjectGrid>();
        if (other.gameObject.tag == "Player")
        {
            InventoryManager manager = other.GetComponentInChildren<InventoryManager>();
            //if (Input.GetKeyDown((KeyCode)UserKeys.StartPlaceObject)) //ToDo: Унести все клавиши в отдельный класс
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
                    //Логика размещения айтема                    
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
    public IEnumerator MiningAnimationCoroutine(   //PlayerAnimationController controller //Упростить
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

    /// <summary>Метод вызывающийся при выходе из коллайдера объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerExit(Collider other)
    {
        _gridTargetManager.gameObject.SetActive(false); //не работает
    }
}