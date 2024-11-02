using UnityEngine;
/// <summary> Класс описывающий коллайдер-триггер для взаимодействия с интерактивным NPC.</summary>
public class InteractiveNpcCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Npc npc = this.GetComponent<Npc>(); //ToDo: Проверка на null
            if (npc is IIteractiveNpc)
            {
                (npc as IIteractiveNpc).Interact();
            }
        }
    }
}