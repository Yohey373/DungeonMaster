using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] Enemy = new GameObject[2];

    public void EnemySpawn(Vector2 spawnPos, EnemyParameterBase.EnemyType enemyType) {
        var enemy = Instantiate(Enemy[(int)enemyType]);
        enemy.transform.position = spawnPos;
    }
}