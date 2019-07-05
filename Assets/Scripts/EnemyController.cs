using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /// <summary>エネミーデーター</summary>
    public EnemyData EnemyData;

    public void Battle(int iwashiCount)
    {
        // パワーとイワシの数を比較
        if (EnemyData.Power > iwashiCount)
        {
            // パワーの方が多い場合

            // TODO 敗北
            Debug.Log("負け");
        }
        else
        {
            // イワシの方が多い場合

            // TODO 勝利
            Debug.Log("勝ち");
        }

    }
}
