using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class TabMenu : MonoBehaviour
{
    [Header("UI Objects")]
    [SerializeField] private List<Button> _tabButtons;
    [SerializeField] private List<GameObject> _tabInfo;
    [Header("Sounds")]
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _tabSound;
    private int _previousIndex, _direction;
    private bool _left, _right;

    private void Awake()
    {
        _audioSource.pitch = 1;
    }

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

    private void Update()
    {
        _left = Input.GetKeyDown(KeyCode.LeftArrow);
        _right = Input.GetKeyDown(KeyCode.RightArrow);

        if (_left || _right)
        {
            _direction = _left ? -1 : 1;
            OnTabSelected((_previousIndex + _tabButtons.Count + _direction) % _tabButtons.Count);
        }
    }

    private void OnTabSelected(int index)
    {
        _tabInfo[_previousIndex].SetActive(false);
        _tabInfo[index].SetActive(true);
        _previousIndex = index;

        _audioSource.PlayOneShot(_tabSound);
        _tabButtons[index].Select();
    }
}
