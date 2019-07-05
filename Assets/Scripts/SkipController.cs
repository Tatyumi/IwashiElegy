using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class SkipController : MonoBehaviour
{
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Update is called once per frame
    void Update()
    {
        // 左クリック押下判別
        if (Input.GetMouseButtonDown(0))
        {
            // 左クリックした場合

            // 音停止
            audioManager.StopSound();

            // 集会シーンに遷移
            SceneManager.LoadScene(SceneName.GATHER_SCENE);
        }
    }
}
