using UnityEngine;

public sealed class IntroductionController : MonoBehaviour
{
    /// <summary>タイトル画像</summary>
    public GameObject TitleImage;
    /// <summary>テキストのスクロールスピード</summary>
    private const float textScrollSpeed = 55.0f;
    /// <summary>制限座標</summary>
    private const float limitPosition = 663.0f;
    /// <summary>終了フラグ</summary>
    private bool isEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        // イントロダクションが終了したか判別
        if (isEnd)
        {
            // 終了した場合

            // タイトル画像の表示
            TitleImage.SetActive(true);
        }
        else
        {
            // 終了していない場合

            // 制限座標を超えていないか判別
            if (transform.localPosition.y <= limitPosition)
            {
                // 超えていない場合

                // y座標に移動する
                transform.position = new Vector2(transform.position.x, transform.position.y + textScrollSpeed * Time.deltaTime);
            }
            else
            {
                // 超えた場合

                // フラグを更新する
                isEnd = true;
            }
        }
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // フラグ初期化
        isEnd = false;
    }
}
