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

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;
    }

    private void Update()
    {
        TrackingPlayer();
    }

    /// <summary>
    /// プレイヤーを追尾する
    /// </summary>
    private void TrackingPlayer()
    {
        Vector3 cameraPos = transform.position;

        cameraPos.y = playerManager.Player.transform.position.y -3.0f;

        // 座標反映
        transform.position = cameraPos;
    }
}
