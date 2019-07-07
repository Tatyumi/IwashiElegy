using UnityEngine;
using UnityEngine.UI;

public class IwashiMeterController : MonoBehaviour
{
    /// <summary>ボーナスナンバーオブジェクト</summary>
    public GameObject BonusNumber;
    /// <summary>ボーナスナンバーテキスト</summary>
    private Text bonusNumberText;
    /// <summary>いわしメーター</summary>
    private Image iwashiMeter;
    /// <summary>レベル</summary>
    private int level;
    /// <summary>ポイント</summary>
    private float point = 0.2f;
    /// <summary>メーターの最大値</summary>
    private float maxMeterValue = 1.0f;
    /// <summary>オーディオマネージャー</summary>
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        // 初期化
        Initialize();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    private void Initialize()
    {
        // コンポーネント取得
        iwashiMeter = gameObject.GetComponent<Image>();
        bonusNumberText = BonusNumber.GetComponent<Text>();

        // 音楽データ取得
        audioManager = AudioManager.Instance;

        // 初期値代入
        iwashiMeter.fillAmount = 0.0f;
        level = 1;
        bonusNumberText.text = level.ToString();
    }

    /// <summary>
    /// メーター加算処理
    /// </summary>
    public void AddMeter()
    {
        // レベルに適したポイントをメーターに加算する
        iwashiMeter.fillAmount += point / level;

        // レベルアップ処理
        void LevelUp()
        {
            // メーターが最大値に達しているか判別
            if(iwashiMeter.fillAmount >= maxMeterValue)
            {
                // 最大値に達している場合

                // 加算
                level++;

                // テキスト表示変更
                bonusNumberText.text = level.ToString();

                // メーターに初期値代入
                iwashiMeter.fillAmount = 0.0f;

                // いわしポイントを加算する
                IwashiCountController.iwashiPoint++;

                // SE再生
                audioManager.PlaySE(audioManager.LevelUpSE.name);
            }
        }

        LevelUp();
    }

    /// <summary>
    /// メーター減算処理
    /// </summary>
    /// <param name="value">値</param>
    public void SubtractMeter(float value)
    {
        // メーターを減産する
        iwashiMeter.fillAmount -= value;

        // メーターが0.0f以下か判別
        if (iwashiMeter.fillAmount < 0.0f)
        {
            // 0.0f以下の場合

            //　0.0fを代入する
            iwashiMeter.fillAmount = 0.0f;
        }
    }
}
