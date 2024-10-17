using Assets.Scripts.Models.Objects.GameObjects;
using UnityEngine;
/// <summary> Класс, описывающий логику подбора объектов при нахождении рядом с IPickableObject.</summary>
///<remarks> Вешается на объект, который можно подобрать при нажатии на определенную клавишу.</remarks>
public class PickObjectCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    //
    private Object objectToPick = null;
    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InventoryManager manager = other.GetComponentInChildren<InventoryManager>(); //Получение инвентаря игрока. Убрать зацикливание и перезапись если не null
            if (objectToPick == null)
            {
                objectToPick = this.gameObject.GetComponent<Object>();
            }          
            if (Input.GetKeyDown(KeyCode.E)) //ToDo: Вынести за enum.
            {
                if (objectToPick is IPickableObject)
                {
                    Item item = ((IPickableObject)objectToPick).PickAndDestroy();
                    manager.AddToInventory(item);
                }
            }
        }
    }
    /// <summary>Метод вызывающийся при выходе из коллайдера объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerExit(Collider other)
    {
        objectToPick = null;
    }
}
