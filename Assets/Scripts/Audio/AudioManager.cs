using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// Класс, управляюший громкостью аудио каналов.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>Экземпляр объекта.</summary>
    public static AudioManager Instance;
    /// <summary>Аудиомиксер.</summary>
    public AudioMixer _audioMixer;
    /// <summary>Создание единственного экземпляра класса.</summary>
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(Instance.gameObject);
    }
    /// <summary>
    /// Метод, отвечающий за изменение параметра громкости определенного аудио канала
    /// </summary>
    /// <param name="name">Название аудио канала</param>
    /// <param name="value">Новое значение, считанное со слайдера</param>
    public void SetMixerValue(string name, float value)
    {
        const int MinMixerValue = -80;
        const int MixerMultipliyer = 20;
        value = value == 0 ? MinMixerValue : Mathf.Log10(value) * MixerMultipliyer;
        _audioMixer.SetFloat(name, value);
    }
}
