using FlavorfulStory.Inventory;
using FlavorfulStory.Inventory.DropSystem;
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

            // TEST
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<ItemDropper>().DropItem(InventoryItem.GetItemFromID("368f7b2d-c83a-4fc0-a12c-921aa67a4beb"));
            }
        }
    }
}