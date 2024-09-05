using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの重い時の武器
/// </summary>
public class PlayerHeavyWeapon : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    PlayerManager playerManager;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;
    }

    /// <summary>
    /// 重武器表示
    /// </summary>
    public void ShowHeavyWeapon()
    {
        // 非表示なら表示に
        if(!playerManager.HeavyWeapon.activeSelf)
        {
            playerManager.HeavyWeapon.SetActive(true);
        }
    }

    /// <summary>
    /// 重武器非表示
    /// </summary>
    public void HideHeavyWeapon()
    {
        // 表示中なら非表示に
        if (playerManager.HeavyWeapon.activeSelf)
        {
            playerManager.HeavyWeapon.SetActive(false);
        }
    }
}
