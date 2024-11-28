using FlavorfulStory.Saving;
using UnityEngine;

namespace FlavorfulStory.LocationManager
{
    public class AppearanceSwitcher : MonoBehaviour, ISaveable
    {
        private InteractableObject[] _gameObjects;
        private int _currentStateIndex;
        
        private void Awake()
        {
            _gameObjects = GetComponentsInChildren<InteractableObject>(true);
            _currentStateIndex = 0;
        }

        public void ChangeAppearance()
        {
            _currentStateIndex = Mathf.Clamp(_currentStateIndex + 1, 0, _gameObjects.Length - 1);
            SetAppearance(_currentStateIndex);
        }

        private void SetAppearance(int stateIndex)
        {
            foreach (var state in _gameObjects)
            {
                state.gameObject.SetActive(false);
            }
            
            _gameObjects[stateIndex].gameObject.SetActive(true);
        }

        #region Saving
        public object CaptureState() => _currentStateIndex;

        public void RestoreState(object state)
        {
            _currentStateIndex = (int)state;
            SetAppearance(_currentStateIndex);
        }
        #endregion
    }
}