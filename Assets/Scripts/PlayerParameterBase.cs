using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameterBase : CharacterParameterBase
{
    [SerializeField]
    private int playerHitPoint;

    [SerializeField]
    private int playerAttackPoint;

    private void Awake()
    {
        base.HitPoint = playerHitPoint;
        base.maxHitPoint = base.HitPoint;
        base.AttackPoint = playerAttackPoint;
    }
}
