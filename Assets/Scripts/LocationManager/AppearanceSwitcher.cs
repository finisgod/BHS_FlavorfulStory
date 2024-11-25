using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class AppearanceSwitcher : MonoBehaviour
    {
        [SerializeField] private Transform[] _gameObjects;
        private int _currentStateIndex;
        
        private void Start()
        {
            _currentStateIndex = 0;
        }

        public void ChangeAppearance()
        {
            _gameObjects[_currentStateIndex].gameObject.SetActive(false);
            _currentStateIndex = _currentStateIndex == _gameObjects.Length - 1 ? _gameObjects.Length - 1 : _currentStateIndex + 1;
            _gameObjects[_currentStateIndex].gameObject.SetActive(true);
        }
    }
}