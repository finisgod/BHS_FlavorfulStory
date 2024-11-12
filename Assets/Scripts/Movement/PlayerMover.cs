using FlavorfulStory.Saving;
using UnityEngine;

namespace FlavorfulStory.Movement
{
    /// <summary> ������������ ������.</summary>
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Animator))]
    public class PlayerMover : MonoBehaviour, ISaveable
    {
        #region Private Fields
        [Header("��������� ������������")]
        /// <summary> �������� �������� � ������ � �������.</summary>
        [SerializeField, Tooltip("�������� ��������")] private float _moveSpeed;

        /// <summary> �������� �������� � �������� � �������.</summary>
        [SerializeField, Tooltip("�������� ��������")] private float _rotateSpeed;

        /// <summary> �������, ��� ������� ������� ���������� ������������ �� ������ ������ ����.</summary>
        [SerializeField, Tooltip("�������, ��� ������� ������� ���������� ������������ �� ������ ������ ����.")]
        private KeyCode _keyForWalking = KeyCode.LeftShift;

        /// <summary> ������� ����.</summary>
        private Rigidbody _rigidbody;

        /// <summary> �������� ������.</summary>
        private Animator _animator;
        #endregion

        /// <summary> ������������� ����� ������.</summary>
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }

        /// <summary> ������������ ������ � �������� �����������.</summary>
        /// <param name="direction"> �����������, � ������� �������� �����.</param>
        public void MoveAndRotate(Vector3 direction)
        {
            Move(direction);
            AnimateMovement(direction.magnitude);
            Rotate(direction);
        }

        /// <summary> ������������ ������ � �������� �����������.</summary>
        /// <param name="direction"> �����������, � ������� �������� �����.</param>
        private void Move(Vector3 direction)
        {
            Vector3 offset = _moveSpeed * CountSpeedMultiplier() * Time.deltaTime * direction;
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }

        /// <summary> ��������� ��������� ��������.</summary>
        /// <returns> ���������� �������� ��������� ��������.</returns>
        private float CountSpeedMultiplier()
        {
            // �������� ���������� ����������� �� 0 �� 1.
            const float WalkingMultiplier = 0.5f;
            const float RunningMultiplier = 1f;
            return Input.GetKey(_keyForWalking) ? WalkingMultiplier : RunningMultiplier;
        }

        /// <summary> ����������� ������������.</summary>
        /// <param name="directionMagnitude"> �������� ������� �����������.</param>
        private void AnimateMovement(float directionMagnitude)
        {
            float speed = Mathf.Clamp01(directionMagnitude) * CountSpeedMultiplier();
            const float DampTime = 0.2f; // �������� �������� �����������
            _animator.SetFloat("Speed", speed, DampTime, Time.deltaTime);
        }

        /// <summary> ������� ������ � �������� �����������.</summary>
        /// <param name="direction"> �����������, � ������� �������� �����.</param>
        public void Rotate(Vector3 direction)
        {
            float singleStep = _rotateSpeed * Time.deltaTime;
            var newDirection = Vector3.RotateTowards(transform.forward, direction, singleStep, 0f);
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