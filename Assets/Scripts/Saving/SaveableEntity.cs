using System.Collections.Generic;
using UnityEngine;

namespace FlavorfulStory.Saving
{
    /// <summary> ����������� ������.</summary>
    [ExecuteAlways]
    public class SaveableEntity : MonoBehaviour
    {
        /// <summary> GUID.</summary>
        [SerializeField] private string _uniqueIdentifier;

        /// <summary> GUID.</summary>
        public string UniqueIdentifier => _uniqueIdentifier;

        /// <summary> �������� ��������� ������� ��� ����������.</summary>
        /// <returns> ���������� ������, � ������� ����������� ���������.</returns>
        public object CaptureState()
        {
            var state = new Dictionary<string, object>();
            foreach (ISaveable saveable in GetComponents<ISaveable>())
            {
                state[saveable.GetType().ToString()] = saveable.CaptureState();
            }
            return state;
        }

        /// <summary> �������������� ��������� ������� ��� ��������.</summary>
        /// <param name="state"> ������ ���������, ������� ���������� ������������.</param>
        public void RestoreState(object state)
        {
            var stateDict = (Dictionary<string, object>)state;
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
        /// <summary> ���� ������ GUID ���� ����������� �������� �� �����.</summary>
        private static readonly Dictionary<string, SaveableEntity> _saveableEntityDatabase = new();

        /// <summary> �������� �� ������ ��������?</summary>
        /// <remarks> � �������� �� ������ ������������ GUID.</remarks>
        private bool IsPrefab => string.IsNullOrEmpty(gameObject.scene.path);

        /// <summary> ��������� GUID.</summary>
        private void Update()
        {
            if (Application.IsPlaying(gameObject) || IsPrefab) return;
            SetUniqueIdentifier();
        }

        /// <summary> ����������� GUID �������� �� �����.</summary>
        private void SetUniqueIdentifier()
        {
            var serializedObject = new UnityEditor.SerializedObject(this);
            var property = serializedObject.FindProperty(nameof(_uniqueIdentifier));
            if (string.IsNullOrEmpty(property.stringValue) || !IsUnique(property.stringValue))
            {
                property.stringValue = System.Guid.NewGuid().ToString();
                serializedObject.ApplyModifiedProperties();
            }
            _saveableEntityDatabase[property.stringValue] = this;
        }

        /// <summary> �������� �� GUID ����������?</summary>
        /// <param name="candidate"> �������� ��� ��������.</param>
        /// <returns> ���������� True - ���� GUID �������� ����������, False - � ��������� ������.</returns>
        private bool IsUnique(string candidate)
        {
            if (!_saveableEntityDatabase.ContainsKey(candidate) || _saveableEntityDatabase[candidate] == this)
                return true;

            if (_saveableEntityDatabase[candidate] == null
                || _saveableEntityDatabase[candidate].UniqueIdentifier != candidate)
            {
                _saveableEntityDatabase.Remove(candidate);
                return true;
            }
            return false;
        }
#endif
        #endregion
    }
}