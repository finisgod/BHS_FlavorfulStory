using UnityEngine;

/// <summary> Контроллер камеры.</summary>
public class PlayerCameraController : MonoBehaviour
{
    /// <summary> Transform игрока.</summary>
    [SerializeField] private Transform _playerPosition;

    /// <summary> Объект камеры.</summary>
    [SerializeField] private GameObject _camera;

    /// <summary> Смещение камеры.</summary>
    [SerializeField] private Vector3 _baseCameraOffset;

    /// <summary> Скорость камеры.</summary>
    [SerializeField] float cameraSpeed = 6.0f;

    /// <summary> Смещение камеры при движении колесиком мыши.</summary>
    private static Vector3 currentCameraOffset = Vector3.zero;

    /// <summary>  При старте .</summary>
    private void Start()
    {
        _camera.transform.position = _playerPosition.transform.position + _baseCameraOffset - currentCameraOffset;
    }

    /// <summary> При обновлении каждого кадра .</summary>
    private void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            currentCameraOffset += _baseCameraOffset.normalized * Input.mouseScrollDelta.y; //ToDo: Mb move to another file
        }
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, _playerPosition.transform.position + _baseCameraOffset - currentCameraOffset, cameraSpeed * Time.deltaTime);
    }
}
