using UnityEngine;

/// <summary> Класс отвечающий за глобальное игровое время.</summary>
public class WorldTime : MonoBehaviour
{
    public static WorldTime Instance;
    [SerializeField] public float dayTime = 18000f;
    [SerializeField] public float nightTime = 72000f;
    [SerializeField] float tick = 100f;
    [SerializeField] float startTime; //86 400 sec in day
    static float currTime; //86 400 sec in day
    public static bool isDay = true;
    static bool isStarted = false;

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

    public delegate void DayEndHandler();
    public static event DayEndHandler DayEndedEvent;

}