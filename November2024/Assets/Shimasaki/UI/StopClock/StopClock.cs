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
    /// 表示までの時間制限値
    /// </summary>
    private float initTimerStart = 1.0f;

    /// <summary>
    /// 表示までの時間制限計算値
    /// </summary>
    private float timerStart;

    /// <summary>
    /// 表示時間制限値
    /// </summary>
    private float initTimeLimit;

    /// <summary>
    /// 表示時間制限計算値
    /// </summary>
    private float timeLimit;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // 制限時間を初期化
        ResetTimeLimits();

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
            if (timerStart > 0.0f)
            {
                timerStart -= Time.deltaTime;
            }
            else
            {
                // タイマーが非表示なら表示
                if (!clockObject.activeSelf)
                {
                    clockObject.SetActive(true);
                }

                // タイムリミット表示を減算
                timeLimit -= Time.deltaTime;
            }
        }
        // 接地中じゃなければ
        else
        {
            // タイマー値が少しでも減っていればリセット
            if (timerStart < initTimerStart)
            {
                ResetTimeLimits();
            }

            // タイマーが表示中なら非表示
            if (clockObject.activeSelf)
            {
                clockObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// タイマーの表示
    /// </summary>
    private void ClockInnerDisplay()
    {
        // タイマーが表示されていなければ終了
        if (!clockObject.activeSelf) return;

        // 表示領域を制限時間から計算して反映
        clockInner.fillAmount = timeLimit / initTimeLimit;
    }

    /// <summary>
    /// 時間制限の初期化
    /// </summary>
    private void ResetTimeLimits()
    {
        Debug.Log("リセット");

        // タイマー表示までの時間を初期化
        timerStart = initTimerStart;

        // タイマーの時間制限値を計算
        initTimeLimit = playerManager.StopLimit - initTimerStart;

        // タイマーの時間制限値を初期化
        timeLimit = initTimeLimit;
    }
}
