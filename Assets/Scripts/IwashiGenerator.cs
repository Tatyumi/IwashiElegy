using UnityEngine;

public class IwashiGenerator : MonoBehaviour
{
    /// <summary>生成間隔</summary>
    public GeneratData GeneratData;
    /// <summary>キャンバス</summary>
    public GameObject Canvas;
    /// <summary>イワシプレファブ</summary>
    public GameObject IwashiPrefab;
    /// <summary>計測時間</summary>
    private float delta = 0.0f;
    /// <summary>最小y座標</summary>
    protected float minGeneratPosY;
    /// <summary>最大y座標</summary>
    protected float maxGeneratPosY;
    /// <summary>生成x座標</summary>
    protected float generatPosX;


    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームが終了しているか判別
        if (!TimeLimtController.isEnd)
        {
            // 終了していない場合

            // 時間計測
            delta += Time.deltaTime;

            // 一定時間経過したか判別
            if (delta > GeneratData.span)
            {
                // 経過した場合

                // 初期化
                delta = 0.0f;

                // オブジェクト生成
                GeneratObj();
            }
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected virtual void Initialize()
    {
        // 最小、最大のy座標を取得
        maxGeneratPosY = Screen.height;
        minGeneratPosY = 0;

        // 生成するX座標の取得
        generatPosX = Screen.width;
    }

    /// <summary>
    /// オブジェクト生成処理
    /// </summary>
    private void GeneratObj()
    {
        // 生成するプレファブをゲームオブジェクトに変換
        var iwashiObj = Instantiate(IwashiPrefab) as GameObject;

        // ゲームオブジェクトをCanVasの子にする
        iwashiObj.transform.SetParent(Canvas.transform, false);

        // 生成する座標を取得
        var generatPos = new Vector2(generatPosX, Random.Range(minGeneratPosY, maxGeneratPosY));

        // ゲームオブジェクトを指定の座標に配置
        iwashiObj.transform.SetPositionAndRotation(generatPos, transform.rotation);
    }
}