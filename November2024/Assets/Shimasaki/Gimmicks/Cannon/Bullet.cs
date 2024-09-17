using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 右向きに飛ぶか
    /// </summary>
    private bool isRight;

    // Start is called before the first frame update
    private void Start()
    {
        // 右向きで初期化
        isRight = true;
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// 発射処理
    /// </summary>
    /// <param name="shotRight">発射方向</param>
    public void Shot(bool shotRight)
    {
        // 発射方向を決定
        isRight = shotRight;
    }

    /// <summary>
    /// 弾の移動
    /// </summary>
    private void Move()
    {
        var movePos = transform.position;

        // 移動加算
        movePos.x += moveSpeed * Time.deltaTime;

        // 座標を反映
        transform.position = movePos;
    }

    // 消える処理と当たり判定
}
