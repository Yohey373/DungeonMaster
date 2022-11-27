using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterBase : MonoBehaviour
{
    private System.Random rand = null;
    private int reqFloorAmount = 0;

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



}
