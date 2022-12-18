using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ItemPotion : MonoBehaviour
{
    public PotionBase Potion;

    [SerializeField]
    private string potionName = string.Empty;

    [SerializeField]
    private int healAmount;

    private void Awake()
    {
        Potion = new PotionBase(potionName, ItemBase.ItemTypes.Portion, healAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<PlayerParameterBase>())
        if (collision.transform.GetComponent<PlayerCharacterBase>())
        {
            var playerParam = collision.gameObject.GetComponent<PlayerParameterBase>();
            playerParam.Heal(Potion.GetHealAmount);
            var transformInt = Vector3Int.FloorToInt(this.transform.position);
            StartCoroutine(EraseItemPotionTile(transformInt));
        }
    }

    // アイテム：ポーションを削除する
    private IEnumerator EraseItemPotionTile(Vector3Int transformInt) {
        // 1フレームが終わるまで待つ
        yield return new WaitForEndOfFrame();
        this.transform.parent.GetComponent<Tilemap>().SetTile(transformInt, null);
    }
}
