using FlavorfulStory.Stats.PlayerStats;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FlavorfulStory.UI.Bars
{
    /// <summary>  Класс, отвечающий за отрисовку количества маны.</summary>
    public class ManaBar : BaseBar, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary> Компонент маны.</summary>
        private Mana _mana;

        /// <summary> Подписка на события.</summary>
        private void OnEnable()
        {
            _mana.OnManaChanged += SetBarText;
        }

        /// <summary> Отписка от события.</summary>
        private void OnDisable()
        {
            _mana.OnManaChanged -= SetBarText;
        }

        private void Awake()
        {
            Player = GameObject.FindGameObjectWithTag("Player");
            _mana = Player.GetComponent<Mana>();
        }

        private void Start()
        {
            SetBarText(_mana.CurrentValue);
            _textObject.gameObject.SetActive(false);
        }

        /// <summary> Включение объекта при наведении на него курсора.</summary>
        /// <param name="eventData"> Информация ивента.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetBarText(_mana.CurrentValue);
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