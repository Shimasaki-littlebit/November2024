using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreManager.InsertRanking(StageScore.EndScore);

        scoreText.text = "�X�R�A : " + StageScore.EndScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
