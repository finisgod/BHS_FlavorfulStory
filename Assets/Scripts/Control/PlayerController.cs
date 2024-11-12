using FlavorfulStory.Movement;
using UnityEngine;

namespace FlavorfulStory.Control
{
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMover _playerMover;

        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
        }

        private void Update()
        {
            if (!LockActionsManager.IsLock) InteractWithMovement();

        }

        private void Start()
        {
            //WorldTime.DayEndedEvent += ToSpawn;
        }

        private void InteractWithMovement()
        {
            float x = Input.GetAxis("Horizontal"), z = Input.GetAxis("Vertical");
            var direction = new Vector3(x, 0, z).normalized;
            _playerMover.MoveAndRotate(direction);
        }
    }
}