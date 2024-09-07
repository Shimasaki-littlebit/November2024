using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;


/// <summary>
/// 棘の処理
/// </summary>
public class Splinter : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// プレイヤーのダメージスクリプト
    /// </summary>
    private PlayerDamage damage;

    /// <summary>
    /// 与える基礎ダメージ
    /// </summary>
    [SerializeField]
    private int damageValue;

    /// <summary>
    /// レイ用間隔
    /// </summary>
    private float rayDistance = 0.05f;

    /// <summary>
    /// 自分が描写されているか
    /// </summary>
    private bool isDisplay = false;

    /// <summary>
    /// プレイヤーのレイヤーマスク
    /// </summary>
    private int playerLayerMask = 1 << 3;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // ダメージスクリプト取得
        damage = playerManager.Player.GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    private void Update()
    {
        SplinterDamage();
    }

    /// <summary>
    /// 棘のダメージ判定処理
    /// </summary>
    private void SplinterDamage()
    {
        // 自分が描写されていなければ終了
        if (!isDisplay) return;

        // プレイヤーに当たっていれば
        if(SplinterRay())
        {
            // プレイヤーにダメージを与える
            damage.TakeDamage(DamageCalculation());
        }
    }

    /// <summary>
    /// 棘の当たり判定Ray
    /// </summary>
    /// <returns>true = 当たっている</returns>
    private bool SplinterRay()
    {
        // レイの開始地点
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f + rayDistance);

        // レイの距離
        float distance = transform.localScale.x - rayDistance * 2.0f;

        // レイ生成
        Ray ray = new Ray(startPos, Vector2.right);

        Debug.DrawRay(startPos, Vector2.right * distance, Color.red);

        // レイを飛ばして当たったらtrueを返す
        if (Physics2D.Raycast(startPos, Vector2.right, distance,playerLayerMask))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// ダメージ値を計算
    /// </summary>
    /// <returns></returns>
    private int DamageCalculation()
    {
        if(playerManager.GetWeight == Weight.HEAVY)
        {
            return damageValue << 1;
        }

        return damageValue;
    }

    /// <summary>
    /// 画面に映った時の処理
    /// </summary>
    private void OnBecameVisible()
    {
        // 処理を開始
        isDisplay = true;
    }
}
