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

    // Start is called before the first frame update
    private void Awake()
    {
        Potion = new PotionBase(potionName, ItemBase.ItemTypes.Potion, healAmount);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerParameterBase>())
        {
            var playerParam = collision.gameObject.GetComponent<PlayerParameterBase>();
            playerParam.PlayerParameter.Heal(Potion.GetHealAmount);

            var transformInt = Vector3Int.FloorToInt(this.transform.position);
            StartCoroutine(EraseItemPotionTile(transformInt));
            Debug.Log("TriggerEnter");
        }
    }

    private IEnumerator EraseItemPotionTile(Vector3Int transformInt)
    {
        yield return new WaitForEndOfFrame();
        this.transform.parent.GetComponent<Tilemap>().SetTile(transformInt, null);
    }

}
