﻿using FlavorfulStory.InventorySystem;
using FlavorfulStory.InventorySystem.DropSystem;
using FlavorfulStory.Movement;
using UnityEngine;

namespace FlavorfulStory.Control
{
    /// <summary> Контроллер игрока.</summary>
    [RequireComponent(typeof(PlayerMover))]
    public class PlayerController : MonoBehaviour
    {
        /// <summary> Передвижение игрока.</summary>
        private PlayerMover _playerMover;

        /// <summary> Инициализация полей.</summary>
        private void Awake()
        {
            _playerMover = GetComponent<PlayerMover>();
        }

        //private void Start()
        //{
        //    //WorldTime.DayEndedEvent += ToSpawn;
        //}

        /// <summary> Выполнение различных действий в зависимости от состояния.</summary>
        private void Update()
        {
            if (!LockActionsManager.IsLock) InteractWithMovement();
            
            // DEBUG
            if (Input.GetKeyDown(KeyCode.Space))
                GetComponent<ItemDropper>().DropItem(InventoryItem.GetItemFromID("ca9e19dc-3f88-4f9a-9074-a70acfc5ea0f"), 1);
        }

        private void InteractWithMovement()
        {
            float x = Input.GetAxis("Horizontal"), z = Input.GetAxis("Vertical");
            var direction = new Vector3(x, 0, z).normalized;
            _playerMover.MoveAndRotate(direction);
        }
    }
}