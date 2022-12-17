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

        // カウントを0からスタートさせたいので-1からカウントアップさせていく。
        var posCount = -1;
        // GetUpperBound(0)はその次元の最後の値の場所を返す
        for (int x = 0; x < MapGenerator.map.GetUpperBound(0); x++)
        {
            for (int y = 0; y < MapGenerator.map.GetUpperBound(1); y++)
            {
                // mapの座標が空いていればstartPosとnextStagePosの場合にそこの座標を変更する
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

            // 自分より左にプレイヤーがいる
            if (v.x < 0)
            {
                chaseDirection = (int)Arrow.Left;
                face = Vector3Int.left;
            }
            // 自分より右にプレイヤーがいる
            if (v.x > 0)
            {
                chaseDirection = (int)Arrow.Right;
                face = Vector3Int.right;
            }
            // 自分より下にプレイヤーがいる
            if (v.y < 0)
            {
                chaseDirection = (int)Arrow.Down;
                face = Vector3Int.down;
            }
            // 自分より上にプレイヤーがいる
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

    // 索敵範囲から出た場合は追跡モードを外す
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            isChase = false;
        }
    }
    
    public override void Update()
    {
        if (GameTurnManager.playerAction)
        {

            if (isChase)
            {
                if (playerDiff <= 2)
                {
                    base.IsPushedSpase = true;
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
                    base.IsPushedSpase = true;
                    break;
            }
        }
        
        base.Update();
    }

}
