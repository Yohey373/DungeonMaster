using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonResultManager : MonoBehaviour
{
    [SerializeField]
    Button resultButton;

    // Start is called before the first frame update
    private void Start()
    {
        DungeonSoundManager.Instance.PlayBGM(DungeonSoundManager.BGMType.DungeonResultBGM);

        resultButton.onClick.AddListener( ()=> {
            SceneTransitionManager.Instance.SceneLoad("TitleScene");
        });
    }
}
