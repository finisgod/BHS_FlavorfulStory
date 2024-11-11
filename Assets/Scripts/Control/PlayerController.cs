using FlavorfulStory.Movement;
using NPC;
using UnityEngine;

namespace FlavorfulStory.Control
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private NpcPathPoint spawnPosition;
        private PlayerMover _playerMover;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
        }

        private void FixedUpdate()
        {
            if(!LockActionsManager.IsLock) InteractWithMovement();
        }

        private void Start()
        {
            ToSpawn();
            WorldTime.DayEndedEvent += ToSpawn;
        }

        public void ToSpawn()
        {
            GetComponent<Rigidbody>().MovePosition(spawnPosition.Coordinate);
        }
        private void InteractWithMovement()
        {
            float x = Input.GetAxis("Horizontal"), z = Input.GetAxis("Vertical");
            var direction = new Vector3(x, 0, z).normalized;
            _playerMover.MoveAndRotate(direction);
        }
        /// <summary> Поворот игрока в заданном направлении.</summary>
        /// <param name="direction"> Направление, в котором движется игрок.</param>
        public void Rotate(Vector3 direction)
        {
            _playerMover.Rotate(direction);
        }
    }
}