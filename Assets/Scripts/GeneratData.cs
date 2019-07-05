using UnityEngine;

// アセットメニューに追加
[CreateAssetMenu(menuName = "MyScriptable/Create GeneratData")]

public class GeneratData : ScriptableObject
{
    /// <summary>生成間隔</summary>
    public float span;
}