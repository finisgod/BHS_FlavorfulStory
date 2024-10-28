using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �����, ���������� �� ���������� �� �����.
/// </summary>
public class PauseHandler : MonoBehaviour
{
    [Header("Objects")]
    /// <summary>������ �������� UI ��������, ������� ����������� ��� �����.</summary>
    [SerializeField] private List<GameObject> _enableObjects;
    /// <summary>������ �������� UI ��������, ������� ���������� ��� �����.</summary>
    [SerializeField] private List<GameObject> _disableObjects;
    ///<summary>���������� ��������� �����.</summary>
    private bool _isPaused;
    ///<summary>�� ��������� ���� �� �� �����.</summary>
    private void Start()
    {
        _isPaused = false;
    }
    ///<summary>���������� ������� ������ ESC. </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }
    ///<summary>����� ��� ���������/���������� �������� UI ��� �����.</summary>
    private void SetPause()
    {
        if (!_isPaused)
        {
            ActivateObjects(_enableObjects);
            DeactivateObjects(_disableObjects);
            Time.timeScale = 0;
            _isPaused = true;
        }
        else if (_isPaused)
        {
            ActivateObjects(_disableObjects);
            DeactivateObjects(_enableObjects);
            Time.timeScale = 1;
            _isPaused = false;
        }
    }
    /// <summary>
    /// ����� ��� ��������� UI �������� ��� �����.
    /// </summary>
    /// <param name="objects">������ UI ��������, ������� ����� ������������ ��� �����. </param>
    private void ActivateObjects(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].gameObject.SetActive(true);
        }
    }
    /// <summary>
    /// ����� ��� ���������� UI �������� ��� �����.
    /// </summary>
    /// <param name="objects">������ UI ��������, ������� ����� ������������ ��� �����. </param>
    private void DeactivateObjects(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].gameObject.SetActive(false);
        }
    }
}