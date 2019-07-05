using System.Collections.Generic;
using UnityEngine;

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    /// <summary>イワシ捕獲SE</summary>
    public AudioClip CatchIwashiSE;
    /// <summary>終了ドラムSE</summary>
    public AudioClip EndDrumSE;
    /// <summary>タイトルSE</summary>
    public AudioClip TitleSE;
    /// <summary>タイトルコールSE</summary>
    public AudioClip TitleCallSE;
    /// <summary>全SE保持ディクショナリ</summary>
    private Dictionary<string, AudioClip> SEDic;
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
            { TitleSE.name, TitleSE },
            { TitleCallSE.name, TitleCallSE }
        };
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
