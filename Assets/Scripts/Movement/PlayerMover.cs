using FlavorfulStory.Saving;
using UnityEngine;

namespace FlavorfulStory.Movement
{
    /// <summary> Передвижение игрока.</summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMover : MonoBehaviour, ISaveable
    {
        [Header("Параметры передвижения")]
        /// <summary> Скорость движения.</summary>
        [SerializeField] private float _moveSpeed;

        /// <summary> Твердое тело.</summary>
        private Rigidbody _rigidbody;

        /// <summary> Аниматор игрока.</summary>
        private Animator _animator;
      
        /// <summary> Инициализация полей класса.</summary>
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        /// <summary> Передвижение игрока в заданном направлении.</summary>
        /// <param name="direction"> Направление, в котором движется игрок.</param>
        public void Move(Vector3 direction)
        {
            float multiplier = Input.GetKey(KeyCode.LeftShift) ? 0.5f : 1f;

            // Animate
            float speed = Mathf.Clamp01(direction.magnitude) * multiplier;
            const float DampTime = 0.2f; // Значение получено эмпирически
            _animator.SetFloat("Speed", speed, DampTime, Time.deltaTime);

            // Move
            Vector3 offset = _moveSpeed * multiplier * Time.deltaTime * direction;
            _rigidbody.MovePosition(_rigidbody.position + offset);

            Rotate(direction);
        }

        /// <summary> Поворот игрока в заданном направлении.</summary>
        /// <param name="direction"> Направление, в котором движется игрок.</param>
        private void Rotate(Vector3 direction)
        {
            float _rotateSpeed = 4f;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        #region Saving
        [System.Serializable]
        private struct MoverSaveData
        {
            public SerializableVector3 Position;
            public SerializableVector3 Rotation;
        }

        public object CaptureState() => new MoverSaveData()
        {
            Position = new SerializableVector3(transform.position),
            Rotation = new SerializableVector3(transform.eulerAngles)
        };

        public void RestoreState(object state)
        {
            var data = (MoverSaveData)state;
            transform.position = data.Position.ToVector();
            transform.eulerAngles = data.Rotation.ToVector();
        }
        #endregion
    }
}