using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    /// <summary>イワシ捕獲SE</summary>
    public AudioClip CatchIwashiSE;
    /// <summary>終了ドラムSE</summary>
    public AudioClip EndDrumSE;
    /// <summary>開始ドラムSE</summary>
    public AudioClip StartDrumSE;
    /// <summary>タイトルSE</summary>
    public AudioClip TitleSE;
    /// <summary>タイトルコールSE</summary>
    public AudioClip TitleCallSE;
    /// <summary>敵キャラ発見SE </summary>
    public AudioClip EnemyNoticeSE;
    /// <summary>敵キャラ拡大SE</summary>
    public AudioClip EnemyUpSE;
    /// <summary>気合SE </summary>
    public AudioClip KiaiSE;
    /// <summary>決闘SE</summary>
    public AudioClip DuelSE;
    /// <summary>勝利SE</summary>
    public AudioClip WinSE;
    /// <summary>敗北SE</summary>
    public AudioClip LoseSE;
    /// <summary>オープニングBGM</summary>
    public AudioClip OpeningBGM;
    /// <summary>集会BGM</summary>
    public AudioClip GatherBGM;
    /// <summary>全SE保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> SEDic;
    /// <summary>全BGM保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> BGMDic;
    /// <summary>オーディオソース</summary>
    AudioSource audioSource;

    private void Awake()
    {
        // 存在確認
        if (this != Instance)
        {
            Destroy(this);
            return;
        }

        // AudioSourceコンポーネントの取得
        audioSource = gameObject.GetComponent<AudioSource>();

        // SEを格納
        SEDic = new Dictionary<string, AudioClip>
        {
            { CatchIwashiSE.name, CatchIwashiSE },
            { EndDrumSE.name, EndDrumSE },
            { StartDrumSE.name, StartDrumSE },
            { TitleSE.name, TitleSE },
            { EnemyNoticeSE.name, EnemyNoticeSE },
            { EnemyUpSE.name, EnemyUpSE },
            { KiaiSE.name, KiaiSE },
            { DuelSE.name, DuelSE },
            { WinSE.name, WinSE },
            { LoseSE.name, LoseSE },
            { TitleCallSE.name, TitleCallSE }
        };

        // BGMを格納
        BGMDic = new Dictionary<string, AudioClip>
        {
            { OpeningBGM.name, OpeningBGM },
            { GatherBGM.name, GatherBGM }
        };
    }

    /// <summary>
    /// BGMの再生
    /// </summary>
    /// <param name="BGMName">BGMの名前</param>
    public void PlayBGM(string BGMName)
    {
        // 名前の存在チェック
        if (!BGMDic.ContainsKey(BGMName))
        {
            // 該当しない場合

            // ログを表示
            Debug.Log(BGMName + "という名前のBGMがありません");
            return;
        }

        // BGMの再生
        audioSource.clip = BGMDic[BGMName] as AudioClip;
        audioSource.Play();
    }

    /// <summary>
    /// SEの再生
    /// </summary>
    /// <param name="SEName">SEの名前</param>
    public void PlaySE(string SEName)
    {
        // 名前の存在チェック
        if (!SEDic.ContainsKey(SEName))
        {
            // 該当しない場合

            // ログを表示
            Debug.Log(SEName + "という名前のSEがありません");
            return;
        }

        // SEの再生
        audioSource.PlayOneShot(SEDic[SEName]);
    }

    /// <summary>
    /// 音を停止
    /// </summary>
    public void StopSound()
    {
        // 再生中の音をすべて停止する
        audioSource.Stop();
    }
}
