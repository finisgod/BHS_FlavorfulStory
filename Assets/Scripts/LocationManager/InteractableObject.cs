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
            _appearanceSwitcher = GetComponentInParent<AppearanceSwitcher>();
        }

        private void Start()
        {
            _outline.enabled = false;
        }

        private void OnMouseEnter()
        {
            _outline.enabled = true;
        }

        private void OnMouseDown()
        {
            Interact();
        }

        private void OnMouseExit()
        {
            _outline.enabled = false;
        }

        protected virtual void Interact()
        {
            _appearanceSwitcher.ChangeAppearance();
        }
    }
}