using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �X�R�A�}�l�[�W���[
/// </summary>
public class ScoreManager
{
    /// <summary>
    /// �X�R�A�f�[�^
    /// </summary>
    private static ScoreData scoreData;

    /// <summary>
    /// �n�C�X�R�A�̃p�X�l�[��
    /// </summary>
    private static string pathName = "/StreamingAssets/ScoreData/HighScoreData";

    /// <summary>
    /// �R���X�g���N�^
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
    /// �X�R�A���Z�[�u
    /// </summary>
    public static void SaveHighScore()
    {
        ScoreJsonReader.Save<ScoreData>(scoreData, pathName, false);
    }
}
