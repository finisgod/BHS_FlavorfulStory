using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// ���������, ���������� �������� ������� �������� ��������� ���������.
/// </summary>
public struct SoundSettings
{
    public float Master;
    public float SFX;
    public float Music;
}
/// <summary>
/// �����, ����������� �������� ��������� ���������.
/// </summary>
public class AudioSettings : MonoBehaviour
{
    /// <summary>������ �� ������� ����� ���������.</summary>
    [SerializeField] private Slider _masterVolumeSlider;
    /// <summary>������ �� ������� ��������� ��������.</summary>
    [SerializeField] private Slider _sfxVolumeSlider;
    /// <summary>������ �� ������� ��������� ������.</summary>
    [SerializeField] private Slider _musicVolumeSlider;
    /// <summary>������� ��������� ���������.</summary>
    public SoundSettings _currentSettings;
    /// <summary>
    /// ��������� �������� �� ���������.
    /// </summary>
    private void Start()
    {
        SetDefaultSettings();
    }
    /// <summary>
    /// �����, ��������������� �������� �� ���������.
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
    /// �����, ����������� ������� �������� ����� ���������.
    /// </summary>
    public void SetMasterVolume()
    {
        _currentSettings.Master = _masterVolumeSlider.value;
    }
    /// <summary>
    /// �����, ����������� ������� �������� ��������� ��������.
    /// </summary>
    public void SetSFXVolume()
    {
        _currentSettings.SFX = _sfxVolumeSlider.value;
    }
    /// <summary>
    /// �����, ����������� ������� �������� ��������� ������.
    /// </summary>
    public void SetMusicVolume()
    {
        _currentSettings.Music = _musicVolumeSlider.value;
    }
}