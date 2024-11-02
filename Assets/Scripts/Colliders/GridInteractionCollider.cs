using Assets.Scripts.Items.Instruments;
using System.Collections;
using UnityEngine;
using static UnityEditor.Progress;
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
                //Debug.Log("CURRENT TILE OBJ NAME:" + currTileObj.name);
            }
        }
    }

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other) //Разнести логику по классам. 
    {
        _gridTargetManager.gameObject.SetActive(true);
        _gridTargetManager.HighlightTile();
        //if (selectedTile != null) //Debug.Log("Founded tile");
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
            Item interactionItem = null;
            if (Input.GetKeyDown((KeyCode)UserKeys.CommitPlaceObject) && (manager.GetAllInventoryItems().Count > 0))
            {
                interactionItem = manager.GetCurrentInventoryItem();
                Tile interactionTile = _gridTargetManager.GetSelectedTile();
                if (interactionTile is PlaceableTile)
                {
                    //Логика размещения айтема                    
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
                    //Убрать if'ы в отдельный класс - дженерик
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
    public IEnumerator MiningAnimationCoroutine(PlayerAnimationController controller //Упростить
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

    /// <summary>Метод вызывающийся при выходе из коллайдера объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerExit(Collider other)
    {
        _gridTargetManager.gameObject.SetActive(false); //не работает
    }
}