using UnityEngine;

// アセットメニューに追加
[CreateAssetMenu(menuName = "MyScriptable/Create EnemyData")]

public class EnemyData : ScriptableObject
{
    /// <summary>パワー</summary>
    public int Power;
}