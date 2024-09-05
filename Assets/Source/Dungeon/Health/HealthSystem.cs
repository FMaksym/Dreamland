using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int _currentHealth;
    private int _maxHealth;

    public int CurrentHealth
    {
        get => _currentHealth;
        protected set
        {
            if (value < 0)
            {
                _currentHealth = 0;
                HandleDeath();
                //throw new ArgumentException("Health value cannot be negative.", nameof(CurrentHealth));
            }
            if (value > MaxHealth)
            {
                _currentHealth = MaxHealth;
            }
            else
            {
                _currentHealth = value;
            }
        }
    }

    public int MaxHealth
    {
        get => _maxHealth;
        protected set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Max health value must be positive.", nameof(MaxHealth));
            }
            _maxHealth = value;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0)
        {
            damageAmount = 0;
            //throw new ArgumentException("Damage amount cannot be negative.", nameof(damageAmount));
        }

        CurrentHealth -= damageAmount;
    }

    public void Heal(int healAmount)
    {
        if (healAmount < 0)
        {
            healAmount = 0;
            //throw new ArgumentException("Heal amount cannot be negative.", nameof(healAmount));
        }

        CurrentHealth += healAmount;
    }

    protected virtual void HandleDeath()
    {
    }
}
