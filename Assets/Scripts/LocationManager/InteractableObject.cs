using System;
using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class InteractableObject : MonoBehaviour, IInteractable
    {
        private Outline _outline;
        private AppearanceSwitcher _appearanceSwitcher;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
            _appearanceSwitcher = transform.parent.GetComponent<AppearanceSwitcher>();
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

        public void Interact()
        {
            _appearanceSwitcher.ChangeAppearance();
        }
    }
}