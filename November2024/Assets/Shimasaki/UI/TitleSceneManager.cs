using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトルのシーン遷移
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    /// <summary>
    /// 縦のボタン移動
    /// </summary>
    private VerticalUIControl vUIControl;

    private void Start()
    {
        // ボタン移動取得
        vUIControl = GetComponent<VerticalUIControl>();
    }

    // Update is called once per frame
    private void Update()
    {
        // AボタンorEnterキー入力でシーン読み込み
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();
        }
    }

    /// <summary>
    /// シーン読み込み
    /// </summary>
    private void LoadScene()
    {
        switch (vUIControl.SelectNum)
        {
            // メインシーンに
            case 0:

                SceneManager.LoadScene("MainScene");

                break;

            // スコアボードに
            case 1:

                SceneManager.LoadScene("ScoreBoardScene");

                break;

            // クレジットに
            case 2:

                SceneManager.LoadScene("CreditScene");

                break;

            // ゲーム終了
            case 3:

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif

                break;
        }
    }
}
