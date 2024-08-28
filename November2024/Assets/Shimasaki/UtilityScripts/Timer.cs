using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// タイマーの時間を設定
    /// </summary>
    /// <param name="setTime">設定秒数</param>
    /// <param name="isOverWrite">true = 上書き開始</param>
    public void SetTimer(float setTime ,bool isOverWrite = false)
    {
        // 上書きが可能な場合
        if(isOverWrite == true)
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

        limitTime = setTime;
    }

    /// <summary>
    /// タイマーを初期化する
    /// </summary>
    public void ResetTimer()
    {
        time = 0.0f;
        limitTime = 0.0f;
    }

    /// <summary>
    /// 時間計算
    /// </summary>
    public void Calculation(float calDeltaTime)
    {
        if (!isTimerStart()) return;

        time += calDeltaTime;
    }

    /// <summary>
    /// 設定時間が終了したか
    /// </summary>
    /// <returns>true = 終了</returns>
    public bool isTimeLimit()
    {
        if (!isTimerStart()) return false;

        // 設定時間が終了したらtrueを返しリセット
        if (time >= limitTime)
        {
            ResetTimer();

            return true;
        }

        return false;
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
