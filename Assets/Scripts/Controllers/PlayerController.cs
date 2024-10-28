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
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            _playerMover.Move(direction);
            _playerMover.Rotate(direction);
        }
    }
}