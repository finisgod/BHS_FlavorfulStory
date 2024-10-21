using FlavorfulStory.Movement;
using UnityEngine;

namespace FlavorfulStory.Control
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            var direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
            _playerMovement.Move(direction);
            _playerMovement.Rotate(direction);
        }
    }
}