using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AttackState : State
{
    public PlayerDetectionInRadius _playerDetection;

    public EnemyAttack enemyAttack;
    public AttackEnemyBehaviour _attackBehaviour;

    public IdleState idleState;
    public ChaseState chaseState;

    public override State RunCurrentState()
    {
        if (_playerDetection.IsPlayerDetectedForChase() && _playerDetection.IsPlayerDetectedForAttack())
        {
            _attackBehaviour.Attack(enemyAttack);
            Debug.Log("Attack!!!!!");
            //return this;
            return idleState;
        }
        else if (_playerDetection.IsPlayerDetectedForChase() && !_playerDetection.IsPlayerDetectedForAttack())
        {
            Debug.Log("I change attack to chase");
            return chaseState;
        }
        else
        {
            Debug.Log("I change chase to idle");
            return idleState;
        }
    }
}
