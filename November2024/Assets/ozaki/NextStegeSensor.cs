using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NextStegeSensor : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマスク
    /// </summary>
    private LayerMask playerMask = 1 << 3;
    
    /// <summary>
    /// 縦の長さ
    /// </summary>
    private float height;

    /// <summary>
    /// ステージマネージャー
    /// </summary>
    private StageManager stageManager;

    /// <summary>
    /// プレイヤーに当たったかの確認
    /// </summary>
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        // ステージマネージャー取得
        stageManager = StageManager.Instance;
        
        // 縦の幅を取得
        height = stageManager.ArrayHeight * 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // プレイヤー感知
        if (!hit && Physics2D.Raycast(transform.position,
                             transform.right,
                             20.0f,
                             playerMask))
        {
            // 当たった状態に
            hit = true;
            // 次のステージの作製
            NextStageCreate();
        }
    }

    /// <summary>
    /// 次のステージ作製に必要な情報を渡す
    /// </summary>
    private void NextStageCreate()
    {
        // ステージデータと高さを渡す
        stageManager.NextStageGenetator(stageManager.Data, transform.position.y - height);
    }
}
