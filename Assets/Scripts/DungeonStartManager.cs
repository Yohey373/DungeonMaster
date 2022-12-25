using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonStartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DungeonSoundManager.Instance.PlayBGM(DungeonSoundManager.BGMType.DungeonAttackBGM);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
