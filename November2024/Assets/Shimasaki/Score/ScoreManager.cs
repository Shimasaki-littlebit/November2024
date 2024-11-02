using System;

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
    /// スコアデータ取得
    /// </summary>
    public static ScoreData GetScoreData
    {
        get => scoreData;
        set => scoreData = value;
    }

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

    /// <summary>
    /// スコアをセーブ
    /// </summary>
    public static void SaveHighScore()
    {
        ScoreJsonReader.Save<ScoreData>(scoreData, pathName, false);
    }

    /// <summary>
    /// 順位挿入
    /// </summary>
    /// <param name="insertScore">判定するスコア</param>
    /// <returns>true = 挿入できた</returns>
    public static bool InsertRanking(int insertScore)
    {
        // 判定スコアがハイスコアの最低値より大きければ
        if (insertScore > ScoreManager.GetScoreData.HighScore[4])
        {
            // スコアを更新
            ScoreManager.GetScoreData.HighScore[4] = insertScore;

            // 順位の並べ替え
            SortRanking();

            // スコアをセーブ
            SaveHighScore();

            return true;
        }

        // スコアが小さければfalse
        return false;
    }

    /// <summary>
    /// スコアを降順ソートする
    /// </summary>
    private static void SortRanking()
    {
        // 昇順ソード
        Array.Sort(ScoreManager.GetScoreData.HighScore);

        // 反転させ降順に
        Array.Reverse(ScoreManager.GetScoreData.HighScore);
    }
}
