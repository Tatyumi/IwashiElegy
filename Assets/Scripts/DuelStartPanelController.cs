using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class DuelStartPanelController : MonoBehaviour
{
    /// <summary>計測時間</summary>
    private float delta;
    /// <summary>待機時間</summary>
    private const float waitTime = 3.0f;

    private void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 一定時間経ったか判別
        if (delta > waitTime)
        {
            // 一定時間経った場合

            // TODO シーン遷移


        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 初期値代入
        delta = 0.0f;
    }
}
