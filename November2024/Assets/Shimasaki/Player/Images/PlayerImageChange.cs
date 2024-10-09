using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// プレイヤーの画像変更
/// </summary>
public class PlayerImageChange : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// プレイヤーの見た目スプライトレンダラー
    /// </summary>
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        playerManager = PlayerManager.Instance;

        spriteRenderer = playerManager.PlayerImage.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// 見た目のセット
    /// </summary>
    private void SetPlayerImage()
    {
        // 重量を見て分岐
        switch(playerManager.GetWeight)
        {
            // 軽い
            case Weight.LIGHT:

                spriteRenderer.sprite = playerManager.LightImage;

                break;

            // 普通
            case Weight.NORMAL:

                spriteRenderer.sprite = playerManager.NormalImage;

                break;

            // 重い
            case Weight.HEAVY:

                spriteRenderer.sprite = playerManager.HeavyImage;

                break;
        }
    }
}
