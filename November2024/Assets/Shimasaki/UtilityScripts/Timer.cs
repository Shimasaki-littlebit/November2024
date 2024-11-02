using UnityEngine.Events;

/// <summary>
/// タイマークラス
/// </summary>
public class Timer
{
    /// <summary>
    /// 計算時間
    /// </summary>
    private float time = 0.0f;

    /// <summary>
    /// タイマー設定時間
    /// </summary>
    private float limitTime = 0.0f;

    /// <summary>
    /// 実行するメソッド
    /// </summary>
    private UnityAction action;

    /// <summary>
    /// タイマーの時間を設定
    /// </summary>
    /// <param name="setTime">設定秒数</param>
    /// <param name="setAction">設定メソッド</param>
    /// <param name="isOverWrite">上書きするか</param>
    public void SetTimer(float setTime, UnityAction setAction, bool isOverWrite = false)
    {
        // 上書きが可能な場合
        if (isOverWrite == true)
        {
            ResetTimer();
        }
        // 上書きできない場合
        else
        {
            // タイマーがもうスタートしていればリターン
            if (isTimerStart()) return;
        }

        // マイナス秒数の場合リターン
        if (setTime < 0.0f) return;

        // タイマー時間を設定
        limitTime = setTime;

        // メソッドを設定
        action = setAction;
    }

    /// <summary>
    /// タイマーを初期化する
    /// </summary>
    public void ResetTimer()
    {
        time = 0.0f;
        limitTime = 0.0f;

        action = null;
    }

    /// <summary>
    /// 時間計算
    /// </summary>
    public void Count(float calDeltaTime)
    {
        if (!isTimerStart()) return;

        time += calDeltaTime;

        JudgeTimeLimit();
    }

    /// <summary>
    /// 設定時間が終了したらメソッドを実行
    /// </summary>
    public void JudgeTimeLimit()
    {
        // 設定時間が終了したら実行しリセット
        if (time >= limitTime)
        {
            if (action != null)
            {
                action();
            }

            ResetTimer();
        }
    }

    /// <summary>
    /// タイマーがスタートしているか
    /// </summary>
    /// <returns>true スタートしている</returns>
    public bool isTimerStart()
    {
        if (limitTime <= 0.0f) return false;

        return true;
    }
}
