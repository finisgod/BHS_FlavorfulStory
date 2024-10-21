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
    [SerializeField] float tick = 100f;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] float startTime; //86 400 sec in day

    /// <summary>
    /// 
    /// </summary>
    static float currTime; //86 400 sec in day

    /// <summary>
    /// 
    /// </summary>
    public static bool isDay = true;

    /// <summary>
    /// 
    /// </summary>
    static bool isStarted = false;

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
            currTime = startTime;
        }

        DontDestroyOnLoad(Instance.gameObject);

        if (currTime < dayTime || currTime > nightTime) { isDay = false; }
        else { isDay = true; }
    }
    public void Update()
    {
        //consts
        float dayInterval = nightTime - dayTime;
        float nightInterval = 86400 - dayInterval; //ToDo: Убрать хардкод
        float nightTickMultiplier = dayInterval / nightInterval;
        //

        currTime += tick;

        if (currTime < dayTime || currTime > nightTime) { isDay = false; }
        else { isDay = true; }

        if (currTime > 86400) { currTime = 0; DayEndedEvent?.Invoke(); }
    }

    public static float GetCurrentTime()
    {
        return currTime;
    }

    #region Saving
    public object CaptureState() => currTime;

    public void RestoreState(object state)
    {
        print((float)state);
        currTime = (float)state;
    }
    #endregion
}