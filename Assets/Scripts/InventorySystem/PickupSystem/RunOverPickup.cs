using UnityEngine;

namespace FlavorfulStory.InventorySystem.PickupSystem
{
    [RequireComponent(typeof(Pickup))]
    public class RunOverPickup : MonoBehaviour
    {
        /// <summary> �����, ������������ ��� ����������� � ����������� ������� �������.</summary>
        /// <param name="other"> ��������� ��������� �������.</param>
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var pickup = GetComponent<Pickup>();
                if (pickup.CanBePickedUp) pickup.PickupItem();
            }
        }
    }
}
