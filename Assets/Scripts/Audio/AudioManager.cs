using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public const string MasterVolume = "Master";
    public const string MusicVolume = "Music";
    public const string SFXVolume = "SFX";

    public AudioMixer _audioMixer;
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

    public void SetMixerValue(string key, float value)
    {
        value = value == 0 ? -80 : Mathf.Log10(value) * 20;
        // Debug.Log($"Set {key} volume to {value}");
        _audioMixer.SetFloat(key, value);
    }
}
