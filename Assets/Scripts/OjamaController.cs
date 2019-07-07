using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OjamaController : MonoBehaviour, IApplableScore
{
    /// <summary>お邪魔キャラのデータ</summary>
    public OjamaData OjamaData;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    void Start()
    {
        // 初期化
        Initialize();
    }

    void Update()
    {
        // ゲームが終了しているか判別
        if (!TimeLimtController.isEnd)
        {
            // 終了していない場合

            // 移動処理
            transform.Translate(OjamaData.MoveSpeed);
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

    /// <summary>
    /// スコア適応処理
    /// </summary>
    public void ApplyScore()
    {
        // SE再生
        audioManager.PlaySE(audioManager.DamageSE.name);

        // いわしの数を減らす
        IwashiCountController.SubtractIwashi(OjamaData.KillIwashiCount, OjamaData.MeterDamage);

        // 破棄
        Destroy(gameObject);
    }
}