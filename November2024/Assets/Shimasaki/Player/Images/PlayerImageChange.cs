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

    /// <summary>
    /// 見た目のセット
    /// </summary>
    public void SetPlayerImage()
    {
        // 重量を見て分岐
        switch(playerManager.GetWeight)
        {
            // 軽い
            case Weight.LIGHT:

                // 画像切り替え
                spriteRenderer.sprite = playerManager.LightImage;

                // プロペラ表示
                playerManager.LightPropeller.SetActive(true);

                break;

            // 普通
            case Weight.NORMAL:

                // 画像切り替え
                spriteRenderer.sprite = playerManager.NormalImage;

                // 各重さ系を非表示
                playerManager.LightPropeller.SetActive(false);
                playerManager.HeavyWeapon.SetActive(false);

                break;

            // 重い
            case Weight.HEAVY:

                // 画像切り替え
                spriteRenderer.sprite = playerManager.HeavyImage;

                // 重い武器表示
                playerManager.HeavyWeapon.SetActive(true);

                break;
        }
    }
}
