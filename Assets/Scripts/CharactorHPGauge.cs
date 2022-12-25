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
        // gaugeRectTransform��CharacterParameter�̈ʒu�Ƃ��ĒǏ]����
        gaugeRectTransform.position 
            = RectTransformUtility.WorldToScreenPoint(Camera.main, 
            CharacterParameter.gameObject.transform.position + new Vector3(0, 1));
        // �����hpRate�ƌv�Z���ʂ��ꏏ�Ȃ瑁�����^�[��
        if (hpRate == CharacterParameter.GetHitPoint /CharacterParameter.GetMaxHitPoint)
        {
            return;
        }
        hpRate = CharacterParameter.GetHitPoint / CharacterParameter.GetMaxHitPoint;
        SetGauge(hpRate);
    }
}
