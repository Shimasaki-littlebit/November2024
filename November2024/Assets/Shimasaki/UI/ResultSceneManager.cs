using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 一旦タイトルへ移動
/// </summary>
public class ResultSceneManager : MonoBehaviour
{
    /// <summary>
    /// サウンドマネージャー
    /// </summary>
    private SoundPlayManager soundPlayManager;


    private void Start()
    {
        // インスタンス取得
        soundPlayManager = SoundPlayManager.Instance;

        // タイトルBGM再生
        soundPlayManager.TitlePlayBGM();

    }

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
        // スコアボードシーンへ
        SceneManager.LoadScene("ScoreBoardScene");
    }
}
