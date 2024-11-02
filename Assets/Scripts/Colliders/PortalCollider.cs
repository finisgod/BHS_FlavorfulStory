using System.Collections;
using UnityEngine;
/// <summary> Класс, описывающий логику работы порталов.</summary>
public class PortalCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary> Точка телепортации. </summary>
    [SerializeField] PathPoint destination;
    /// <summary> Префаб загрузочного экрана.</summary>
    [SerializeField] GameObject loadingScreen;
    /// <summary> Свойство, возвращающее точку телепортации.</summary>
    public PathPoint Destination { get { return destination; } }
    /// <summary> Id портала .</summary>
    public int id = 0;
    /// <summary> Флаг завершения телепортации.</summary>
    public bool isTeleporting = false;
    /// <summary> Флаг завершения телепортации NPC.</summary>
    public bool isNpcTeleporting = false;

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isTeleporting)
            {
                if (destination != this.GetComponent<PathPoint>())
                {
                    StartCoroutine(LoadScreen());
                    destination.GetComponentInChildren<PortalCollider>().isTeleporting = true;
                    other.GetComponentInChildren<Rigidbody>().MovePosition(destination.GetPosition());
                }
            }
        }
        if (other.gameObject.tag == "Npc")
        {
            Npc npc = other.GetComponentInChildren<Npc>();
            if (!isNpcTeleporting)
            {
                if (destination != this.GetComponent<PathPoint>())
                {
                    Debug.Log("NPC TELEPORT " + id.ToString());
                    destination.GetComponentInChildren<PortalCollider>().isNpcTeleporting = true;
                    //other.transform.position = destination.GetPosition();
                    npc.MoveByPathPoint(destination);
                }
            }
        }
    }

    /// <summary>Метод вызывающийся при выходе из коллайдера объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Trigger exit!! id:" +  id.ToString());
            isTeleporting = false;
        }
        if (other.gameObject.tag == "Npc")
        {
            Debug.Log("Trigger npc exit!! id:" + id.ToString());
            isNpcTeleporting = false;
        }
    }
    /// <summary> Метод-корутина для включения загрузочного экрана.</summary>
    IEnumerator LoadScreen()
    {
        float Duration = 2;
        float LoadScreenTimer = 0;
        loadingScreen.SetActive(true);
        while (LoadScreenTimer < Duration)
        {
            Debug.Log("CORUTINE STARTED");
            LoadScreenTimer++;
            yield return new WaitForSeconds(1f);
        }
        Debug.Log("CORUTINE ENDED");
        loadingScreen.SetActive(false);
    }
}