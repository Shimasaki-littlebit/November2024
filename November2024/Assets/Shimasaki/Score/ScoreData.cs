using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアセーブ用データ
/// </summary>
[System.Serializable]
public class ScoreData
{
    /// <summary>
    /// ハイスコアの数値
    /// </summary>
    public int[] HighScore = new int[5];
}
