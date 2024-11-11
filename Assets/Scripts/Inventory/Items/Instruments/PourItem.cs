using UnityEngine;


    public class PourItem : ToolItem
    {
        public PourItem() : base() { }
        public PourItem(string name) : base(name) { }
        public override void UseLkm(object sender, IUsableItemArgs args)
        {
            if (args is ToolItemArgs && sender is FarmTile)
            {
                Debug.Log("Pour lkm");
            }
        }
        public override void UsePkm(object sender, IUsableItemArgs args)
        {
            if (args is ToolItemArgs)
            {
                Debug.Log("Pour pkm");
            }
        }
    }

