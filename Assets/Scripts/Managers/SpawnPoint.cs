using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPoint : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("SPAWN POINT");
        GameObject[] objOnScene = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject obj in objOnScene)
        {
            if (obj.tag == "Player")
            {
                obj.transform.position = this.gameObject.transform.position;
                Player player = obj.GetComponentInChildren<Player>();
                player.gameObject.transform.position = this.transform.position;
                player.spawnPosition = this.transform.position;
                player.ToSpawn();
                Debug.Log("INITIALIZED POSITION");
            }
        }
    }
}