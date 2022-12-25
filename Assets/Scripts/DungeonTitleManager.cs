using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonTitleManager : MonoBehaviour
{
    [SerializeField]
    Button startButton;

    // Start is called before the first frame update
    private void Start()
    {
        DungeonSoundManager.Instance.PlayBGM(DungeonSoundManager.BGMType.DungeonTitleBGM);
        DungeonScoreManager.Instance.DungeonScoreInit();

        startButton.onClick.AddListener( ()=> {
            SceneTransitionManager.Instance.SceneLoad("SampleScene");
        });
    }
    
}
