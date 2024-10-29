using UnityEngine;

namespace FlavorfulStory.Inventory.PickupSystem
{
    [RequireComponent(typeof(Pickup))]
    public class RunOverPickup : MonoBehaviour
    {
        /// <summary> Метод, вызывающийся при пересечении с коллайдером другого объекта.</summary>
        /// <param name="other"> Коллайдер входящего объекта.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GetComponent<Pickup>().PickUpItem();
            }
        }
    }
}
