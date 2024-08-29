using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの横以上
/// </summary>
public class PlayerHorizontalMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// 横入力値
    /// </summary>
    private float horizontalValue;

    /// <summary>
    /// レイ用間隔
    /// </summary>
    private float rayDistance = 0.05f;

    // Start is called before the first frame update
    private void Start()
    {
        playerManager = PlayerManager.Instance;

        // 横入力値初期化
        horizontalValue = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        // 横入力感知
        HorizontalInput();

        // 左右の当たり判定レイ
        RightRay();
        LeftRay();
    }

    private void FixedUpdate()
    {
        HorizontalMove();
    }

    /// <summary>
    /// 横の入力検知
    /// </summary>
    private void HorizontalInput()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
    }

    /// <summary>
    /// 横移動
    /// </summary>
    private void HorizontalMove()
    {
        // 移動できなければ返す
        if (!CheckMovable()) return;

        var playerPos = transform.position;

        // 移動計算
        playerPos.x += horizontalValue * playerManager.HorizontalSpeed * Time.deltaTime;

        // 反映
        transform.position = playerPos;
    }

    /// <summary>
    /// 移動可能か調べる
    /// </summary>
    /// <returns>true = 移動可能</returns>
    private bool CheckMovable()
    {
        // 動けない状態ならfalse
        if (!playerManager.IsMovable) return false;

        // 右壁接触時に右入力があればfalse
        if (playerManager.IsRightWall)
        {
            if (horizontalValue > 0.0f) return false;
        }

        // 左壁接触時に左入力があればfalse
        if (playerManager.IsLeftWall)
        {
            if (horizontalValue < 0.0f) return false;
        }

        // 大丈夫ならtrue
        return true;
    }

    /// <summary>
    /// 右面のレイ
    /// </summary>
    private void RightRay()
    {
        // レイの開始地点
        Vector2 startPos = new(transform.position.x + transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f - rayDistance);

        // レイの距離
        float distance = transform.localScale.y - rayDistance * 2.0f;

        // レイ生成
        Ray ray = new Ray(startPos,Vector2.down);

        Debug.DrawRay(startPos, Vector2.down * distance ,Color.red);

        // レイを飛ばして当たったら右壁判定
        if (Physics2D.Raycast(startPos,Vector2.down,distance))
        {
            playerManager.IsRightWall = true;

            transform.position = RoundPositionX();

            Debug.Log("右壁");
        }
        // そうでない時は判定しない
        else
        {
            playerManager.IsRightWall = false;
        }
    }

    /// <summary>
    /// 左面のレイ
    /// </summary>
    private void LeftRay()
    {
        // レイの開始地点
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f - rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f - rayDistance);

        // レイの距離
        float distance = transform.localScale.y - rayDistance * 2.0f;

        // レイ生成
        Ray ray = new Ray(startPos, Vector2.down);

        Debug.DrawRay(startPos, Vector2.down * distance, Color.red);

        // レイを飛ばして当たったら左壁判定
        if (Physics2D.Raycast(startPos, Vector2.down, distance))
        {
            playerManager.IsLeftWall = true;

            transform.position = RoundPositionX();

            Debug.Log("左壁");
        }
        // そうでない時は判定しない
        else
        {
            playerManager.IsLeftWall = false;
        }
    }

    /// <summary>
    /// 座標の四捨五入修正
    /// (移動の値が大きい場合はすり抜ける)
    /// </summary>
    /// <returns>修正後座標</returns>
    private Vector2 RoundPositionX()
    {
        Vector2 pos = transform.position;

        pos.x = Mathf.Round(pos.x);

        return pos;
    }
}
