using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHPGauge : GaugeBase
{
    public CharacterParameterBase CharacterParameter;

    private float hpRate = 0f;

    private RectTransform gaugeRectTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        hpRate = CharacterParameter.GetHitPoint / CharacterParameter.GetMaxHitPoint;
        SetGauge(hpRate);
        gaugeRectTransform = this.transform.parent.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // gaugeRectTransformをCharacterParameterの位置として追従する
        gaugeRectTransform.position 
            = RectTransformUtility.WorldToScreenPoint(Camera.main, 
            CharacterParameter.gameObject.transform.position + new Vector3(0, 1));
        // 現状のhpRateと計算結果が一緒なら早期リターン
        if (hpRate == CharacterParameter.GetHitPoint /CharacterParameter.GetMaxHitPoint)
        {
            return;
        }
        hpRate = CharacterParameter.GetHitPoint / CharacterParameter.GetMaxHitPoint;
        SetGauge(hpRate);
    }
}
