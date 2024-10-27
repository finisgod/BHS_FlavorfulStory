using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// �����, ����������� ���������� ����� �������.
/// </summary>
public class AudioManager : MonoBehaviour
{
    /// <summary>��������� �������.</summary>
    public static AudioManager Instance;
    /// <summary>�����������.</summary>
    public AudioMixer _audioMixer;
    /// <summary>�������� ������������� ���������� ������.</summary>
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
    /// �����, ���������� �� ��������� ��������� ��������� ������������� ����� ������
    /// </summary>
    /// <param name="name">�������� ����� ������</param>
    /// <param name="value">����� ��������, ��������� �� ��������</param>
    public void SetMixerValue(string name, float value)
    {
        const int MinMixerValue = -80;
        const int MixerMultipliyer = 20;
        value = value == 0 ? MinMixerValue : Mathf.Log10(value) * MixerMultipliyer;
        _audioMixer.SetFloat(name, value);
    }
}
