using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// カメラの動き
/// </summary>
public class CameraMove : SingletonMonoBehaviour<CameraMove>
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

    ///// <summary>
    ///// 移動用タイマー
    ///// </summary>
    //private Timer moveTimer;

    //private bool isMoveUp;

    //private bool isMoveDown;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        //// タイマー初期化
        //moveTimer = new();

        //isMoveUp = false;
        //isMoveDown = false;
    }

    private void FixedUpdate()
    {
        TrackingPlayer();

        //MoveUp();

        // タイマー計算
        //moveTimer.Count(Time.deltaTime);
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

    //public void StartMoveUp()
    //{
    //    isMoveUp = true;

    //    moveTimer.SetTimer(0.5f, EndMoveUp);
    //}

    //private void EndMoveUp()
    //{
    //    isMoveUp = false;

    //    var pos = transform.localPosition;

    //    pos.y = Mathf.Round(pos.y);

    //    transform.localPosition = pos;
    //}

    //private void MoveUp()
    //{
    //    if (!isMoveUp) return;

    //    var cameraPos = transform.localPosition;

    //    cameraPos.y += cameraShift * Time.deltaTime * 2.0f;

    //    transform.localPosition = cameraPos;
    //}
}
