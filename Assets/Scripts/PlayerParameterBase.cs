using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParameterBase : MonoBehaviour
{
    public CharacterParameterBase PlayerParameter;

    [SerializeField]
    private int hitPoint;

    [SerializeField]
    private int attackPoint;

    // Start is called before the first frame update
    private void Awake()
    {
        PlayerParameter = new CharacterParameterBase(hitPoint, attackPoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
