﻿using UnityEngine;

/// <summary> Базовый класс игрока для сохранения его состояний.</summary> 
public class Player : MonoBehaviour //Скорее всего singleton 
{
    public int Health = 100;
    public int Energy = 100;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            LooseHealth(1);
            LooseEnergy(2);
        }
    }

    public void Warp(Vector3 position)
    {
        _rigidBody.MovePosition(position);
    }

    public void LooseHealth(int delta)
    {
        Health -= delta;
        OnChangeHealth?.Invoke(Health);
    }
    public void LooseEnergy(int delta)
    {
        Energy -= delta;
        OnChangeEnergy?.Invoke(Energy);
    }

    public delegate void OnChangeHealthEvent(int health);
    public event OnChangeHealthEvent OnChangeHealth;

    public delegate void OnChangeEnergyEvent(int health);
    public event OnChangeEnergyEvent OnChangeEnergy;
}
