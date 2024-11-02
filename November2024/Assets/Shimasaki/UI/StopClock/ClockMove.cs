using UnityEngine;

/// <summary>
/// プレイヤー落下停止時時間制限タイマーUIの動き
/// </summary>
public class ClockMove : MonoBehaviour
{
    /// <summary>
    /// オフセット
    /// </summary>
    [SerializeField]
    private Vector3 offset;

    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// プレイヤーのトランスフォーム
    /// </summary>
    private Transform playerTransform;

    /// <summary>
    /// タイマー表示のトランスフォーム
    /// </summary>
    [SerializeField]
    private Transform clockTransform;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンス取得
        playerManager = PlayerManager.Instance;

        // プレイヤーのトランスフォーム取得
        playerTransform = playerManager.Player.transform;
    }

    private void FixedUpdate()
    {
        // タイマーの位置をプレイヤー+オフセットの位置に調整し続ける
        clockTransform.position = RectTransformUtility.
            WorldToScreenPoint(Camera.main,playerTransform.position + offset);
    }
}
