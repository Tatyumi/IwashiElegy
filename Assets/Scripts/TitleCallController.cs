using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class TitleCallController : MonoBehaviour
{
    /// <summary>フェードスピード</summary>
    private float fadeSpeed = 0.01f;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>目標アルファ値</summary>
    private float targetAlpha = 0.8f;
    /// <summary>アクションパネル</summary>
    private Image ActionPanel;
    /// <summary>色(RGB)</summary>
    private float red, green, blue;
    /// <summary>アルファ値</summary>
    private float alpha = 0.0f;
    /// <summary>経過時間</summary>
    private float delta;
    /// <summary>タイトルコールフラグ</summary>
    private bool isTitleCall;

    // Start is called before the first frame update
    private void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    private void Update()
    {
        // ゲームオブジェクトの活性状態チェック
        if (gameObject.activeSelf)
        {
            // 活性状態の場合

            // フラグ判別
            if (!isTitleCall)
            {
                // falseの場合

                // SE再生
                audioManager.PlaySE(audioManager.TitleCallSE.name);

                // フラグ更新
                isTitleCall = true;
            }

            // アルファ値を加算しフェードインする
            ActionPanel.color = new Color(red, green, blue, alpha);
            alpha += fadeSpeed;

            // 一定のアルファ値に達した場合
            if (ActionPanel.color.a >= targetAlpha)
            {
                // 時間計測
                delta += Time.deltaTime;
            }
        }

        // 一定時間経過したか判別
        if (delta > 3.0f)
        {
            // 経過した場合

            // TODO シーン遷移処理
            Debug.Log("しーんせんい");
        }
    }

    // 初期化処理
    private void Initialize()
    {
        // imageコンポーネントの取得
        ActionPanel = gameObject.GetComponent<Image>();

        // imageの色(RGB)の値を取得
        red = ActionPanel.color.r;
        green = ActionPanel.color.g;
        blue = ActionPanel.color.b;

        // 音楽データの取得
        audioManager = AudioManager.Instance;

        // 初期値代入
        delta = 0.0f;
        isTitleCall = false;

        // ゲームオブジェクトを非表示
        gameObject.SetActive(false);
    }
}