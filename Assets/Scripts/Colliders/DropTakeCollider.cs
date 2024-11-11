using UnityEngine;
/// <summary> Класс, описывающий логику подбора айтемов.</summary>
///<remarks> Вешается на айтем, который можно подобрать. При нахождении рядом с айтемом тот начнет притягиваться к игроку.</remarks>
public class DropTakeCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary> Скорость с которой айтем притягивается к персонажу.</summary>
    private int speed = 70;
    /// <summary> Минимальное расстояние для притягивания предмета.</summary>
    private double distance = 0.10;

    /// <summary> Триггер при нахождении в коллайдере, прикрепленном к объекту. Срабатывает притягивание айтема</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 targetDirection = other.transform.position - transform.position;
            this.gameObject.transform.position += targetDirection / speed;
            if ((gameObject.transform.position - other.transform.position).magnitude < distance)
            {
                InventoryManager manager = other.GetComponentInChildren<InventoryManager>();
                IPickableObject obj = this.gameObject.GetComponent<IPickableObject>();
                Item item = obj.PickAndDestroy();
                manager.AddToInventory(item);
            }
        }
    }
}