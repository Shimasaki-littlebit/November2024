using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// プレイヤーの重さを変更するクラス
/// </summary>
public class PlayerChangeWeight : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// クールダウン用タイマー
    /// </summary>
    private Timer coolTimer;

    /// <summary>
    /// クールダウン時間
    /// </summary>
    private float coolTime = 0.5f;

    /// <summary>
    /// カメラ移動スクリプト
    /// </summary>
    private CameraMove camera;

    /// <summary>
    /// クールダウン中か
    /// </summary>
    private bool isCoolDown;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;

        // タイマー初期化
        coolTimer = new();

        // クールダウンフラグ初期化
        isCoolDown = false;

        camera = CameraMove.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        AlterWeight();
    }

    private void FixedUpdate()
    {
        // タイマー計算
        coolTimer.Count(Time.deltaTime);
    }

    /// <summary>
    /// 重さ変更
    /// </summary>
    private void AlterWeight()
    {
        // クールダウン中なら終了
        if (isCoolDown) return;

        // 入力がないか、同時入力があれば終了
        if (LeftInput() && RightInput()) return;
        if (!LeftInput() && !RightInput()) return;

        // 左シフト
        if (LeftInput())
        {
            ShiftLeft();
        }

        // 右シフト
        if (RightInput())
        {
            ShiftRight();
        }
    }

    /// <summary>
    /// RB,RTの入力判定
    /// </summary>
    /// <returns>true = 入力あり</returns>
    private bool RightInput()
    {
        if (Input.GetAxisRaw("RTrigger") > 0.0f) return true;
        if (Input.GetKeyDown("joystick button 5")) return true;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return true;

        return false;
    }

    /// <summary>
    /// LB,LTの入力判定
    /// </summary>
    /// <returns>true = 入力あり</returns>
    private bool LeftInput()
    {
        if (Input.GetAxisRaw("LTrigger") > 0.0f) return true;
        if (Input.GetKeyDown("joystick button 4")) return true;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return true;

        return false;
    }

    /// <summary>
    /// 重さ右シフト
    /// </summary>
    private void ShiftRight()
    {
        // 既に重ければ終了
        if (playerManager.GetWeight >= Weight.HEAVY) return;

        // 右にシフト
        playerManager.GetWeight++;

        StartCoolDown();
    }

    /// <summary>
    /// 重さ左シフト
    /// </summary>
    private void ShiftLeft()
    {
        // 既に軽ければ終了
        if (playerManager.GetWeight <= Weight.LIGHT) return;

        // 左にシフト
        playerManager.GetWeight--;

        //camera.StartMoveUp();

        StartCoolDown();
    }

    /// <summary>
    /// クールダウン開始処理
    /// </summary>
    private void StartCoolDown()
    {
        isCoolDown = true;

        // タイマーをセット
        coolTimer.SetTimer(coolTime, FinishCoolDown);
    }

    /// <summary>
    /// クールダウン終了処理
    /// </summary>
    private void FinishCoolDown()
    {
        isCoolDown = false;
    }
}
