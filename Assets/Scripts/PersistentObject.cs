using FlavorfulStory.SceneManagement;
using UnityEngine;

namespace FlavorfulStory
{
    /// <summary> ������������ ������������� �������� Singleton.</summary>
    public class PersistentObject : MonoBehaviour
    {
        /// <summary> ��������.</summary>
        public static PersistentObject Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        /// <summary> �������� ������ �� SavingWrapper.</summary>
        /// <returns> ���������� ������ �� SavingWrapper.</returns>
        public SavingWrapper GetSavingWrapper() => GetComponentInChildren<SavingWrapper>();
    }
}