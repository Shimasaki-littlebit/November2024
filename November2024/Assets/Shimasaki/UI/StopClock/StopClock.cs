using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの落下停止時のタイムリミット表示
/// </summary>
public class StopClock : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// 表示オブジェクト
    /// </summary>
    [SerializeField]
    private GameObject clockObject;

    /// <summary>
    /// 表示の内枠ゲージ
    /// </summary>
    private Image clockInner;

    /// <summary>
    /// 制限
    /// </summary>
    private float timeLimit;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // 制限時間を初期化
        timeLimit = playerManager.StopLimit;

        // 表示の内枠ゲージ取得
        clockInner = clockObject.transform.GetChild(0).GetComponent<Image>();

        clockInner.fillAmount = 1.0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ClockCalc();

        ClockInnerDisplay();
    }

    /// <summary>
    /// タイマー表示の計算
    /// </summary>
    private void ClockCalc()
    {
        // プレイヤーが接地中
        if (playerManager.IsGround)
        {
            // タイマーが非表示なら表示
            if (!clockObject.activeSelf)
            {
                clockObject.SetActive(true);
            }

            // タイムリミット表示を減算
            timeLimit -= Time.deltaTime;
        }

        // 接地中じゃなければ
        else
        {
            // タイマーが非表示なら終了
            if (!clockObject.activeSelf) return;

            // タイムリミット表示初期化
            timeLimit = playerManager.StopLimit;

            // タイマー非表示
            clockObject.SetActive(false);
        }
    }

    /// <summary>
    /// タイマーの表示
    /// </summary>
    private void ClockInnerDisplay()
    {
        // 接地中でなければ終了
        if (!playerManager.IsGround) return;

        // 表示領域を制限時間から計算して反映
        clockInner.fillAmount = timeLimit / playerManager.StopLimit;
    }
}
