using UnityEngine;
using System.Collections;

public class WaveDirector : MonoBehaviour
{
    /// <summary>進捗</summary>
    public static int Phase = 0;
    /// <summary>最大進捗</summary>
    public static int MaxPhase = 2;
    /// <summary>敵のリスト</summary>
    public GameObject[] EnemyLists;
    /// <summary>決まり文句リスト</summary>
    public GameObject[] ClicheLists;
    /// <summary>イワシ</summary>
    public GameObject Iwashi;
    /// <summary>怒ってるイワシ</summary>
    public GameObject AngryIwashi;
    /// <summary>ガイドパネル</summary>
    public GameObject GuidePanel;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();

        // コルーチン取得
        var corutine = StartSkit();

        // コルーチン開始
        StartCoroutine(corutine);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // それぞれ活性状態を初期化
        AngryIwashi.SetActive(false);
        GuidePanel.SetActive(false);
        GameObjectsSwtichActive(EnemyLists, false);
        GameObjectsSwtichActive(ClicheLists, false);

        // 音楽データ取得
        audioManager = AudioManager.Instance;
    }

    /// <summary>
    /// ゲームオブジェクトの配列の活性状態を切り替える
    /// </summary>
    /// <param name="gameObjects">ゲームオブジェクト配列</param>
    /// <param name="activeFlag">活性状態</param>
    public static void GameObjectsSwtichActive(GameObject[] gameObjects, bool activeFlag)
    {
        foreach (var obj in gameObjects)
        {
            // 非活性
            obj.SetActive(activeFlag);
        }
    }

    /// <summary>
    /// 指定した要素番号のオブジェクトを活性状態にする
    /// </summary>
    /// <param name="gameObjectLists">ゲームオブジェクトリスト</param>
    public static void GameObjecsSpecifiedActive(GameObject[] gameObjectLists)
    {
        for (int i = 0; i < gameObjectLists.Length; i++)
        {
            // 該当する番号はtrue
            gameObjectLists[i].SetActive(i == Phase);
        }
    }

    /// <summary>
    /// ゲーム進捗に合わせたオブジェクトを表示する
    /// </summary>
    /// <param name="gameObjectLists"></param>
    public static void GameObjectsPhaseActive(GameObject[] gameObjectLists)
    {
        // 進捗に応じた数値
        var n = gameObjectLists.Length - (MaxPhase - Phase);

        for (int i = 0; i < n; i++)
        {
            // 表示
            gameObjectLists[i].SetActive(true);
        }
    }


/// <summary>
/// 寸劇コルーチン
/// </summary>
/// <returns></returns>
private IEnumerator StartSkit()
    {
        // 表示
        Iwashi.SetActive(true);

        // 敵キャラに気づくSE再生
        audioManager.PlaySE(audioManager.EnemyNoticeSE.name);

        // 待機時間
        var wait = new WaitForSeconds(2);

        yield return wait;

        // 非表示
        Iwashi.SetActive(false);
        // 進捗に合うオブジェクトの表示
        GameObjecsSpecifiedActive(EnemyLists);

        // 敵キャラ拡大SE再生
        audioManager.PlaySE(audioManager.EnemyUpSE.name);

        yield return wait;

        // 非表示
        GameObjectsSwtichActive(EnemyLists, false);
        // 表示
        AngryIwashi.SetActive(true);
        // 進捗に合うオブジェクトの表示
        GameObjecsSpecifiedActive(ClicheLists);
        // 勢いSE再生
        audioManager.PlaySE(audioManager.KiaiSE.name);

        yield return wait;

        // 表示
        GuidePanel.SetActive(true);
    }
}
