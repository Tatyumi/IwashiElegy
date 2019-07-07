using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// アセットメニューに追加
[CreateAssetMenu(menuName = "MyScriptable/Create OjamaData")]

public class OjamaData : ScriptableObject
{
    /// <summary>いわし撃破数</summary>
    public int KillIwashiCount;
    /// <summary>移動速度</summary>
    public Vector2 MoveSpeed;
    /// <summary>メーターダメージ</summary>
    public float MeterDamage;

}