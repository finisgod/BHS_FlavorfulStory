using System;
using UnityEngine;

public class AgricultureObject : Object, IAgricultureObject, IToolPickableObject, IItemProduceable
{
    [SerializeField] public GameObject[] prefabStates;
    private int _growDays = 0;
    private double _startWorldTime = 0;
    private bool _isGrown = false;
    private double _goalGrowTime = 10000.0;
    private double _currentGrowTime = 0;
    private GameObject _stateObject;
    private int _currentStateIndex;
    //public double GoalGrowTime { get { return _goalGrowTime; } }
    public double CurrentGrowTime { get { return _currentGrowTime; } set { _currentGrowTime = value; } }
    public bool IsGrown { get { return _isGrown; } }
    public bool IsCanGrow { get; set; }
    public AgricultureObject(string name) : base(name)
    {
    }
    public void Start()
    {
        _currentStateIndex = 0;
        _goalGrowTime = 10000.0; //вынести в базовую инициализацию
        _startWorldTime = WorldTime.GetCurrentTime();
        _stateObject = Instantiate(prefabStates[0], this.gameObject.transform);
    }
    public void Update()
    {
        if (prefabStates.Length > 0)
        {
            int index = (int)Math.Floor(_currentGrowTime / (_goalGrowTime/prefabStates.Length));
            if (index != _currentStateIndex)
            {
                _currentStateIndex = index;
                if (_currentStateIndex < prefabStates.Length)
                {
                    if(_stateObject) Destroy(_stateObject);
                    _stateObject = Instantiate(prefabStates[index], this.gameObject.transform);
                }
            }
        }
        double delta = WorldTime.GetCurrentTime() - _startWorldTime;
        if(IsCanGrow)  CurrentGrowTime += WorldTime.Instance.Tick; //Доделать с днями
        if (CurrentGrowTime > _goalGrowTime) { _isGrown = true; AgricultureGrown.Invoke(); } //Убрать цикл
        Debug.Log(CurrentGrowTime.ToString());
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

