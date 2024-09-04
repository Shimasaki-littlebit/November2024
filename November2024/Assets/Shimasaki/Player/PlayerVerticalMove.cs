using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

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

    /// <summary>
    /// レイ用間隔
    /// </summary>
    private float rayDistance = 0.05f;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // 速度設定
        SetSpeed();
    }

    private void Update()
    {
        GroundRay();
    }

    private void FixedUpdate()
    {
        Fall();
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

    /// <summary>
    /// 速度取得
    /// </summary>
    /// <returns>速度</returns>
    private float GetSpeed()
    {
        // プレイヤーの重さで分岐
        switch (playerManager.GetWeight)
        {
            // 軽い
            case Weight.LIGHT:

                return lightFallSpeed;

            // 普通
            case Weight.NORMAL:

                return playerManager.NomalFallSpeed;

            // 重い
            case Weight.HEAVY:

                return heavyFallSpeed;

            default:

                return playerManager.NomalFallSpeed;
        }
    }

    /// <summary>
    /// 落下処理
    /// </summary>
    private void Fall()
    {
        // 落ちなければ終了
        if (!playerManager.IsMovable) return;
        if (playerManager.IsGround) return;

        Vector2 movePos = transform.position;

        // 落下速度計算
        movePos.y -= GetSpeed() * Time.deltaTime;

        // 座標に反映
        transform.position = movePos;
    }

    /// <summary>
    /// 地面を判定するレイ
    /// </summary>
    private void GroundRay()
    {
        // レイの開始地点
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y - transform.localScale.y * 0.5f - rayDistance);

        // レイの距離
        float distance = transform.localScale.x - rayDistance * 2.0f;

        // レイ生成
        Ray ray = new Ray(startPos, Vector2.right);

        Debug.DrawRay(startPos, Vector2.right * distance, Color.green);

        // レイを飛ばして当たったら地面判定
        if (Physics2D.Raycast(startPos, Vector2.right, distance))
        {
            if (!playerManager.IsGround)
            {
                playerManager.IsGround = true;
            }

            // 座標調整
            transform.position = RoundPositionY();
        }

        // 当たっていなければ地面判定を降ろす
        else
        {
            if (playerManager.IsGround)
            {
                playerManager.IsGround = false;
            }
        }
    }

    /// <summary>
    /// Y座標の四捨五入修正
    /// </summary>
    /// <returns>修正後座標</returns>
    private Vector2 RoundPositionY()
    {
        Vector2 pos = transform.position;

        pos.y = Mathf.Round(pos.y);

        return pos;
    }
}
