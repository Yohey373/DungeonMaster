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

    private void Start()
    {
        // �_���W�����̋L��������̂ł�������hitpoint���擾����
        if (DungeonMemoryManager.Instance.GetplayerHitPoint != 0)
        {
            base.HitPoint = DungeonMemoryManager.Instance.GetplayerHitPoint;
            base.maxHitPoint = DungeonMemoryManager.Instance.GetPlayerMaxHitPoint;
            base.AttackPoint = DungeonMemoryManager.Instance.GetPlayerAttackPoint;
        }
        else
        {
            base.HitPoint = playerHitPoint;
            base.maxHitPoint = base.HitPoint;
            base.AttackPoint = playerAttackPoint;
        }
    }

}
