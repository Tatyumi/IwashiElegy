using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;


public class ResultDirector : MonoBehaviour
{
    /// <summary>勝利テキスト</summary>
    public GameObject WinText;
    /// <summary>敗北テキスト</summary>
    public GameObject LoseText;
    /// <summary>コンティニューパネル</summary>
    public GameObject ContinuePanel;
    /// <summary>勝利時の背景</summary>
    public GameObject WinBackGround;
    /// <summary>敗北時の背景</summary>
    public GameObject LoseBackGround;
    /// <summary>勝利した場合の敵キャラリスト</summary>
    public GameObject[] WinEnemyLists;
    /// <summary>敗北した場合の敵キャラリスト</summary>
    public GameObject[] LoseEnemyLists;
    /// <summary>結果フラグ</summary>
    public static bool isResult;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();

        // コルーチン取得
        var corutine = StartJadge();

        // コルーチン開始
        StartCoroutine(corutine);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 非表示
        WinText.SetActive(false);
        LoseText.SetActive(false);
        ContinuePanel.SetActive(false);
        WinBackGround.SetActive(false);
        LoseBackGround.SetActive(false);

        // 音楽データ取得
        audioManager = AudioManager.Instance;
    }

    /// <summary>
    /// 判定開始コルーチン
    /// </summary>
    /// <returns></returns>
    private IEnumerator StartJadge()
    {
        // 音停止
        audioManager.StopSound();

        // 待機時間
        var wait = new WaitForSeconds(5);

        // 勝敗判定
        if (isResult)
        {
            // 勝利した場合

            // 勝利テキストの表示
            WinText.SetActive(true);

            // 進捗にあった敵キャラの表示
            WaveDirector.GameObjecsSpecifiedActive(WinEnemyLists);

            // 背景表示
            WinBackGround.SetActive(true);

            // SE再生
            audioManager.PlaySE(audioManager.WinSE.name);

            yield return wait;

            // ゲーム進行
            WaveDirector.Phase++;

            // 最後までゲームが進んだか判別
            if (WaveDirector.Phase > WaveDirector.MaxPhase)
            {
                // 進んでいる場合

                // Endingシーンに遷移
                SceneManager.LoadScene(SceneName.ENDING_SCENE);
            }
            else
            {
                // ウェーブシーンに遷移
                SceneManager.LoadScene(SceneName.WAVE_SCENE);
            }
        }
        else
        {
            // 敗北した場合

            // 敗北テキストの表示
            LoseText.SetActive(true);

            // 背景表示
            LoseBackGround.SetActive(true);

            // 進捗にあった敵キャラの表示
            WaveDirector.GameObjecsSpecifiedActive(LoseEnemyLists);

            // SE再生
            audioManager.PlaySE(audioManager.LoseSE.name);

            yield return wait;

            // コンティニューパネルを表示
            ContinuePanel.SetActive(true);
        }
    }
}