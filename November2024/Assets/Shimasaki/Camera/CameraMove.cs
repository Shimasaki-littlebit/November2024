using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// カメラの動き
/// </summary>
public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// カメラをずらす幅
    /// </summary>
    [SerializeField]
    private float cameraShift;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;
    }

    private void FixedUpdate()
    {
        TrackingPlayer();
    }

    /// <summary>
    /// プレイヤーを追尾する
    /// </summary>
    private void TrackingPlayer()
    {
        Vector3 cameraPos = transform.position;

        // プレイヤーの重さを見てカメラ位置を変える
        switch (playerManager.GetWeight)
        {
            // 軽い
            case Weight.LIGHT:

                cameraPos.y = playerManager.Player.transform.position.y - cameraShift;

                break;

            // 普通
            case Weight.NORMAL:

                cameraPos.y = playerManager.Player.transform.position.y;

                break;

            // 重い
            case Weight.HEAVY:

                cameraPos.y = playerManager.Player.transform.position.y + cameraShift;

                break;
        }

        // 座標反映
        transform.position = cameraPos;
    }
}
