using System.Collections;
using System.Collections.Generic;
using System;
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

        DisplayScoreRanking();
    }

    //// Update is called once per frame
    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.U))
    //    {
    //        ScoreManager.InsertRanking(15);
    //    }

    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        ScoreManager.SaveHighScore();
    //    }
    //}

    /// <summary>
    /// スコアの表示
    /// </summary>
    private void DisplayScoreRanking()
    {
        int num = 0;

        foreach (var scoreObject in scoreObjects)
        {
            var scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

            scoreText.SetText(rankingData.HighScore[num].ToString());

            num++;
        }
    }
}
