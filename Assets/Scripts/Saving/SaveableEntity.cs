using System.Collections.Generic;
using UnityEngine;

namespace FlavorfulStory.Saving
{
    /// <summary> Сохраняемый объект.</summary>
    [ExecuteAlways]
    public class SaveableEntity : MonoBehaviour
    {
        /// <summary> GUID.</summary>
        [SerializeField] private string _uniqueIdentifier;
        /// <summary> GUID.</summary>
        public string UniqueIdentifier => _uniqueIdentifier;

        /// <summary> Фиксация состояния объекта при сохранении.</summary>
        /// <returns> Возвращает объект, в котором фиксируется состояние.</returns>
        public object CaptureState()
        {
            var state = new Dictionary<string, object>();
            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }
            return state;
        }

        /// <summary> Восстановление состояния объекта при загрузке.</summary>
        /// <param name="state"> Объект состояния, который необходимо восстановить.</param>
        public void RestoreState(object state)
        {
            var stateDict = state as Dictionary<string, object>;
            if (stateDict == null) return;

            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                string typeString = saveable.GetType().ToString();
                if (stateDict.ContainsKey(typeString))
                {
                    saveable.RestoreState(stateDict[typeString]);
                }
            }
        }

        #region Setting GUID
#if UNITY_EDITOR
        /// <summary> Глобальный словарь со всеми GUID на сцене.</summary>
        private static readonly Dictionary<string, SaveableEntity> _globalLookup = new();

        /// <summary> Является ли объект префабом?</summary>
        /// <remarks> В префабах не должен выставляться GUID.</remarks>
        private bool IsPrefab => string.IsNullOrEmpty(gameObject.scene.path);

        /// <summary> Установка GUID.</summary>
        private void Update()
        {
            if (Application.IsPlaying(gameObject) || IsPrefab) return;
            SetUniqueIdentifier();
        }

        /// <summary> Выставление GUID сущности на сцене.</summary>
        private void SetUniqueIdentifier()
        {
            var serializedObject = new UnityEditor.SerializedObject(this);
            var property = serializedObject.FindProperty(nameof(_uniqueIdentifier));
            if (string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }
            _globalLookup[property.stringValue] = this;
        }

        /// <summary> Является ли GUID уникальным?</summary>
        /// <param name="candidate"> Кандидат для проверки.</param>
        /// <returns> Возвращает True - если GUID является уникальным, False - в противном случае.</returns>
        private bool IsUnique(string candidate)
        {
            if (!_globalLookup.ContainsKey(candidate) || _globalLookup[candidate] == this)
                return true;

            if (_globalLookup[candidate] == null 
                || _globalLookup[candidate].UniqueIdentifier != candidate)
            {
                _globalLookup.Remove(candidate);
                return true;
            }
            return false;
        }
#endif
        #endregion
    }
}