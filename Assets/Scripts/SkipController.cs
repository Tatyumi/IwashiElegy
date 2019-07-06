using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class SkipController : MonoBehaviour
{
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 左クリック押下判別
        if (Input.GetMouseButtonDown(0))
        {
            // 左クリックした場合

            // 音停止
            audioManager.StopSound();

            // ウェーブシーンに遷移
            SceneManager.LoadScene(SceneName.WAVE_SCENE);
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 音楽データ取得
        audioManager = AudioManager.Instance;
    }
}
