using UnityEngine;

namespace FlavorfulStory.UI
{
    /// <summary> Переключатель UI.</summary>
    public class UISwitcher : MonoBehaviour
    {
        /// <summary> Объект, который по умолчанию включается при старте сцены.</summary>
        [SerializeField] private GameObject _entryPoint;

        /// <summary> При старте включаем нужный объект.</summary>
        private void Start()
        {
            SwitchTo(_entryPoint);
        }

        /// <summary> Переключить объекты.</summary>
        /// <param name="toDisplay"> Объект, который нужно отобразить.</param>
        public void SwitchTo(GameObject toDisplay)
        {
            if (toDisplay.transform.parent != transform) return;

            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            toDisplay.SetActive(true);
        }
    }
}