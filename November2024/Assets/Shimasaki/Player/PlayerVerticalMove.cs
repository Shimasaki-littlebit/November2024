using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの縦移動
/// </summary>
public class PlayerVerticalMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// 軽い速度
    /// </summary>
    private float lightFallSpeed;

    /// <summary>
    /// 重い速度
    /// </summary>
    private float heavyFallSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // 速度設定
        SetSpeed();
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// 重い軽い時の速度設定
    /// </summary>
    private void SetSpeed()
    {
        // 軽い状態の速度設定
        lightFallSpeed = playerManager.NomalFallSpeed * playerManager.LightMagnification;

        // 重い状態の速度設定
        heavyFallSpeed = playerManager.NomalFallSpeed * playerManager.HeavyMagnification;
    }
}
