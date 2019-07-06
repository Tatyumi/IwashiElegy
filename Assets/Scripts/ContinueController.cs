using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class ContinueController : MonoBehaviour
{
    /// <summary>
    /// ゲームを再開する
    /// </summary>
    public void Continue()
    {
        // ウェーブシーンに遷移
        SceneManager.LoadScene(SceneName.WAVE_SCENE);
    }

    /// <summary>
    /// タイトル画面に戻る
    /// </summary>
    public void GiveUp()
    {
        // タイトルシーンに遷移
        SceneManager.LoadScene(SceneName.TITLE_SCENE);
    }
}
