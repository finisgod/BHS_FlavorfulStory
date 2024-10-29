using UnityEngine;

namespace FlavorfulStory.Inventory.PickupSystem
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
                GetComponent<Pickup>().PickUpItem();
            }
        }
    }
}
