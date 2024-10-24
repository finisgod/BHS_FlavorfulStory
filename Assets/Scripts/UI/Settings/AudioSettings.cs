using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;


public struct SoundSettings
{
    public float Master;
    public float SFX;
    public float Music;
}

public class AudioSettings : MonoBehaviour
{
    [SerializeField] private Slider _masterVolume;
    [SerializeField] private Slider _sfxVolume;
    [SerializeField] private Slider _musicVolume;
    public SoundSettings _currentSettings;

    private void Start()
    {
        SetDefaultSettings();
    }

    public void SetDefaultSettings()
    {
        _masterVolume.value = 0.5f;
        _sfxVolume.value = 0.5f;
        _musicVolume.value = 0.5f;
        _currentSettings.Master = 0.5f;
        _currentSettings.SFX = 0.5f;
        _currentSettings.Music = 0.5f;
    }

    public void SetMasterVolume()
    {
        _currentSettings.Master = _masterVolume.value;
    }

    public void SetSFXVolume()
    {
        _currentSettings.SFX = _sfxVolume.value;
    }

    public void SetMusicVolume()
    {
        _currentSettings.Music = _musicVolume.value;
    }
}