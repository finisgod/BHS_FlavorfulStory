using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary> Класс в доработке.</summary>
public class PositionManager : MonoBehaviour
{
    [SerializeField] Player player;

    public static PositionManager Instance;
    public static Dictionary<string, Vector3> playerPosition = new Dictionary<string, Vector3>();
    public static void SavePlayerPosition(string sceneName, Vector3 position)
    {
        Debug.Log("SavePosition");
        if (playerPosition.ContainsKey(sceneName))
        {
            playerPosition[sceneName] = position;
        }
        else
        {
            playerPosition.Add(sceneName, position);
        }
    }

    public Vector3 GetPlayerPosition(string sceneName)
    {
        if (playerPosition.ContainsKey(sceneName))
        {
            return playerPosition[sceneName];
        }
        else return Vector3.zero;
    }
}