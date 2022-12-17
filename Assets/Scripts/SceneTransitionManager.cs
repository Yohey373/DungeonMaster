using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンをロードする処理の責任はこのスクリプトしか持たない
/// </summary>
public class SceneTransitionManager : SingletonMonoBehaviour<SceneTransitionManager>
{
    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}