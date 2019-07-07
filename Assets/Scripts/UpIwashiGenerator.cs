using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpIwashiGenerator : VerticalIwashiGenerator
{
    /// <summary>
    /// 初期化処理
    /// </summary>
    protected override void Initialize()
    {
        // 最小、最大のx座標の代入
        maxGeneratPosX = Screen.width;
        minGeneratPosX = 0;

        // 生成するy座標の代入
        generatPosY = Screen.height;
    }
}