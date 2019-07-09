using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeLimtController : MonoBehaviour
{
    /// <summary>決闘開始パネル</summary>
    public GameObject DuelStartPanel;
    /// <summary>終了フラグ</summary>
    public static bool isEnd;
    /// <summary>制限時間</summary>
    private float timeLimit;
    /// <summary>制限時間テキスト</summary>
    private Text timeLimitText;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;


    private void Awake()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 終了フラグチェック
        if (!isEnd)
        {
            // falseの場合(終了していない)

            // 時間計測
            timeLimit -= Time.deltaTime;

            //時間表示
            timeLimitText.text = timeLimit.ToString("0.0");

            if (timeLimit < 0.0f)
            {
                // 時間を指定
                timeLimit = 0.0f;

                //時間表示
                timeLimitText.text = timeLimit.ToString("0.0");

                // ゲーム終了
                isEnd = true;

                // 音停止
                audioManager.StopSound();

                // SE再生
                audioManager.PlaySE(audioManager.EndDrumSE.name);

                // 表示
                DuelStartPanel.SetActive(true);
            }
        }
    }

    /// <summary>初期化処理</summary>
    private void Initialize()
    {
        // コンポーネント取得
        timeLimitText = gameObject.GetComponent<Text>();

        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // 初期値値代入
        timeLimit = 15.0f * (WaveDirector.Phase + 1);
        isEnd = false;

        // 非表示
        DuelStartPanel.SetActive(false);

        // 時間取得
        timeLimitText.text = timeLimit.ToString();
    }
}
