using FlavorfulStory.Saving;
using UnityEngine;

namespace FlavorfulStory.Movement
{
    /// <summary> ������������ ������.</summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMover : MonoBehaviour, ISaveable
    {
        [Header("��������� ������������")]
        /// <summary> �������� ��������.</summary>
        [SerializeField] private float _moveSpeed;
        /// <summary> �������� ��������.</summary>
        [SerializeField] private float _rotateSpeed;

        /// <summary> ������� ����.</summary>
        private Rigidbody _rigidbody;

        /// <summary> ������������� ����� ������.</summary>
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        /// <summary> ������������ ������ � �������� �����������.</summary>
        /// <param name="direction"> �����������, � ������� �������� �����.</param>
        public void Move(Vector3 direction)
        {
            Vector3 offset = _moveSpeed * Time.deltaTime * direction;
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }

        /// <summary> ������� ������ � �������� �����������.</summary>
        /// <param name="direction"> �����������, � ������� �������� �����.</param>
        public void Rotate(Vector3 direction)
        {
            if (Vector3.Angle(transform.forward, direction) > 0)
            {
                Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction, _rotateSpeed, 0);
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
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