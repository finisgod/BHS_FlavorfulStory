using FlavorfulStory.Stats.CharacterStats;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FlavorfulStory.UI
{
    /// <summary>  Класс, отвечающий за отрисовку количества здоровья.</summary>
    public class HealthBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary> Объект текста.</summary>
        [SerializeField] private TMP_Text _textObject;
        
        /// <summary> Объект игрока.</summary>
        [SerializeField] private GameObject _player;
        
        /// <summary> Компонент здоровья.</summary>
        private Health _health;

        /// <summary> Подписка на события.</summary>
        private void OnEnable()
        {
            _health.OnHealthChanged += SetHealthText;
        }

        /// <summary> Отписка от события.</summary>
        private void OnDisable()
        {
            _health.OnHealthChanged -= SetHealthText;
        }

        private void Awake()
        {
            _health = _player.GetComponent<Health>();
        }

        private void Start()
        {
            SetHealthText(_health.CurrentHealth);
            _textObject.gameObject.SetActive(false);
        }
        
        /// <summary> Установка текстового значения.</summary>
        /// <param name="health"> Текущее значение энергии.</param>
        private void SetHealthText(int health)
        {
            _textObject.text = health.ToString();
        }
        

        /// <summary> Включение объекта при наведении на него курсора.</summary>
        /// <param name="eventData"> Информация ивента.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetHealthText(_health.CurrentHealth);
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