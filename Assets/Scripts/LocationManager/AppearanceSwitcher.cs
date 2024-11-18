using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class AppearanceSwitcher : MonoBehaviour
    {
        [SerializeField] private GameObject[] _prefabs;
        
        private GameObject _currentPrefab;
        private int _currentPrefabIndex;

        private void Start()
        {
            _currentPrefabIndex = 0;
            _currentPrefab = Instantiate(_prefabs[_currentPrefabIndex], transform.position, Quaternion.identity, transform);
        }

        public void ChangePrefab()
        {
            _currentPrefabIndex = _currentPrefabIndex == _prefabs.Length - 1 ? _prefabs.Length - 1 : _currentPrefabIndex + 1;
            
            Destroy(_currentPrefab);
            _currentPrefab = Instantiate(_prefabs[_currentPrefabIndex], transform.position, Quaternion.identity, transform);
        }
    }
}