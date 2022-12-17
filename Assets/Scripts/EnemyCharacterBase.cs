using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterBase : CharacterBase
{
    private System.Random rand = null;
    private int reqFloorAmount = 0;

    private bool isChase = false;

    private int chaseDirection = 0;
    float playerDiff = 10f;

    private int enemyActionCount = 0;

    private Vector2 startPos = new Vector2(0, 0);

    [SerializeField]
    float seed = 1f;

    void Start()
    {

        if (rand == null)
        {
            rand = new System.Random(seed.GetHashCode());
        }

        reqFloorAmount = (((MapGenerator.map.GetUpperBound(1) + 1) * (MapGenerator.map.GetUpperBound(0) + 1)) * 50) / 100;

        var enemyPos = rand.Next(reqFloorAmount);
        Debug.Log(enemyPos);

        // �J�E���g��0����X�^�[�g���������̂�-1����J�E���g�A�b�v�����Ă����B
        var posCount = -1;
        // GetUpperBound(0)�͂��̎����̍Ō�̒l�̏ꏊ��Ԃ�
        for (int x = 0; x < MapGenerator.map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < MapGenerator.map.GetUpperBound(1); y++)
            {
                // map�̍��W���󂢂Ă����startPos��nextStagePos�̏ꍇ�ɂ����̍��W��ύX����
                if (MapGenerator.map[x, y] == 0)
                {
                    posCount++;
                    if (posCount == enemyPos)
                    {
                        startPos = new Vector2(x, y);
                        this.transform.position = startPos;
                    }
                }
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            isChase = true;
            Vector3 v = (collision.transform.position - this.transform.position).normalized;
            playerDiff = (collision.transform.position - this.transform.position).magnitude;
            var face = Vector3Int.zero;

            // ������荶�Ƀv���C���[������
            if (v.x < 0)
            {
                chaseDirection = (int)Arrow.Left;
                face = Vector3Int.left;
            }
            // �������E�Ƀv���C���[������
            if (v.x > 0)
            {
                chaseDirection = (int)Arrow.Right;
                face = Vector3Int.right;
            }
            // ������艺�Ƀv���C���[������
            if (v.y < 0)
            {
                chaseDirection = (int)Arrow.Down;
                face = Vector3Int.down;
            }
            // ��������Ƀv���C���[������
            if (v.y > 0)
            {
                chaseDirection = (int)Arrow.Up;
                face = Vector3Int.up;
            }
            if (playerDiff <= 2)
            {
                base.LookToDirection(face);
            }
        }
    }

    // ���G�͈͂���o���ꍇ�͒ǐՃ��[�h���O��
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            isChase = false;
        }
    }
    
    public override void Update()
    {
        if (GameTurnManager.playerActionCount != enemyActionCount)
        {
            enemyActionCount++;
            if (isChase)
            {
                if (playerDiff <= 2)
                {
                    base.IsAttack = true;
                }
                else
                {
                    base.SetArrowState((Arrow)chaseDirection);
                }
            }

            var rand = Random.Range(0, 5);
            switch (rand)
            {
                case 0:
                    base.SetArrowState(Arrow.Left);
                    break;
                case 1:
                    base.SetArrowState(Arrow.Up);
                    break;
                case 2:
                    base.SetArrowState(Arrow.Down);
                    break;
                case 3:
                    base.SetArrowState(Arrow.Right);
                    break;
                case 4:
                    base.IsAttack = true;
                    break;
            }
        }
        
        base.Update();
    }

}
