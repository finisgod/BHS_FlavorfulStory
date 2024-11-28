using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class InteractWithObjects : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)] private float _radius;
        [SerializeField] private KeyCode _interactKey = KeyCode.E;
        private InteractableObject _currentTarget;

        private void Update()
        {
            if (_currentTarget) _currentTarget.SwitchOutline(false);
            
            _currentTarget = FindTarget();
            
            if (_currentTarget) _currentTarget.SwitchOutline(true);
            
            if (Input.GetKeyDown(_interactKey) || Input.GetMouseButtonDown(0))
            {
                if (CanInteract()) _currentTarget.Interact();
            }
        }
        
        private InteractableObject FindTarget()
        {
            InteractableObject target = GetCursorTarget();
            if (!target)
            {
                var nearbyInteractables = GetNearbyObjects();
                if (nearbyInteractables.Count() > 0)
                    target = GetClosestInteractable(nearbyInteractables);
            }
            return target;
        }
        
        private InteractableObject GetCursorTarget()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bool isHit = Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity,
                LayerMask.GetMask("Interactable"));
            return isHit ? hitInfo.collider.GetComponent<InteractableObject>() : null;
        }
        
        private IEnumerable<InteractableObject> GetNearbyObjects()
        {
            RaycastHit[] hits = Physics.SphereCastAll(
                transform.position, 
                _radius,
                Vector3.one,
                0,
                LayerMask.GetMask("Interactable")
            );
            return hits.Select(hit => hit.collider.GetComponent<InteractableObject>());
        }
        
        private InteractableObject GetClosestInteractable(IEnumerable<InteractableObject> interactables)
        {
            InteractableObject closest = null;
            float minDistance = float.MaxValue;
            foreach (var interactable in interactables)
            {
                float distance = Vector3.Distance(transform.position, interactable.transform.position);
                if (distance >= minDistance) continue;
                
                minDistance = distance;
                closest = interactable;
            }
            return closest;
        }
        
        private bool CanInteract() => 
            _currentTarget && Vector3.Distance(transform.position, _currentTarget.transform.position) <= _radius;

        private void OnDrawGizmos()
        {
            var player = GameObject.FindGameObjectWithTag("Player");
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(player.transform.position, _radius);
        }
    }
}