using UnityEngine;
/// <summary>Класс описывающий логику коллайдера у точки маршрута.</summary>
///<remarks> Является переключателем, для установки точки "достигнутой" .</remarks>
public class PathPointCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary>PathPoint на котором висит коллайдер.</summary>
    PathPoint PathPoint;

    /// <summary>Метод вызывающийся при старте скрипта.</summary>
    public void Start()
    {
        PathPoint = GetComponent<PathPoint>(); 
    }

    /// <summary>Метод вызывающийся при входе в коллайдер объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerEnter(Collider other) //ToDo: Подумать как оставить все в 1 коллайдере
    {
        if (other.gameObject.tag == "Npc")
        {
            Npc npc = other.gameObject.GetComponent<Npc>();
            PathPoint.SetAcheved(npc.Name); //ToDo: Проверка на null
        }
    }

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Npc")
        {
            Npc npc = other.gameObject.GetComponent<Npc>();
            PathPoint.SetAcheved(npc.Name); //ToDo: Проверка на null
        }
    }
    
}