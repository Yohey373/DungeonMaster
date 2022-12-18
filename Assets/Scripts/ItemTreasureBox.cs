using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemTreasureBox : MonoBehaviour
{
    public TreasureBoxBase TreasureBox;

    [SerializeField]
    private string treasureName = string.Empty;

    [SerializeField]
    private int scoreAmount;

    private void Awake()
    {
        TreasureBox = new TreasureBoxBase(treasureName, ItemBase.ItemTypes.TreasureBox, scoreAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            DungeonScoreManager.Instance.AddDungeonScore(TreasureBox.GetScoreAmount);
            var transformInt = Vector3Int.FloorToInt(this.transform.position);
            StartCoroutine(EraseItemTreasureBoxTile(transformInt));
        }
    }

    // アイテム：宝箱を削除する
    private IEnumerator EraseItemTreasureBoxTile(Vector3Int transformInt)
    {
        // 1フレームが終わるまで待つ
        yield return new WaitForEndOfFrame();
        this.transform.parent.GetComponent<Tilemap>().SetTile(transformInt, null);
    }
}