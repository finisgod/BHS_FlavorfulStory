using UnityEngine;

/// <summary> Базовый класс игрока для сохранения его состояний.</summary> 
public class Player : MonoBehaviour //Скорее всего singleton 
{
    public Vector3 spawnPosition;

    public int Health = 100;
    public int Energy = 100;
    Rigidbody rb;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //ToSpawn();
        //WorldTime.DayEndedEvent += ToSpawn;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            LooseHealth(1);
            LooseEnergy(2);
        }
    }

    public void ToSpawn()
    {
        this.GetComponent<Rigidbody>().MovePosition(spawnPosition);
    }

    public void Warp(Vector3 position)
    {
        rb.MovePosition(position);
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
