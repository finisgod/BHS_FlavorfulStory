using UnityEngine;
/// <summary>����� ���������� �� ������������ ������.</summary>
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    /// <summary> �������� ��������.</summary>
    [SerializeField] private float _speed = 50f;
    /// <summary> ������ ������.</summary>
    [SerializeField] private GameObject _player;
    /// <summary> ������ ��� ���������� ��������� ������ � ������������.</summary>
    static Vector3 lastPosition = Vector3.zero;
    private void FixedUpdate()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 move  = transform.right * xMove + transform.forward * zMove;

        if (move != Vector3.zero)
        {
            float angle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg;
            lastPosition.y = angle;

            Vector3 moveDelta = move * Time.deltaTime * _speed;

            rb.velocity = moveDelta;
            rb.rotation = Quaternion.Euler(0, angle, 0);
        }
    }
}
