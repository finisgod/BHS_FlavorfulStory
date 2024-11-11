using UnityEngine;


public class DigItem : ToolItem
{
    public DigItem() : base() { }
    public DigItem(string name) : base(name) { }
    public override void UseLkm(object sender, IUsableItemArgs args)
    {
        if (args is ToolItemArgs && sender is FarmTile)
        {
            Debug.Log("DigItem lkm");
        }
    }
    public override void UsePkm(object sender, IUsableItemArgs args)
    {
        if (args is ToolItemArgs)
        {
            Debug.Log("DigItem pkm");
        }
    }
}

