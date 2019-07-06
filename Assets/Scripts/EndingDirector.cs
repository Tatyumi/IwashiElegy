using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingDirector : MonoBehaviour
{
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();

        // BGM再生
        audioManager.PlayBGM(audioManager.EndingBGM.name);
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