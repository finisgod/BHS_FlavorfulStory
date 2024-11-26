using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class RepairableObject : InteractableObject
    {
        public override void Interact()
        {
            Debug.Log("Interacting with repairable object " + gameObject.name);
            _appearanceSwitcher.ChangeAppearance();
        }
    }
}