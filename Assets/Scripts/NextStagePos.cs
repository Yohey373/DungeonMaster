using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class NextStagePos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.layer);
        // 侵入してきたgameobjectのlayerがPlayerなら
        if (collision.gameObject.layer == 3)
        {
            
            DungeonScoreManager.Instance.AddDungeonScore(5);
            DungeonMemoryManager.Instance.SetPlayerParameter(collision.gameObject.GetComponent<CharacterParameterBase>());
            DungeonHierarchyCounter.Instance.DungeonHierarchyCountUP();
            SceneTransitionManager.Instance.SceneLoad("SampleScene");

        }
    }
}