using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScore : SingletonMonoBehaviour<StageScore>
{
    private int score;

    public int Score
    {
        get => score;
        set => score = value;
    }

    [SerializeField]
    private TextMesh text;

    [SerializeField]
    private int addScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore()
    {
        Score += addScore;
    }
}
