using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Common;

public class EndRollTextController : MonoBehaviour
{
    public GameObject[] TotalIwashiText;
    /// <summary>テキストのスクロールスピード</summary>
    private const float textScrollSpeed = 30.0f;
    /// <summary>制限座標</summary>
    private const float limitPosition = 454.0f;
    /// <summary>終了フラグ</summary>
    private bool isEnd = false;
    /// <summary>経過時間</summary>
    private float delta = 0.0f;
    /// <summary>待機時間</summary>
    private float waitTime = 9.0f;
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
        // イントロダクションが終了したか判別
        if (isEnd)
        {
            // 終了した場合

            // 時間計測
            delta += Time.deltaTime;

            // 指定の時間経過したか判別
            if(delta > waitTime)
            {
                // 経過した場合

                // 音を停止
                audioManager.StopSound();

                // タイトルシーンに遷移
                SceneManager.LoadScene(SceneName.TITLE_SCENE);
            }
        }
        else
        {
            // 終了していない場合

            // 制限座標を超えていないか判別
            if (transform.localPosition.y <= limitPosition)
            {
                // 超えていない場合

                // y座標に移動する
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            }
            else
            {
                // 超えた場合

                // いわし合計値テキストの表示
                WaveDirector.GameObjectsSwtichActive(TotalIwashiText, true);

                // 捕まえた合計値をテキストに表示する
                TotalIwashiText[1].GetComponent<Text>().text = IwashiCountController.TotalIwashiCount.ToString();

                // フラグを更新する
                isEnd = true;
            }
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // フラグ初期化
        isEnd = false;

        // 初期化
        delta = 0.0f;

        // 音楽データ取得
        audioManager = AudioManager.Instance;

        // いわし合計値テキストの非表示
        WaveDirector.GameObjectsSwtichActive(TotalIwashiText, false);
    }
}
