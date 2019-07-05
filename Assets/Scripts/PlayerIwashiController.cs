using UnityEngine;

public sealed class PlayerIwashiController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // ゲームが終了しているか判別
        if (!TimeLimtController.isEnd)
        {
            // 終了していない場合

            // マウスの座標をオブジェクトの座標に代入
            gameObject.transform.position = Input.mousePosition;
        }
    }

    /// <summary>
    /// 衝突処理
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // コンポーネントの取得
        var obj = collision.gameObject.GetComponent<IApplableScore>();

        // nullチェック
        if(obj != null)
        {
            // null出ない場合

            // スコア適応
            obj.ApplyScore();
        }
    }
}
