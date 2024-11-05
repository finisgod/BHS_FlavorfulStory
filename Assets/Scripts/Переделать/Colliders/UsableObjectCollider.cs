using UnityEngine;
/// <summary>Класс описывающий коллайдер для взаимодействия с интерактивным объектом.</summary>
public class UsableObjectCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stating");
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("IsPlayer");
            if (Input.GetKeyDown((KeyCode)UserKeys.UseObject))
            {
                IUsableObject obj = this.gameObject.GetComponent<IUsableObject>();
                obj.Use();
                //Debug.Log(obj != null);
            }
        }
    }
}