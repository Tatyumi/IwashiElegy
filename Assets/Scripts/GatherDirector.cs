using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherDirector : MonoBehaviour
{
    /// <summary>UIオブジェクトリスト</summary>
    public GameObject[] UIObjects;
    /// <summary>いわしジェネレーターリスト</summary>
    public GameObject[] IwashiGenerators;
    /// <summary>お邪魔ジェネレーターリスト</summary>
    public GameObject[] OjamaGenerators;
    /// <summary>スタートカンバスオブジェクト</summary>
    public GameObject GatherStartPanel;
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
        // UIオブジェクトを非表示にする
        WaveDirector.GameObjectsSwtichActive(UIObjects, false);

        // ジェネレーターを非表示にする
        WaveDirector.GameObjectsSwtichActive(IwashiGenerators, false);
        WaveDirector.GameObjectsSwtichActive(OjamaGenerators, false);

        // 表示
        GatherStartPanel.SetActive(true);

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

        // UIオブジェクトを表示
        WaveDirector.GameObjectsSwtichActive(UIObjects, true);

        // 進捗に応じたジェネレーターを表示
        WaveDirector.GameObjectsPhaseActive(IwashiGenerators);
        WaveDirector.GameObjectsPhaseActive(OjamaGenerators);

        // 非表示
        GatherStartPanel.SetActive(false);
    }
}
