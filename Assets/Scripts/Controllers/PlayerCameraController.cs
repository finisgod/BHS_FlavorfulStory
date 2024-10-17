using UnityEngine;
/// <summary>����� - ���������� ������ .</summary>
public class PlayerCameraController : MonoBehaviour
{
    /// <summary> Transform ������.</summary>
    [SerializeField] private Transform _playerPosition;
    /// <summary> ������ ������.</summary>
    [SerializeField] private GameObject _camera;
    /// <summary> �������� ������.</summary>
    [SerializeField] private Vector3 _baseCameraOffset;
    [SerializeField] float cameraSpeed = 6.0f;
    /// <summary> �������� ������ ��� �������� ��������� ����.</summary>
    static Vector3 currentCameraOffset = Vector3.zero;

    /// <summary>����� ������������ ��� ������ ������� .</summary>
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
