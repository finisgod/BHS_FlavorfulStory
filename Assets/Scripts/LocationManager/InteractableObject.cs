using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    [RequireComponent(typeof(Outline))]
    public class InteractableObject : MonoBehaviour
    {
        public Outline _outline;
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

        // private void Start()
        // {
        //     _outline.enabled = false;
        // }
        //
        // private void OnMouseEnter()
        // {
        //     _outline.enabled = true;
        // }
        
        // private void OnMouseExit()
        // {
        //     _outline.enabled = false;
        // }

        public virtual void Interact()
        {
            _appearanceSwitcher.ChangeAppearance();
        }
    }
}