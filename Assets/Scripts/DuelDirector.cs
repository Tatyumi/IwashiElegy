using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelDirector : MonoBehaviour
{
    /// <summary>敵リスト</summary>
    public GameObject[] EnemyLists;
    /// <summary>怒ってるイワシたち</summary>
    public Transform AngryIwashiLists;
    /// <summary>決闘開始テキスト</summary>
    public GameObject DuelStartText;
    /// <summary>開始x座標</summary>
    private float StartPosX = 744;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();

        // コルーチン取得
        var corutine = StartBattle();

        // コルーチン開始
        StartCoroutine(corutine);
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // 非表示
        WaveDirector.GameObjectsSwtichActive(EnemyLists, false);

        for (int i = 1; i < AngryIwashiLists.childCount; i++)
        {
            // 怒ってるイワシを一匹のみ表示する
            AngryIwashiLists.GetChild(i).gameObject.SetActive(false);
        }

        // 表示
        DuelStartText.SetActive(true);
    }

    /// <summary>
    /// バトルコルーチン
    /// </summary>
    private IEnumerator StartBattle()
    {
        // 待機時間
        var wait = new WaitForSeconds(2);

        yield return wait;

        // 非表示
        DuelStartText.SetActive(false);

        // 進捗に適した敵を表示する
        WaveDirector.GameObjectListsSpecifiedActive(EnemyLists);

        // 指定の位置に配置
        AngryIwashiLists.localPosition = new Vector2(StartPosX, AngryIwashiLists.localPosition.y);

    }
}
