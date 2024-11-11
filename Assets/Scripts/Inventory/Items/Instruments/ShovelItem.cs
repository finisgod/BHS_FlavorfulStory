using UnityEngine;


public class ShovelItem : ToolItem
{
    public ShovelItem() : base() { }
    public ShovelItem(string name) : base(name) { }
    public override void UseLkm(object sender, IUsableItemArgs args)
    {
        if (args is ToolItemArgs && sender is FarmTile)
        {
            FarmTile farmTile = sender as FarmTile;
            ToolItemArgs toolItemArgs = args as ToolItemArgs; //ToDo: проверка на null
            if (farmTile != null)
            {
                Object objectToPick = farmTile.TileObject;
                if (objectToPick != null)
                {
                    if (objectToPick is AgricultureObject)
                    {
                        Item item = ((AgricultureObject)objectToPick).PickByToolAndDestroy(this);
                        (args as ToolItemArgs).item = item;
                    }
                }
            }
            Debug.Log("Shovel lkm");
        }
    }
    public override void UsePkm(object sender, IUsableItemArgs args)
    {
        if (args is ToolItemArgs)
        {
            Debug.Log("Shovel pkm");
        }
    }
}

