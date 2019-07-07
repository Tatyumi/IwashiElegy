using UnityEngine;

public class RightIwashiGenerator :HorizonIwashiGenerator
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Initialize()
    {
        // 最小、最大のy座標を取得
        maxGeneratPosY = Screen.height;
        minGeneratPosY = 0;

        // 生成するx座標の代入
        generatPosX = Screen.width;
    }
}
