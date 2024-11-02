using NPC;
using System.Collections;
using UnityEngine;
/// <summary> Класс, описывающий логику работы порталов.</summary>
public class InstancePortalCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary> Точка телепортации. </summary>
    [SerializeField] NPC.NpcPathPoint destination;
    /// <summary> Префаб загрузочного экрана.</summary>
    //[SerializeField] GameObject loadingScreen;
    /// <summary> Флаг завершения телепортации.</summary>
    public bool isTeleporting = false;

    /// <summary> Свойство, возвращающее точку телепортации.</summary>
    public NPC.NpcPathPoint Destination
    {
        get { return destination; }
    }

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isTeleporting)
            {
                if (destination != this.GetComponent<NpcPathPoint>())
                {
                    //StartCoroutine(LoadScreen());
                    destination.GetComponentInChildren<InstancePortalCollider>().isTeleporting = true;
                    other.GetComponentInChildren<Rigidbody>().MovePosition(destination.Coordinate);
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
            isTeleporting = false;
        }
    }

    /*
    /// <summary> Метод-корутина для включения загрузочного экрана.</summary>
    IEnumerator LoadScreen()
    {
        float Duration = 2;
        float LoadScreenTimer = 0;
        loadingScreen.SetActive(true);
        while (LoadScreenTimer < Duration)
        {
            //Debug.Log("CORUTINE STARTED");
            LoadScreenTimer++;
            yield return new WaitForSeconds(1f);
        }
        //Debug.Log("CORUTINE ENDED");
        loadingScreen.SetActive(false);
    }
    */
}