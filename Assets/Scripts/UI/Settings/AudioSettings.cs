using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Структура, содержащая значения текущие значения слайдеров громкости.
/// </summary>
public struct SoundSettings
{
    public float Master;
    public float SFX;
    public float Music;
}
/// <summary>
/// Класс, считывающий значения слайдеров громкости.
/// </summary>
public class AudioSettings : MonoBehaviour
{
    /// <summary>Ссылка на слайдер общей громкости.</summary>
    [SerializeField] private Slider _masterVolumeSlider;
    /// <summary>Ссылка на слайдер громкости эффектов.</summary>
    [SerializeField] private Slider _sfxVolumeSlider;
    /// <summary>Ссылка на слайдер громкости музыки.</summary>
    [SerializeField] private Slider _musicVolumeSlider;
    /// <summary>Текущие настройки громкости.</summary>
    public SoundSettings _currentSettings;
    /// <summary>
    /// Установка значений по умолчанию.
    /// </summary>
    private void Start()
    {
        SetDefaultSettings();
    }
    /// <summary>
    /// Метод, устанавливающий значения по умолчанию.
    /// </summary>
    public void SetDefaultSettings()
    {
        _masterVolumeSlider.value = 0.5f;
        _sfxVolumeSlider.value = 0.5f;
        _musicVolumeSlider.value = 0.5f;
        _currentSettings.Master = 0.5f;
        _currentSettings.SFX = 0.5f;
        _currentSettings.Music = 0.5f;
    }
    /// <summary>
    /// Метод, сохраняющий зачение слайдера общей громкости.
    /// </summary>
    public void SetMasterVolume()
    {
        _currentSettings.Master = _masterVolumeSlider.value;
    }
    /// <summary>
    /// Метод, сохраняющий зачение слайдера громкости эффектов.
    /// </summary>
    public void SetSFXVolume()
    {
        _currentSettings.SFX = _sfxVolumeSlider.value;
    }
    /// <summary>
    /// Метод, сохраняющий зачение слайдера громкости музыки.
    /// </summary>
    public void SetMusicVolume()
    {
        _currentSettings.Music = _musicVolumeSlider.value;
    }
}