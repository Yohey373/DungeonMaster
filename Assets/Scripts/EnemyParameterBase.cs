using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyParameterBase : MonoBehaviour
{
    public CharacterParameterBase EnemyCharacterParameter;

    [SerializeField]
    private int hitPoint;

    [SerializeField]
    private int attackPoint;

    // Start is called before the first frame update
    private void Awake()
    {
        EnemyCharacterParameter = new CharacterParameterBase(hitPoint, attackPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
