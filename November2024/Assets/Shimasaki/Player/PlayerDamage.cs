using System.Collections;
using System.Collections.Generic;
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
    /// 無敵時間
    /// </summary>
    [SerializeField]
    private float invincibleTime;

    /// <summary>
    /// 無敵時間かどうか
    /// </summary>
    private bool isInvincible;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // タイマー初期化
        invincibleTimer = new();
        // 無敵時間初期化
        isInvincible = false;
    }

    
    private void FixedUpdate()
    {
        // 無敵時間なら無敵時間計算
        if (isInvincible)
        {
            invincibleTimer.Count(Time.deltaTime);
        }
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
        invincibleTimer.SetTimer(invincibleTime,FinishInvincible);
    }

    /// <summary>
    /// 無敵時間終了
    /// </summary>
    private void FinishInvincible()
    {
        isInvincible = false;
    }

}
