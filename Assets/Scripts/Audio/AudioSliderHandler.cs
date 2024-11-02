using UnityEngine;
using UnityEngine.UI;

namespace FlavorfulStory.Audio
{
    /// <summary> Класс, считывающий значение слайдера.</summary>
    [RequireComponent(typeof(Slider))]
    public class AudioSliderHandler : MonoBehaviour
    {
        /// <summary> Тип громкости.</summary>
        [SerializeField] private VolumeType _volumeType;

        /// <summary> Настройки звука.</summary>
        [SerializeField] private AudioSettings _audioSettings;

        /// <summary> Ссылка на слайдер.</summary>
        private Slider _slider;

        /// <summary>Получение компонента Слайдер</summary>
        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        /// <summary> Вызывается при включении объекта.</summary>
        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(delegate { ValueChanged(); });
            _audioSettings.SliderUpdate += UpdateSlider;
        }

        /// <summary> Вызывается при отключении объекта.</summary>
        private void OnDisable()
        {
            _slider.onValueChanged.RemoveAllListeners();
            _audioSettings.SliderUpdate -= UpdateSlider;
        }

        /// <summary> Вызывается при изменении значения слайдера.</summary>
        private void ValueChanged()
        {
            _audioSettings.SetMixerValue(_volumeType, _slider.value);
        }

        private void UpdateSlider()
        {
            _slider.value = _audioSettings.GetVolumeValueFromType(_volumeType);
        }
    }
}