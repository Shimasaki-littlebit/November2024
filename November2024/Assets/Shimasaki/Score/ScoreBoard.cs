using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// スコアボード
/// </summary>
public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log(ScoreManager.Test());
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            ScoreManager.SaveHighScore();
        }
    }
}
