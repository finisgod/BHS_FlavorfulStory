using UnityEngine;

/// <summary> Класс используемого айтема.</summary>
public class UsableItem : Item, IUsableItem
{
    public UsableItem() : base() { }
    public UsableItem(string name) : base(name) { }
    public void UseLkm(object sender , IUsableItemArgs args)
    {
        Debug.Log("LKM used on: " + Name);
    }
    public void UsePkm(object sender, IUsableItemArgs args)
    {
        Debug.Log("PKM used on: " + Name);
    }

}