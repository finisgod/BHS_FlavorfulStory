using UnityEngine;

namespace FlavorfulStory.UI
{
    /// <summary> ������������� UI.</summary>
    public class UISwitcher : MonoBehaviour
    {
        /// <summary> ������, ������� �� ��������� ���������� ��� ������ �����.</summary>
        [SerializeField] private GameObject _entryPoint;

        /// <summary> ��� ������ �������� ������ ������.</summary>
        private void Start()
        {
            SwitchTo(_entryPoint);
        }

        /// <summary> ����������� �������.</summary>
        /// <param name="toDisplay"> ������, ������� ����� ����������.</param>
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