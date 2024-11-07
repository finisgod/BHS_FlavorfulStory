using FlavorfulStory.Stats.PlayerStats;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FlavorfulStory.UI
{
    /// <summary>  Класс, отвечающий за отрисовку количества маны.</summary>
    public class ManaBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary> Объект текста.</summary>
        [SerializeField] private TMP_Text _textObject;
        
        /// <summary> Объект игрока.</summary>
        [SerializeField] private GameObject _player;
                
        /// <summary> Компонент маны.</summary>
        private Mana _mana;

        /// <summary> Подписка на события.</summary>
        private void OnEnable()
        {
            _mana.OnManaChanged += SetManaText;
        }

        /// <summary> Отписка от события.</summary>
        private void OnDisable()
        {
            _mana.OnManaChanged -= SetManaText;
        }

        private void Awake()
        {
            _mana = _player.GetComponent<Mana>();
        }

        private void Start()
        {
            SetManaText(_mana.CurrentMana);
            _textObject.gameObject.SetActive(false);
        }

        /// <summary> Установка текстового значения.</summary>
        /// <param name="mana"> Текущее значение маны.</param>
        private void SetManaText(int mana)
        {
            _textObject.text = mana.ToString();
        }

        /// <summary> Включение объекта при наведении на него курсора.</summary>
        /// <param name="eventData"> Информация ивента.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetManaText(_mana.CurrentMana);
            _textObject.gameObject.SetActive(true);
        }

        /// <summary> Выключение объекта при наведении на него курсора.</summary>
        /// <param name="eventData"> Информация ивента.</param>
        public void OnPointerExit(PointerEventData eventData)
        {
            _textObject.gameObject.SetActive(false);
        }
    }
}