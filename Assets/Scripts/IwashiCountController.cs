using UnityEngine;
using UnityEngine.UI;

public sealed class IwashiCountController : MonoBehaviour
{
    /// <summary>イワシの数</summary>
    public static int IwashiCount;
    /// <summary>いわしポイント</summary>
    public static int iwashiPoint;
    /// <summary>トータルでいわしを捕まえた数</summary>
    public static int TotalIwashiCount;
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

    /// <summary>
    /// いわし減算処理
    /// </summary>
    /// <param name="killCount">撃破数</param>
    /// <param name="meterDamage">メーターダメージ量</param>
    public static void SubtractIwashi(int killCount , float meterDamage)
    {
        // 減算
        IwashiCount -= killCount;

        // いわしの数が0以下か判別
        if (IwashiCount < 0)
        {
            // 0以下の場合

            // 0を代入する
            IwashiCount = 0;
        }

        // イワシの数を代入
        iwashiCountText.text = IwashiCount.ToString();

        // メーター減算処理
        iwashiMeter.SubtractMeter(meterDamage);
    }
}