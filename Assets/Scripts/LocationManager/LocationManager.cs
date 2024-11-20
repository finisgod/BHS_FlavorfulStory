using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class LocationManager : MonoBehaviour
    {
        [SerializeField, Range(1f, 10f)] private float _radius;
        private GameObject _player;
        private Dictionary<GameObject, int> _objectsState;
        private GameObject[] _objects;
        
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
            _objects = GameObject.FindGameObjectsWithTag("Interactable");
        }

        private void Start()
        {
            if (_objectsState == null)
            {   
                _objectsState = new Dictionary<GameObject, int>();

                foreach (GameObject gameObj in _objects)
                {
                    _objectsState.Add(gameObj, 0);
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                Interact();
        }


        private void Interact()
        {
            if (_objects == null) return;

            GameObject nearestObject = FindNearestObject();
            if (nearestObject != null)
            {
                AppearanceSwitcher appearanceSwitcher = nearestObject.GetComponent<AppearanceSwitcher>();
                appearanceSwitcher.ChangePrefab();
            }
        }
        
        private GameObject FindNearestObject()
        {
            RaycastHit[] hits = Physics.SphereCastAll(_player.transform.position, _radius, Vector3.zero, _radius, LayerMask.GetMask("Interactable"));
            Debug.Log(hits.Length);
            
            
            float minDistance = _radius;
            GameObject closest = null;

            foreach (var hit in hits)
            {
                if (!_objects.Contains(hit.transform.gameObject)) continue;
                
                float distance = Vector3.Distance(hit.transform.position, _player.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closest = hit.transform.gameObject;
                }
            }

            if (closest != null)
            {
                Debug.Log(_objects.Length + ": " + closest.name);
                return closest;
            }

            Debug.Log(_objects.Length);
            return null;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_player.transform.position, _radius);
        }
    }
}