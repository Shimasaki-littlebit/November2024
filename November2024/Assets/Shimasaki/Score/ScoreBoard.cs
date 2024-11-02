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

        // �X�R�A�\��
        DisplayScoreRanking();
    }

    /// <summary>
    /// �X�R�A�̕\��
    /// </summary>
    private void DisplayScoreRanking()
    {
        // �Y����
        int num = 0;

        // �e�����L���O���e�L�X�g�ɃZ�b�g
        foreach (var scoreObject in scoreObjects)
        {
            var scoreText = scoreObject.GetComponent<TextMeshProUGUI>();

            scoreText.SetText(rankingData.HighScore[num].ToString());

            num++;
        }
    }
}
