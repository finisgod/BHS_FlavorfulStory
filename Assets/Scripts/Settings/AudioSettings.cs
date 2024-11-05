using FlavorfulStory.Settings;
using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

namespace FlavorfulStory.Audio
{
    /// <summary> Тип громкости.</summary>
    public enum VolumeType
    {
        /// <summary> Общая громкость.</summary>
        Master,

        /// <summary> Громкость звуков.</summary>
        SFX,

        /// <summary> Громкость музыки.</summary>
        Music,
    }

    /// <summary> Значения слайдеров громкости.</summary>
    public class AudioSettings : MonoBehaviour
    {
        /// <summary> Аудиомикшер.</summary>
        [SerializeField] private AudioMixer _audioMixer;

        /// <summary> Обновление слайдера.</summary>
        [SerializeField] private UnityEvent _sliderUpdate;

        /// <summary> При старте выставляем значения слайдера.</summary>
        private void Start()
        {
            SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            SetMixerValue(VolumeType.Master, GetVolumeValueFromType(VolumeType.Master));
            SetMixerValue(VolumeType.Music, GetVolumeValueFromType(VolumeType.Music));
            SetMixerValue(VolumeType.SFX, GetVolumeValueFromType(VolumeType.SFX));
            _sliderUpdate.Invoke();
        }

        /// <summary> Установка значения параметра громкости определенного аудио канала.</summary>
        /// <param name="name"> Название аудио канала.</param>
        /// <param name="value"> Новое значение, считанное со слайдера.</param>
        public void SetMixerValue(VolumeType volumeType, float value)
        {
            const int MinMixerValue = -80;
            const int MixerMultipliyer = 20;
            float mixerValue = value == 0 ? MinMixerValue : Mathf.Log10(value) * MixerMultipliyer;

            string channelName = volumeType.ToString();
            _audioMixer.SetFloat(channelName, mixerValue);

            SavingSettings.SetVolumeFromType(volumeType, value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="volumeType"></param>
        /// <returns></returns>
        public float GetVolumeValueFromType(VolumeType volumeType) => volumeType switch
        {
            VolumeType.Master => SavingSettings.MasterVolume,
            VolumeType.SFX => SavingSettings.SfxVolume,
            VolumeType.Music => SavingSettings.MusicVolume,
            _ => 0,
        };
    }
}