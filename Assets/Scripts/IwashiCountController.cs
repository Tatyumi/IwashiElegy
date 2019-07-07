﻿using UnityEngine;
using UnityEngine.UI;

public sealed class IwashiCountController : MonoBehaviour
{
    /// <summary>イワシの数</summary>
    public static int IwashiCount;
    /// <summary>いわしポイント</summary>
    public static int iwashiPoint;
    /// <summary>いわしメーター</summary>
    public GameObject IwashiMeter;
    /// <summary>イワシの数表示テキスト</summary>
    private static Text iwashiCountText;
    /// <summary>いわしメーターコントローラー</summary>
    private static IwashiMeterController iwashiMeter;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理
        Initialize();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 初期値代入
        IwashiCount = 0;
        iwashiPoint = 1;

        // コンポーネントの取得
        iwashiCountText = gameObject.GetComponent<Text>();
        iwashiMeter = IwashiMeter.GetComponent<IwashiMeterController>();

        // イワシの数を代入
        iwashiCountText.text = IwashiCount.ToString();
    }

    /// <summary>
    /// イワシ加算処理
    /// </summary>
    public static void AddIwashi()
    {
        // 加算
        IwashiCount += iwashiPoint;

        // イワシの数を代入
        iwashiCountText.text = IwashiCount.ToString();

        // メーター加算
        iwashiMeter.AddMeter();
    }
}
