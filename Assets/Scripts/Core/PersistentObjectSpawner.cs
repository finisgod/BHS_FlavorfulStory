using Unity.VisualScripting;
using UnityEngine;

namespace FlavorfulStory.Core
{
    /// <summary> Альтернатива использованию паттерна Singleton. Класс создает префаб только один раз для всех игровых сцен.</summary>
    /// <remarks> Поместите в инспекторе префаб, который будет присутствовать в каждой сцене и содержать все игровые объекты, являющиеся Singleton.
    /// Класс создаст префаб только один раз и настроит его на сохранение между сценами.</remarks>
    public class PersistentObjectSpawner : MonoBehaviour
    {
        /// <summary> Префаб, который создается только один раз и сохраняется между сценами.</summary>
        [Tooltip("Префаб, который создается только один раз и сохраняется между сценами.")]
        [SerializeField] private GameObject _persistentObjectsPrefab;

        /// <summary> Был ли создан объект?</summary>
        private static bool _hasSpawned = false;

        /// <summary> Создание постоянного объекта.</summary>
        private void Awake()
        {
            if (_hasSpawned) return;

            SpawnPersistentObjects();
            _hasSpawned = true;
        }

        /// <summary> Создание постоянного объекта.</summary>
        private void SpawnPersistentObjects()
        {
            GameObject persistentObject = Instantiate(_persistentObjectsPrefab);
            DontDestroyOnLoad(persistentObject);
        }
    }
}
