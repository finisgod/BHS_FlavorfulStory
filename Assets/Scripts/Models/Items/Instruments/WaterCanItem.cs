using UnityEngine;

namespace Assets.Scripts.Items.Instruments
{
    public class WaterCanItem : ToolItem
    {
        private readonly double _pourDuration = 5000;
        //public WaterCanItem() : base() { }
        public WaterCanItem() : base("WaterCan") { }
        public override void UseLkm(object sender, IUsableItemArgs args)
        {
            if (args is ToolItemArgs && sender is FarmTile)
            {
                FarmTile farmTile = sender as FarmTile;
                ToolItemArgs toolItemArgs = args as ToolItemArgs; //ToDo: проверка на null
                if (farmTile != null)
                {
                    farmTile.Pour(_pourDuration);
                }
                //Debug.Log("WaterCanItem lkm");
            }
        }
        public override void UsePkm(object sender, IUsableItemArgs args)
        {
            if (args is ToolItemArgs)
            {
                //Debug.Log("WaterCanItem pkm");
            }
        }
    }
}

