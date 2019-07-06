using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Common;

public class EnemyController : MonoBehaviour
{
    /// <summary>エネミーデーター</summary>
    public EnemyData EnemyData;

    public void Battle(int iwashiCount)
    {
        // 判定を取得
        ResultDirector.isResult = iwashiCount > EnemyData.Power;

        // 結果シーンに遷移
        SceneManager.LoadScene(SceneName.RESULT_SCENE);
    }
}
