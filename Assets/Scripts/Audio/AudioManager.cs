using UnityEngine;
using UnityEngine.Audio;
/// <summary>
///  ласс, управл€юший громкостью аудио каналов.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>Ёкземпл€р объекта.</summary>
    public static AudioManager Instance;
    /// <summary>јудиомиксер.</summary>
    public AudioMixer _audioMixer;
    /// <summary>—оздание единственного экземпл€ра класса.</summary>
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
    /// ћетод, отвечающий за изменение параметра громкости определенного аудио канала
    /// </summary>
    /// <param name="name">Ќазвание аудио канала</param>
    /// <param name="value">Ќовое значение, считанное со слайдера</param>
    public void SetMixerValue(string name, float value)
    {
        const int MinMixerValue = -80;
        const int MixerMultipliyer = 20;
        value = value == 0 ? MinMixerValue : Mathf.Log10(value) * MixerMultipliyer;
        _audioMixer.SetFloat(name, value);
    }
}
