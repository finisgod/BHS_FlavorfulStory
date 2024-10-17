using UnityEngine;
/// <summary> Класс, описывающий логику поворота NPC к главному персонажу при встрече.</summary>
public class FaceToFaceCollider : MonoBehaviour //все коллайдеры оптимизировать. Много лишних действий в OnTriggerEnter / Stay
{
    /// <summary>RigidBody принадлежащий NPC .</summary>
    [SerializeField] Rigidbody rb;

    /// <summary>Скорость вращения NPC .</summary>
    [SerializeField] float rotationSpeed;

    /// <summary>Объект NPC.</summary>
    [SerializeField] Npc npc;

    /// <summary>Метод вызывающийся при нахождении в коллайдере объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npc.StopMoving();
            Vector3 dir = other.gameObject.transform.position - this.gameObject.transform.position;
            float angle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            rb.gameObject.transform.rotation = Quaternion.Lerp(rb.rotation, rotation, rotationSpeed * Time.deltaTime);         
        }
    }
    /// <summary>Метод вызывающийся при выходе из коллайдера объекта на котором этот скрипт висит .</summary>
    /// <param name="other"> Коллайдер входящего объекта.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            npc.StartMoving();
        }
    }
}