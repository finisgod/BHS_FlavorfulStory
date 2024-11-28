using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    [RequireComponent(typeof(Outline))]
    public class InteractableObject : MonoBehaviour
    {
        private Outline _outline;
        protected AppearanceSwitcher _appearanceSwitcher;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
            SwitchOutline(false);
            _appearanceSwitcher = GetComponentInParent<AppearanceSwitcher>();
        }

        public virtual void Interact()
        {
            _appearanceSwitcher.ChangeAppearance();
            print("Interacted");
        }

        public void SwitchOutline(bool enabled) => _outline.enabled = enabled;
    }
}