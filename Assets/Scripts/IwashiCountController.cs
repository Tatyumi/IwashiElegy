using UnityEngine;
using UnityEngine.UI;

public sealed class IwashiCountController : MonoBehaviour
{
    /// <summary>イワシの数</summary>
    public static int IwashiCount;
    /// <summary>イワシの数表示テキスト</summary>
    private static Text iwashiCountText;

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

        // コンポーネントの取得
        iwashiCountText = gameObject.GetComponent<Text>();

        // イワシの数を代入
        iwashiCountText.text = IwashiCount.ToString();
    }

    /// <summary>
    /// イワシ加算処理
    /// </summary>
    public static void AddIwashi()
    {
        // 加算
        IwashiCount++;

        // イワシの数を代入
        iwashiCountText.text = IwashiCount.ToString();
    }
}
