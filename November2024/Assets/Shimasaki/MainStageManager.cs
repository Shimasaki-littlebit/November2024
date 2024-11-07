using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStageManager : MonoBehaviour
{
    /// <summary>
    /// サウンドマネージャー
    /// </summary>
    private SoundPlayManager soundPlayManager;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        soundPlayManager = SoundPlayManager.Instance;

        // ゲームBGM再生
        soundPlayManager.GamePlayBGM();
    }
}
