using UnityEngine;

/// <summary>
/// 大砲
/// </summary>
public class Cannon : MonoBehaviour
{
    /// <summary>
    /// 弾のプレハブ
    /// </summary>
    [SerializeField]
    private GameObject bulletPrefab;

    /// <summary>
    /// 発射用タイマー
    /// </summary>
    private Timer shotTimer;

    /// <summary>
    /// 発射間隔
    /// </summary>
    private float shotInterval = 3.0f;

    /// <summary>
    /// 右向きか
    /// </summary>
    [SerializeField]
    private bool isRight;

    /// <summary>
    /// 右向きか取得
    /// </summary>
    public bool IsRight
    {
        get => isRight;
        set => isRight = value;
    }

    // Start is called before the first frame update
    private void Start()
    {
        shotTimer = new();

        // タイマーセット
        shotTimer.SetTimer(shotInterval, FinishShotTimer);
    }

    private void FixedUpdate()
    {
        if (shotTimer.isTimerStart())
        {
            // タイマーカウント
            shotTimer.Count(Time.deltaTime);
        }
        else
        {
            // タイマーセット
            shotTimer.SetTimer(shotInterval, FinishShotTimer);
        }
    }

    /// <summary>
    /// タイマー終了時の処理
    /// </summary>
    private void FinishShotTimer()
    {
        // 発射
        ShotBullet();

        //// タイマーセット
        //shotTimer.SetTimer(shotInterval, FinishShotTimer);
    }

    /// <summary>
    /// 弾の発射
    /// </summary>
    private void ShotBullet()
    {
        // 生成座標用
        Vector2 shotPos = transform.position;

        // 右向きの場合
        if (isRight)
        {
            // 本体右側の座標を計算
            shotPos += Vector2.right;

            // 本体右側に弾を生成
            var bullet = Instantiate(bulletPrefab, shotPos, Quaternion.identity);

            // スクリプトを取得して発射処理
            var bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Shot(isRight);
        }

        // 左向きの場合
        else
        {
            // 本体右側の座標を計算
            shotPos += Vector2.left;

            // 本体右側に弾を生成
            var bullet = Instantiate(bulletPrefab, shotPos, Quaternion.identity);

            // スクリプトを取得して発射処理
            var bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Shot(isRight);
        }
    }
}
