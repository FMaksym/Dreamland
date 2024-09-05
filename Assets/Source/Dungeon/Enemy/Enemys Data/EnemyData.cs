using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data")]
public class EnemyData : ScriptableObject
{
    public enum AttackType
    {
        Melee,
        Ranged,
        Magic
    }

    public AttackType attackType;
    public string enemyName;
    public int health;
    public int maxHealth;
    public int damage;
    public float movementSpeed;
    public float attackFrequency;
    public float attackRadius;
    public float detectionRadius;
    public float idleRadius;
    public float idleDuration;
    public float rotationSpeed;
}
