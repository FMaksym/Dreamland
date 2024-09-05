using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PlayerHealth : HealthSystem
{
    [SerializeField] private int _playerHealth;
    //private int _currentHealth;

    //public int CurrentHealthPlayer
    //{
    //    get => CurrentHealth;
    //    set => CurrentHealth = _currentHealth;
    //}

    //public int MaxHealthPlayer
    //{
    //    get => MaxHealth;
    //    set => MaxHealth = _playerHealth;
    //}

    public void PlayerTakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public void PlayerHeal(int healAmount)
    {
        base.TakeDamage(healAmount);
    }

    protected override void HandleDeath()
    {
        Debug.Log("Player Die");
    }
}
