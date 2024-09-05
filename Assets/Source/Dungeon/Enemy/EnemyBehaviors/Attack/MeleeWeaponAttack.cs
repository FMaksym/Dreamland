using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponAttack : EnemyAttack
{
    public override void Attack(EnemyData enemyData, Animator enemyAnimator)
    {
        enemyAnimator.SetTrigger("Attack");
        return;
    }
}
