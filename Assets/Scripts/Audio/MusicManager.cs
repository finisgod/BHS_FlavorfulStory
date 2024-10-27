using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/// <summary>
/// �����, ���������� �� ��������������� ������.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    /// <summary> ������ �� ������.</summary>
    [SerializeField] private AudioMixer _audioMixer;
    /// <summary> ������ ����������� ��� �����.</summary>
    [SerializeField] private List<AudioClip> _tracks;
    /// <summary> ������ �� �������������.</summary>
    private AudioSource _audioPlayer;
    /// <summary>��������� ���������� ����� ���������</summary>
    private void Awake()
    {
        _audioPlayer = GetComponent<AudioSource>();
        _audioPlayer.pitch = 1;
    }
    /// <summary> ����� ��� ������ ��������������� ������.</summary>
    private void Start()
    {
        StartCoroutine(PlayTracks(_tracks));
    }
    /// <summary> ����� ��� ��������������� �����.</summary>
    private void PlayTrack(AudioClip audioClip)
    {
        _audioPlayer.clip = audioClip;
        _audioPlayer.Play();
    }
    /// <summary> ����� ��� ��������������� ���� ������.</summary>
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
    /// ����� ��� ��������� ���������� ������� �� ������ ������.
    /// </summary>
    /// <param name="tracks">������ ������</param>
    /// <returns>��������� ������</returns>
    private int GetRandomIndex(List<AudioClip> tracks)
    {
        return Random.Range(0, tracks.Count);
    }
}
