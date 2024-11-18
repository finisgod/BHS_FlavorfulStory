using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class LocationManager : MonoBehaviour
    {
        [SerializeField] private AppearanceSwitcher[] _interactableObjects;

        private GameObject _player;
        
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player");
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
                Interact();
        }


        private void Interact()
        {
            if (_interactableObjects == null) return;

            foreach (var interactableObject in _interactableObjects)
            {
                if (Vector3.Distance(_player.transform.position, interactableObject.transform.position) < 3)
                {
                    interactableObject.ChangePrefab();
                }
            }
        }
    }
}