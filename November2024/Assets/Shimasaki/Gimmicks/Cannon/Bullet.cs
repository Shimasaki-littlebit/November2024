using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// プレイヤーのダメージスクリプト
    /// </summary>
    private PlayerDamage playerDamage;

    /// <summary>
    /// 弾の画像
    /// </summary>
    [SerializeField]
    private GameObject bulletImage;

    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// 弾のダメージ
    /// </summary>
    [SerializeField]
    private int bulletDamage;

    /// <summary>
    /// 右向きに飛ぶか
    /// </summary>
    private bool isRight;

    /// <summary>
    /// プレイヤーのレイヤーマスク
    /// </summary>
    private int playerLayerMask = 1 << 3;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // プレイヤーダメージスクリプト取得
        playerDamage = playerManager.Player.GetComponent<PlayerDamage>();
    }

    private void Update()
    {
        HitPlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// 発射処理
    /// </summary>
    /// <param name="shotRight">発射方向</param>
    public void Shot(bool shotRight)
    {
        // 発射方向を決定
        isRight = shotRight;

        ImageDirection();
    }

    /// <summary>
    /// 画像の方向を変える
    /// </summary>
    private void ImageDirection()
    {
        var rotate = bulletImage.transform.eulerAngles;

        if (isRight)
        {
            rotate.z = 0.0f;           
        }
        else
        {
            rotate.z = 180.0f;
        }

        bulletImage.transform.eulerAngles = rotate;
    }

    /// <summary>
    /// 弾の移動
    /// </summary>
    private void Move()
    {
        var movePos = transform.position;

        // 右向き
        if (isRight)
        {
            // 移動加算
            movePos.x += moveSpeed * Time.deltaTime;
        }

        // 左向き
        else
        {
            // 移動加算
            movePos.x -= moveSpeed * Time.deltaTime;
        }


        // 座標を反映
        transform.position = movePos;
    }

    /// <summary>
    /// プレイヤーに当たった際の処理
    /// </summary>
    private void HitPlayer()
    {
        // プレイヤーに当たっていなければ終了
        if (!HitBoxRay()) return;

        // プレイヤーに被ダメージ処理
        playerDamage.TakeDamage(bulletDamage);

        Delete();
    }

    /// <summary>
    /// 弾の当たり判定
    /// </summary>
    /// <returns>true = 当たった</returns>
    private bool HitBoxRay()
    {
        //Gizmos.color = Color.yellow;

        //Gizmos.DrawWireCube(transform.position, transform.localScale * 0.5f);

        // プレイヤーのみに当たるボックスキャストを飛ばす
        if (Physics2D.BoxCast(transform.position, transform.localScale, 0.0f, Vector2.zero, 0.0f, playerLayerMask))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// カメラ外に行くと削除
    /// </summary>
    private void OnBecameInvisible()
    {
        Delete();
    }

    /// <summary>
    /// 消える際の処理
    /// </summary>
    private void Delete()
    {
        Destroy(gameObject);
    }
}
