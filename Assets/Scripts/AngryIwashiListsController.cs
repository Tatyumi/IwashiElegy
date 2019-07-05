using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryIwashiListsController : MonoBehaviour
{
    /// <summary>移動速度</summary>
    private float moveSpeed = -3.0f;

    // Update is called once per frame
    void Update()
    {
        // 移動
        transform.Translate(moveSpeed, 0.0f,0.0f);
    }

    /// <summary>
    /// 衝突判定
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // コンポーネント取得
        var obj = collision.gameObject.GetComponent<EnemyController>();

        // nullチェック
        if(obj != null)
        {
            // nullでない場合

            // 戦闘開始
            obj.Battle(IwashiCountController.IwashiCount);
        }
    }
}
