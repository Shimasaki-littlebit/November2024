using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアマネージャー
/// </summary>
public class ScoreManager
{
    /// <summary>
    /// スコアデータ
    /// </summary>
    private static ScoreData scoreData;

    /// <summary>
    /// ハイスコアのパスネーム
    /// </summary>
    private static string pathName = "/StreamingAssets/ScoreData/HighScoreData";

    /// <summary>
    /// コンストラクタ
    /// </summary>
    static ScoreManager()
    {
        scoreData = ScoreJsonReader.LoadData<ScoreData>(pathName);
    }

    public static int Test()
    {
        scoreData.HighScore[0] += 4;

        return scoreData.HighScore[0];
    }

    /// <summary>
    /// スコアをセーブ
    /// </summary>
    public static void SaveHighScore()
    {
        ScoreJsonReader.Save<ScoreData>(scoreData, pathName, false);
    }
}
