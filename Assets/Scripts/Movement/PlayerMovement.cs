using UnityEngine;

namespace FlavorfulStory.Movement
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Параметры передвижения")]
        /// <summary> Скорость движения.</summary>
        [SerializeField] private float _moveSpeed;
        /// <summary> Скорость поворота.</summary>
        [SerializeField] private float _rotateSpeed;

        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 direction)
        {
            Vector3 offset = _moveSpeed * Time.deltaTime * direction;
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }

        public void Rotate(Vector3 direction)
        {
            if (Vector3.Angle(transform.forward, direction) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }
    }
}