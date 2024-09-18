using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

/// <summary>
/// �X�R�A�{�[�h
/// </summary>
public class ScoreBoard : MonoBehaviour
{
    /// <summary>
    /// �X�R�A�̃f�[�^
    /// </summary>
    private ScoreData rankingData;

    /// <summary>
    /// �X�R�A��Text�����Ă���I�u�W�F�N�g
    /// </summary>
    [SerializeField]
    private GameObject[] scoreObjects;

    // Start is called before the first frame update
    private void Start()
    {
        // �X�R�A�̃f�[�^���擾
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
    /// �X�R�A�̕\��
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
