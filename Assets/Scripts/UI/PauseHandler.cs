using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private List<GameObject> _enableObjects;
    [SerializeField] private List<GameObject> _disableObjects;
    private bool _isPaused;

    private void Start()
    {
        _isPaused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

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

    private void ActivateObjects(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].gameObject.SetActive(true);
        }
    }

    private void DeactivateObjects(List<GameObject> objects)
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].gameObject.SetActive(false);
        }
    }
}