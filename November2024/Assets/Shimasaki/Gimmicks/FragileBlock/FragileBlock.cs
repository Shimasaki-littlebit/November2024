using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// メモ　Rayの判定要改善


/// <summary>
/// 壊れるブロック
/// </summary>
public class FragileBlock : MonoBehaviour
{
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

    // Update is called once per frame
    private void Update()
    {
        BreakBlock();
    }

    /// <summary>
    /// ブロックを壊すかどうか判定するRay
    /// </summary>
    private bool BreakBlockRay()
    {
        // レイの開始地点
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f + rayDistance);

        // レイの距離
        float distance = transform.localScale.x - rayDistance * 2.0f;

        Debug.DrawRay(startPos, Vector2.right * distance, Color.red);

        // レイを飛ばして当たったらtrueを返す
        if (Physics2D.Raycast(startPos, Vector2.right, distance, playerLayerMask))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// ブロックを壊す処理
    /// </summary>
    private void BreakBlock()
    {
        // 描写されていなければ終了
        if (!isDisplay) return;

        // 壊す判定Rayに当たっていれば壊す
        if(BreakBlockRay())
        {
            Destroy(gameObject);
        }
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
