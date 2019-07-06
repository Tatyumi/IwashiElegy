using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherDirector : MonoBehaviour
{
    /// <summary>全てのゲームオブジェクト</summary>
    public GameObject[] AllGameObjects;
    /// <summary>スタートカンバスオブジェクト</summary>
    public GameObject StartCanvas;
    /// <summary>目標時間</summary>
    private const float targetTime = 3.0f;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Awake()
    {
        // 初期化処理
        Initialize();

        // コルーチン取得
        var corutine = StartGame();

        // コルーチン開始
        StartCoroutine(corutine);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 全てのゲームオブジェクトを非表示にする
        WaveDirector.GameObjectsSwtichActive(AllGameObjects, false);

        // 表示
        StartCanvas.SetActive(true);

        // 音楽データ取得
        audioManager = AudioManager.Instance;
    }


    private IEnumerator StartGame()
    {
        // 開始SE
        audioManager.PlaySE(audioManager.StartDrumSE.name);

        // 待機時間
        var wait = new WaitForSeconds(2);

        yield return wait;

        // BGM再生
        audioManager.PlayBGM(audioManager.GatherBGM.name);

        // 全てのゲームオブジェクトを表示
        WaveDirector.GameObjectsSwtichActive(AllGameObjects, true);

        // 非表示
        StartCanvas.SetActive(false);
    }
}
