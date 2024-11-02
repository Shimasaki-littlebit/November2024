using System;

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
    /// �X�R�A�f�[�^�擾
    /// </summary>
    public static ScoreData GetScoreData
    {
        get => scoreData;
        set => scoreData = value;
    }

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

    /// <summary>
    /// �X�R�A���Z�[�u
    /// </summary>
    public static void SaveHighScore()
    {
        ScoreJsonReader.Save<ScoreData>(scoreData, pathName, false);
    }

    /// <summary>
    /// ���ʑ}��
    /// </summary>
    /// <param name="insertScore">���肷��X�R�A</param>
    /// <returns>true = �}���ł���</returns>
    public static bool InsertRanking(int insertScore)
    {
        // ����X�R�A���n�C�X�R�A�̍Œ�l���傫�����
        if (insertScore > ScoreManager.GetScoreData.HighScore[4])
        {
            // �X�R�A���X�V
            ScoreManager.GetScoreData.HighScore[4] = insertScore;

            // ���ʂ̕��בւ�
            SortRanking();

            // �X�R�A���Z�[�u
            SaveHighScore();

            return true;
        }

        // �X�R�A�����������false
        return false;
    }

    /// <summary>
    /// �X�R�A���~���\�[�g����
    /// </summary>
    private static void SortRanking()
    {
        // �����\�[�h
        Array.Sort(ScoreManager.GetScoreData.HighScore);

        // ���]�����~����
        Array.Reverse(ScoreManager.GetScoreData.HighScore);
    }
}
