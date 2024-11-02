using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StageScore : SingletonMonoBehaviour<StageScore>
{
    private int score;

    public int Score
    {
        get => score;
        set => score = value;
    }

    public static int EndScore;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private int addScore;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "�X�R�A: " + Score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        Score += addScore;

        scoreText.text = "�X�R�A: " + Score;
    }

    /// <summary>
    /// �X�R�A��ÓI�ϐ��ɑ��
    /// </summary>
    public void PlayEndScore()
    {
        EndScore = Score;
    }
}
