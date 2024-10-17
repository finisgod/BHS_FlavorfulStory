using UnityEngine;
/// <summary>Класс - контроллер камеры .</summary>
public class PlayerCameraController : MonoBehaviour
{
    /// <summary> Transform игрока.</summary>
    [SerializeField] private Transform _playerPosition;
    /// <summary> Объект камеры.</summary>
    [SerializeField] private GameObject _camera;
    /// <summary> Смещение камеры.</summary>
    [SerializeField] private Vector3 _baseCameraOffset;
    [SerializeField] float cameraSpeed = 6.0f;
    /// <summary> Смещение камеры при движении колесиком мыши.</summary>
    static Vector3 currentCameraOffset = Vector3.zero;

    /// <summary>Метод вызывающийся при старте скрипта .</summary>
    private void Start()
    {
        _camera.transform.position = _playerPosition.transform.position + _baseCameraOffset - currentCameraOffset;
    }
    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            currentCameraOffset += _baseCameraOffset.normalized * Input.mouseScrollDelta.y; //ToDo: Mb move to another file
        }
        _camera.transform.position = Vector3.Lerp(_camera.transform.position , _playerPosition.transform.position + _baseCameraOffset - currentCameraOffset, cameraSpeed * Time.deltaTime);
    }
}
