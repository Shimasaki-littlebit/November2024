using PlayerWeight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 重さによるカメラの位置変更
/// </summary>
public class CameraShift : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// 重い時の切り替え速度
    /// </summary>
    private float heavyChangeSpeed = 0.05f;

    /// <summary>
    /// 軽い時の切り替え速度
    /// </summary>
    private float lightChangeSpeed = 0.01f;

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

    // Update is called once per frame
    private void Update()
    {
        Shift();
    }

    /// <summary>
    /// カメラの位置変更
    /// </summary>
    private void Shift()
    {
        // ローカル座標取得
        var cameraPos = transform.localPosition;

        // プレイヤーの重さを見てローカル座標を変える
        switch (playerManager.GetWeight)
        {
            // 軽い
            case Weight.LIGHT:

                // 指定位置までゆっくりとカメラをずらす
                if (cameraPos.y > -cameraShift)
                {
                    cameraPos.y -= lightChangeSpeed;
                }
                else
                {
                    if (cameraPos.y != -cameraShift)
                    {
                        cameraPos.y = Mathf.Round(cameraPos.y);
                    }
                }

                break;

            // 普通
            case Weight.NORMAL:

                if (cameraPos.y > 0.0f)
                {
                    cameraPos = Vector3.MoveTowards(cameraPos, new Vector3(cameraPos.x, 0.0f, cameraPos.z), lightChangeSpeed);
                }
                else
                {
                    cameraPos = Vector3.MoveTowards(cameraPos, new Vector3(cameraPos.x, 0.0f, cameraPos.z), heavyChangeSpeed);
                }

                break;

            // 重い
            case Weight.HEAVY:

                // 指定位置までゆっくりとカメラをずらす
                if (cameraPos.y < cameraShift)
                {
                    cameraPos.y += heavyChangeSpeed;
                }
                else
                {
                    if (cameraPos.y != cameraShift)
                    {
                        cameraPos.y = Mathf.Round(cameraPos.y);
                    }
                }

                break;
        }

        transform.localPosition = cameraPos;
    }
}
