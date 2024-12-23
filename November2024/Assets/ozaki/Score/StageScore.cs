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
        scoreText.text = Score.ToString() + "m";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        Score += addScore;

        scoreText.text = Score.ToString() + "m";
    }

    /// <summary>
    /// スコアを静的変数に代入
    /// </summary>
    public void PlayEndScore()
    {
        EndScore = Score;
    }
}
