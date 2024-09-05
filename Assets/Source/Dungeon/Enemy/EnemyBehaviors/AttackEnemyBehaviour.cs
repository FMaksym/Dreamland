using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyBehaviour : MonoBehaviour
{
    [SerializeField] private EnemyData _enemyData;
    [SerializeField] private Animator _animator;

    private void Start()
    {
        
    }

    public void Attack(EnemyAttack enemyAttack)
    {
        enemyAttack.Attack(_enemyData, _animator);
    }
}
