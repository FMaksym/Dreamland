using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthSystem
{
    public delegate void EnemyDeath(GameObject gameObject);
    public event EnemyDeath OnEnemyDeath;

    [SerializeField] private EnemyData _enemyData;

    [SerializeField] private int MaxHealthEnemy => _enemyData.maxHealth;

    //[SerializeField] private int _enemyHealth => _enemyData.maxHealth;

    //public int CurrentHealthEnemy
    //{
    //    get => CurrentHealth;
    //    set => CurrentHealth = MaxHealth;
    //}

    //public int MaxHealthEnemy
    //{
    //    get => MaxHealth;
    //    set => MaxHealth = _enemyHealth;
    //}

    private void Start()
    {
        MaxHealth = MaxHealthEnemy;
        CurrentHealth = MaxHealthEnemy;

        //Debug.Log($"I am {_enemyData.enemyName} number 2 and my current health now is {CurrentHealth} and {MaxHealth}");
    }

    public void EnemyTakeDamage(int damage)
    {
        base.TakeDamage(damage);
    }

    public void EnemyHeal(int healAmount)
    {
        base.Heal(healAmount);
    }

    protected override void HandleDeath()
    {
        OnEnemyDeath?.Invoke(gameObject);
        Debug.Log("Player Die");
    }
}
