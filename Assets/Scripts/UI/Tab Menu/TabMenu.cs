using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// �����, ���������� �� ����������� ���� ����� � �������������� � ���� ����.
/// </summary>
public class TabMenu : MonoBehaviour
{
    [Header("UI Objects")]
    /// <summary>������ ������ ������ ����</summary>
    [SerializeField] private List<Button> _tabButtons;
    /// <summary>������ �������������� ������ ��� ��������������� ������ ����.</summary>
    [SerializeField] private List<GameObject> _tabInfo;
    [Header("Sounds")]
    /// <summary>�������������.</summary>
    [SerializeField] private AudioSource _audioSource;
    /// <summary>���� ������� �� ������ ����.</summary>
    [SerializeField] private AudioClip _pressedTabSound;
    /// <summary>���������� ������������, ����� ������ ���� ������. </summary>
    private int _previousIndex;

    private void Awake()
    {
        _audioSource.pitch = 1;
    }
    /// <summary>�������� �������� �������������� ������ � ��������������� �������..</summary>
    private void Start()
    {
        for (int i = 0; i < _tabButtons.Count; i++)
        {
            int _index = i;
            _tabButtons[i].onClick.AddListener(() => OnTabSelected(_index));
        }

        _previousIndex = (int)(_tabButtons.Count / 2);
        OnTabSelected(_previousIndex);
    }
    /// <summary>��������� ����������� �� ������� ���� � ������� ����������.</summary>
    private void Update()
    {
        bool _left = Input.GetKeyDown(KeyCode.Q);
        bool _right = Input.GetKeyDown(KeyCode.E);

        if (_left || _right)
        {
            int _direction = _left ? -1 : 1;
            OnTabSelected((_previousIndex + _tabButtons.Count + _direction) % _tabButtons.Count);
        }
    }
    /// <summary>
    /// �����, ���������� ��� ������� �� ������, ��������� ��������������� ���� � �������� ����������.
    /// </summary>
    /// <param name="index">������ ������������ �����.</param>
    private void OnTabSelected(int index)
    {
        _tabInfo[_previousIndex].SetActive(false);
        _tabInfo[index].SetActive(true);
        _previousIndex = index;

        _audioSource.PlayOneShot(_pressedTabSound);
        _tabButtons[index].Select();
    }
}
