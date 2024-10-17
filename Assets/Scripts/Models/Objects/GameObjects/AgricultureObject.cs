using Assets.Scripts.Interfaces.InventorySystem;
using Assets.Scripts.Items.Instruments;
using UnityEngine;
using Instruments = Assets.Scripts.Items.Instruments;

namespace Assets.Scripts.Models.Objects.GameObjects
{
    public class AgricultureObject : Object, IAgricultureObject, IToolPickableObject, IItemProduceable
    {
        private int _growDays = 0;
        private double _startWorldTime = 0;
        private bool _isGrown = false;
        private double _goalGrowTime = 10000.0;
        private double _currentGrowTime = 0;
        //public double GoalGrowTime { get { return _goalGrowTime; } }
        public double CurrentGrowTime { get { return _currentGrowTime; } set { _currentGrowTime = value; } }
        public bool IsGrown { get { return _isGrown; } }
        public AgricultureObject(string name) : base(name)
        {
        }
        public void Start()
        {
            _goalGrowTime = 10000.0; //вынести в базовую инициализацию
            _startWorldTime = WorldTime.GetCurrentTime();
        }
        public void Update()
        {
            double delta = WorldTime.GetCurrentTime() - _startWorldTime;

            //Debug.Log("START: " + _startWorldTime.ToString());

            CurrentGrowTime = delta; //Доделать с днями

            if (CurrentGrowTime > _goalGrowTime) { _isGrown = true; AgricultureGrown.Invoke(); } //Убрать цикл

            //Debug.Log(this.ObjectName + " Goal Grow time:" + _goalGrowTime.ToString());
            //Debug.Log(this.ObjectName + " Grow time:" + CurrentGrowTime.ToString());

        }
        public Item PickByToolAndDestroy(ToolItem tool)
        {
            if (IsGrown)
            {
                Destroy(this.gameObject);
                return GetComponentInParent<ItemObjectFactory>().ProduceItem(this);
            }
            else
                return null;
        }

        public delegate void AgricultureGrownHandler();
        public event AgricultureGrownHandler AgricultureGrown;
    }
}
