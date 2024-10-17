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

    /// <summary>
    /// 壁のレイヤー
    /// </summary>
    private int wallLayer = 1 << 6;

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

        // もしキーボード入力があれば反映
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            horizontalValue = KeyInput();
        }
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
        Ray ray = new Ray(startPos, Vector2.down);

        Debug.DrawRay(startPos, Vector2.down * distance, Color.red);

        // レイを飛ばして当たったら右壁判定
        if (Physics2D.Raycast(startPos, Vector2.down, distance,wallLayer))
        {
            if (!playerManager.IsRightWall)
            {
                playerManager.IsRightWall = true;
            }

            // 座標調整
            transform.position = RoundPositionX();
        }

        // そうでない時は右壁判定しない
        else
        {
            if (playerManager.IsRightWall)
            {
                playerManager.IsRightWall = false;
            }
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
        if (Physics2D.Raycast(startPos, Vector2.down, distance, wallLayer))
        {
            if (!playerManager.IsLeftWall)
            {
                playerManager.IsLeftWall = true;
            }

            // 座標調整
            transform.position = RoundPositionX();
        }

        // そうでない時は左壁判定しない
        else
        {
            if (playerManager.IsLeftWall)
            {
                playerManager.IsLeftWall = false;
            }
        }
    }

    /// <summary>
    /// X座標の四捨五入修正
    /// (移動の値が大きい場合はすり抜ける)
    /// </summary>
    /// <returns>修正後座標</returns>
    private Vector2 RoundPositionX()
    {
        Vector2 pos = transform.position;

        pos.x = Mathf.Round(pos.x);

        return pos;
    }

    /// <summary>
    /// キー入力の数値
    /// </summary>
    /// <returns>左右の入力値</returns>
    private float KeyInput()
    {
        float result = 0.0f;

        // A入力で左入力
        if (Input.GetKey(KeyCode.A))
        {
            result -= 1.0f;
        }

        // D入力で右入力
        if (Input.GetKey(KeyCode.D))
        {
            result += 1.0f;
        }

        return result;
    }
}
