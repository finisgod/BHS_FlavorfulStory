using Unity.VisualScripting;
using UnityEngine;

namespace FlavorfulStory.Core
{
    /// <summary> ������������ ������������� �������� Singleton. ����� ������� ������ ������ ���� ��� ��� ���� ������� ����.</summary>
    /// <remarks> ��������� � ���������� ������, ������� ����� �������������� � ������ ����� � ��������� ��� ������� �������, ���������� Singleton.
    /// ����� ������� ������ ������ ���� ��� � �������� ��� �� ���������� ����� �������.</remarks>
    public class PersistentObjectSpawner : MonoBehaviour
    {
        /// <summary> ������, ������� ��������� ������ ���� ��� � ����������� ����� �������.</summary>
        [Tooltip("������, ������� ��������� ������ ���� ��� � ����������� ����� �������.")]
        [SerializeField] private GameObject _persistentObjectsPrefab;

        /// <summary> ��� �� ������ ������?</summary>
        private static bool _hasSpawned = false;

        /// <summary> �������� ����������� �������.</summary>
        private void Awake()
        {
            if (_hasSpawned) return;

            SpawnPersistentObjects();
            _hasSpawned = true;
        }

        /// <summary> �������� ����������� �������.</summary>
        private void SpawnPersistentObjects()
        {
            GameObject persistentObject = Instantiate(_persistentObjectsPrefab);
            DontDestroyOnLoad(persistentObject);
        }
    }
}
