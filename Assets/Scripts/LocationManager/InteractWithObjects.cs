using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class InteractWithObjects : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)] private float _radius;
        private GameObject _player;
        private List<InteractableObject> _nearbyInteractables;
        private InteractableObject _cursorTarget, _currentTarget;
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }
        
        private void Start()
        {
            _nearbyInteractables = new List<InteractableObject>();
        }

        private void Update()
        {
            CursorTracking();
            
            _nearbyInteractables = SphereTracking();
            
            Prioritise();
            
            if (_currentTarget != null)
            {
                _currentTarget._outline.enabled = true;
            }
            
            if (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))
            {
                if (_currentTarget != null && Vector3.Distance(transform.position, _currentTarget.transform.position) <= _radius)
                {
                    _currentTarget.Interact();
                }
            }
        }

        private void CursorTracking()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, LayerMask.GetMask("Interactable")))
            {
                InteractableObject target = hitInfo.collider.GetComponent<InteractableObject>();
                if (target != null)
                {
                    _cursorTarget = target; // Сохраняем объект, на который наведён курсор
                }
            }
            else
            {
                _cursorTarget = null; // Если курсор ни на что не наведен
            }
        }

        private List<InteractableObject> SphereTracking()
        {
            RaycastHit[] hits = Physics.SphereCastAll(
                transform.position, 
                _radius,
                Vector3.one,
                0,
                LayerMask.GetMask("Interactable")
                );
            
            List<InteractableObject> interactables = new List<InteractableObject>();
            foreach (RaycastHit hit in hits)
            {
                InteractableObject interactable = hit.collider.gameObject.GetComponent<InteractableObject>();
                interactables.Add(interactable);
            }
            
            return interactables;
        }

        private void Prioritise()
        {
            if (_currentTarget != null)
                _currentTarget._outline.enabled = false;
            
            if (_cursorTarget != null)
            {
                _currentTarget = _cursorTarget;
            }
            else if (_nearbyInteractables.Count > 0)
            {
                _currentTarget = GetClosestInteractable(_nearbyInteractables);
            }
            else
            {
                _currentTarget = null;
            }
        }
        
        private InteractableObject GetClosestInteractable(List<InteractableObject> interactables)
        {
            InteractableObject closest = null;
            float minDistance = float.MaxValue;

            foreach (var interactable in interactables)
            {
                float distance = Vector3.Distance(transform.position, interactable.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = interactable;
                }
            }

            return closest;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_player.transform.position, _radius);
        }
    }
}