using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// スコアボードのシーン遷移
/// </summary>
public class ScoreBoardSceneManager : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        // AボタンorEnterキーorAキー入力でシーン読み込み
        if (Input.GetKeyDown("joystick button 0") || 
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.A))
        {
            LoadScene();
        }
    }

    /// <summary>
    /// シーン遷移
    /// </summary>
    private void LoadScene()
    {
        // タイトルシーンへ
        SceneManager.LoadScene("TitleScene");
    }
}
