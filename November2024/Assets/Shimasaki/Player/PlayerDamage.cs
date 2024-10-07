using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// プレイヤーの被ダメージ処理
/// </summary>
public class PlayerDamage : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// 無敵時間タイマー
    /// </summary>
    private Timer invincibleTimer;

    /// <summary>
    /// 無敵時間かどうか
    /// </summary>
    private bool isInvincible;

    /// <summary>
    /// 落下が止まっている時のタイマー
    /// </summary>
    private Timer stopTimer;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // 無敵時間タイマー初期化
        invincibleTimer = new();
        // 無敵時間初期化
        isInvincible = false;
        // 停止タイマー初期化
        stopTimer = new();
    }

    
    private void FixedUpdate()
    {
        // 無敵時間なら無敵時間計算
        if (isInvincible)
        {
            invincibleTimer.Count(Time.deltaTime);
        }

        StopTimeCalc();
    }

    /// <summary>
    /// 被ダメージ
    /// </summary>
    /// <param name="damageValue">ダメージ値</param>
    public void TakeDamage(int damageValue)
    {
        // 無敵時間ならリターン
        if (isInvincible) return;

        // 無敵時間開始
        StartInvincible();

        // 体力を減らす
        playerManager.HitPoint-= damageValue;

        // 体力がなくればゲームオーバー処理
        if(playerManager.HitPoint <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    private void GameOver()
    {
        
    }

    /// <summary>
    /// 無敵時間開始
    /// </summary>
    private void StartInvincible()
    {
        isInvincible = true;

        // 無敵時間タイマーを設定
        invincibleTimer.SetTimer(playerManager.InvincibleTime,FinishInvincible);
    }

    /// <summary>
    /// 無敵時間終了
    /// </summary>
    private void FinishInvincible()
    {
        isInvincible = false;
    }

    /// <summary>
    /// 落下停止時の時間計算
    /// </summary>
    private void StopTimeCalc()
    {
        // 接地中なら落下停止タイマーを開始
        if (playerManager.IsGround)
        {
            // 開始していなければ開始
            if (!stopTimer.isTimerStart())
            {
                stopTimer.SetTimer(playerManager.StopLimit, StopTimeLimit);
            }

            // 開始していればタイマー計算
            else
            {
                stopTimer.Count(Time.deltaTime);
            }
        }

        // 接地中でなければタイマーをリセット
        else
        {
            // タイマーが始まっていればタイマーリセット
            if (stopTimer.isTimerStart())
            {
                stopTimer.ResetTimer();
            }
        }
    }

    /// <summary>
    /// 落下停止時間が終了した時の処理
    /// </summary>
    private void StopTimeLimit()
    {
        // ゲームオーバーに
        GameOver();
    }
}
