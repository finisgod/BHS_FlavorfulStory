using UnityEngine;
/// <summary> Класс.</summary>
public class PlayerInitializer : MonoBehaviour //NotUsed
{
    public static PlayerInitializer Instance;

    public void Awake()
    {
        /*
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(Instance.gameObject);
        */
    }
}
