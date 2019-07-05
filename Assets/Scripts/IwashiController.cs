using UnityEngine;

public class IwashiController : MonoBehaviour, IApplableScore
{
    /// <summary>移動速度</summary>
    private Vector2 moveSpeed = new Vector2(-3, 0);
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;
    /// <summary>最大移動x座標</summary>
    private float maxMovePosX;
    /// <summary>最大移動Y座標</summary>
    private float maxMovePosY;

    void Start()
    {
        // 初期化処理
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームが終了しているか判別
        if (!TimeLimtController.isEnd)
        {
            // 終了していない場合

            // 移動
            UpdateMove();
        }

        // 画面外か判別
        if (transform.position.x > maxMovePosX || transform.position.x < 0
            || transform.position.y > maxMovePosY || transform.position.y < 0)
        {
            // 画面外の場合

            // 破棄
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    void Initialize()
    {
        // 音楽データ取得
        audioManager = AudioManager.Instance;

        // x,y座標のの最大値取得
        maxMovePosX = Screen.width;
        maxMovePosY = Screen.height;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void UpdateMove()
    {
        transform.Translate(moveSpeed);
    }

    /// <summary>
    /// スコア適応処理
    /// </summary>
    public void ApplyScore()
    {
        // イワシ加算処理
        IwashiCountController.AddIwashi();

        // SE再生
        audioManager.PlaySE(audioManager.CatchIwashiSE.name);

        // 破棄
        Destroy(gameObject);
    }
}
