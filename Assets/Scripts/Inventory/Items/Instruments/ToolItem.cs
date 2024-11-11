using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;


public class ToolItem : Item, IUsableItem
{
    public ToolItem() : base() { }
    public ToolItem(string name) : base(name) { }

    public virtual void UseLkm(object sender, IUsableItemArgs args) { }
    public virtual void UsePkm(object sender, IUsableItemArgs args) { }
}

public class ToolItemArgs : IUsableItemArgs
{
    public Item item = null;
}



