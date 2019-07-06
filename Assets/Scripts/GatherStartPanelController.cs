using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherStartPanelController : MonoBehaviour
{
    /// <summary>全てのゲームオブジェクト</summary>
    public GameObject[] AllGameObjects;
    /// <summary>経過時間</summary>
    private float delta;
    /// <summary>目標時間</summary>
    private const float targetTime = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化処理
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // 時間計測
        delta += Time.deltaTime;

        // 目標時間経ったか判別
        if(delta > targetTime)
        {
            // 経った場合

            // 全てのゲームオブジェクトを表示にする
            WaveDirector.GameObjectsSwtichActive(AllGameObjects, true);

            // 集会開始パネルを非表示にする
            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 全てのゲームオブジェクトを非表示にする
        WaveDirector.GameObjectsSwtichActive(AllGameObjects, false);

        // 初期値代入
        delta = 0.0f;
    }
}
