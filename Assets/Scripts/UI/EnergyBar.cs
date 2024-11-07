using FlavorfulStory.Stats.PlayerStats;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FlavorfulStory.UI
{
    /// <summary>  Класс, отвечающий за отрисовку количества энергии.</summary>
    public class EnergyBar : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        /// <summary> Объект текста.</summary>
        [SerializeField] private TMP_Text _textObject;
        
        /// <summary> Объект игрока.</summary>
        [SerializeField] private GameObject _player;
        
        /// <summary> Компонент энергии.</summary>
        private Energy _energy;

        /// <summary> Подписка на события.</summary>
        private void OnEnable()
        {
            _energy.OnEnergyChanged += SetEnergyText;
        }

        /// <summary> Отписка от событий.</summary>
        private void OnDisable()
        {
            _energy.OnEnergyChanged -= SetEnergyText;
        }

        private void Awake()
        {
            _energy = _player.GetComponent<Energy>();
        }
        
        private void Start()
        {
            SetEnergyText(_energy.CurrentEnergy);
            _textObject.gameObject.SetActive(false);
        }

        /// <summary> Установка текстового значения.</summary>
        /// <param name="energy"> Текущее значение энергии.</param>
        private void SetEnergyText(int energy)
        {
            _textObject.text = energy.ToString();
        }
        

        /// <summary> Включение объекта при наведении на него курсора.</summary>
        /// <param name="eventData"> Информация ивента.</param>
        public void OnPointerEnter(PointerEventData eventData)
        {
            SetEnergyText(_energy.CurrentEnergy);
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
