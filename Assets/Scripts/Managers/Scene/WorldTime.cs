using FlavorfulStory.Saving;
using UnityEngine;

/// <summary> Глобальное игровое время.</summary>
public class WorldTime : MonoBehaviour, ISaveable
{
    /// <summary>
    /// 
    /// </summary>
    public static WorldTime Instance;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] public float dayTime = 18000f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] public float nightTime = 72000f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float tick = 100f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float startTime; //86 400 sec in day

    /// <summary>
    /// 
    /// </summary>
    private static float _currentTime; //86 400 sec in day

    /// <summary>
    /// 
    /// </summary>
    public static bool isDay = true;

    /// <summary>
    /// 
    /// </summary>
    public delegate void DayEndHandler();

    /// <summary>
    /// 
    /// </summary>
    public static event DayEndHandler DayEndedEvent;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            _currentTime = startTime;
        }

        DontDestroyOnLoad(Instance.gameObject);

        if (_currentTime < dayTime || _currentTime > nightTime) { isDay = false; }
        else { isDay = true; }
    }

    public void Update()
    {
        //consts
        float dayInterval = nightTime - dayTime;
        float nightInterval = 86400 - dayInterval; //ToDo: Убрать хардкод
        float nightTickMultiplier = dayInterval / nightInterval;
        //

        _currentTime += tick;

        if (_currentTime < dayTime || _currentTime > nightTime) isDay = false;
        else isDay = true;

        if (_currentTime > 86400) 
        { 
            _currentTime = 0;
            DayEndedEvent?.Invoke(); 
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static float GetCurrentTime()
    {
        return _currentTime;
    }

    #region Saving
    public object CaptureState() => _currentTime;

    public void RestoreState(object state) => _currentTime = (float)state;
    #endregion
}