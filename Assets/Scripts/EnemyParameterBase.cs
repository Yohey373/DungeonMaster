using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameterBase : CharacterParameterBase
{
    public enum EnemyType {
        Invalide =-1,
        Normal,
        High
    }

    [SerializeField]
    private float enemyHitPoint;

    [SerializeField]
    private float enemyAttackPoint;

    private void Awake()
    {
        base.HitPoint = enemyAttackPoint;
        base.maxHitPoint = base.HitPoint;
        base.AttackPoint = enemyAttackPoint;
    }
}
