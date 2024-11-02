using UnityEngine;
using TMPro;

/// <summary>
/// スコアボード
/// </summary>
public class ScoreBoard : MonoBehaviour
{
    /// <summary>
    /// スコアのデータ
    /// </summary>
    private ScoreData rankingData;

    /// <summary>
    /// スコアのTextがついているオブジェクト
    /// </summary>
    [SerializeField]
    private GameObject[] scoreObjects;

    // Start is called before the first frame update
    private void Start()
    {
        // スコアのデータを取得
        rankingData = ScoreManager.GetScoreData;

        // スコア表示
        DisplayScoreRanking();
    }

    /// <summary>
    /// スコアの表示
    /// </summary>
    private void DisplayScoreRanking()
    {
        // 添え字
        int num = 0;

        // 各ランキングをテキストにセット
        foreach (var scoreObject in scoreObjects)
        {
            var scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

            scoreText.SetText(rankingData.HighScore[num].ToString());

            num++;
        }
    }
}
