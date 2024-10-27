using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// Класс, отвечающий за поспроизведение музыки.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    /// <summary> Ссылка на микшер.</summary>
    [SerializeField] private AudioMixer _audioMixer;
    /// <summary> Список аудиоклипов для песен.</summary>
    [SerializeField] private List<AudioClip> _tracks;
    /// <summary> Ссылка на аудиоисточник.</summary>
    private AudioSource _audioPlayer;
    /// <summary>Получение компонента аудио источника</summary>
    private void Awake()
    {
        _audioPlayer = GetComponent<AudioSource>();
        _audioPlayer.pitch = 1;
    }
    /// <summary> Метод для старта воспроизведения музыки.</summary>
    private void Start()
    {
        StartCoroutine(PlayTracks(_tracks));
    }
    /// <summary> Метод для воспроизведения трека.</summary>
    private void PlayTrack(AudioClip audioClip)
    {
        _audioPlayer.clip = audioClip;
        _audioPlayer.Play();
    }
    /// <summary> Метод для воспроизведения всех треков.</summary>
    private IEnumerator PlayTracks(List<AudioClip> tracks)
    {
        while (true)
        {
            int randomTrackIndex = GetRandomIndex(tracks);
            Debug.Log(randomTrackIndex);
            PlayTrack(tracks[randomTrackIndex]);
            yield return new WaitForSeconds(tracks[randomTrackIndex].length);
        }
    }
    /// <summary>
    /// Метод для получения случайного индекса из списка треков.
    /// </summary>
    /// <param name="tracks">Список треков</param>
    /// <returns>Случайный индекс</returns>
    private int GetRandomIndex(List<AudioClip> tracks)
    {
        return Random.Range(0, tracks.Count);
    }
}
