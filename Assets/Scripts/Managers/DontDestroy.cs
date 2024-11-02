using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public static DontDestroy Instance;
    public void Start()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}