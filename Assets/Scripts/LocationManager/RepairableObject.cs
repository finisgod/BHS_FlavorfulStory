using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    /// <summary> Восстанавливающийся объект.</summary>
    public class RepairableObject : InteractableObject
    {
        /// <summary> Взаимодействие.</summary>
        public override void Interact()
        {
            base.Interact();
            Debug.Log("Interacting with repairable object " + gameObject.name);
        }
    }
}