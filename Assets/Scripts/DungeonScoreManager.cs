using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonScoreManager : SingletonMonoBehaviour<DungeonScoreManager>
{
    // ダンジョンのスコア。Unity上で確認するためにSerializeField属性をつけている。
    [SerializeField]
    private int dungeonScore = 0;

    // 外部からスコアを取得したい場合に使うアクセサ
    public int GetDungeonScore {

        get { return dungeonScore; }
    }

    // 基本的にはこのメソッドを呼ぶことでスコアを加算していく
    public void AddDungeonScore(int addScore) {
        dungeonScore += addScore;
    }
}