using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーマネージャー
/// </summary>
public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
    /// <summary>
    /// 重さ列挙型
    /// </summary>
    public enum Weight
    {
        STOP,
        NORMAL,
        HEAVY,
        LIGHT,
    }

    /// <summary>
    /// プレイヤーの重さ
    /// </summary>
    private Weight weight;

    /// <summary>
    /// 重さ取得
    /// </summary>
    public Weight GetWeight
    {
        get=> weight;
        set=> weight = value;
    }

    /// <summary>
    /// 体力
    /// </summary>
    [SerializeField]
    private int hitPoint;

    /// <summary>
    /// 体力取得
    /// </summary>
    public int HitPoint
    {
        get => hitPoint;
        set => hitPoint = value;
    }

    /// <summary>
    /// 横移動速度
    /// </summary>
    [SerializeField]
    private float horizontalSpeed;

    /// <summary>
    /// 横移動速度取得
    /// </summary>
    public float HorizontalSpeed
    {
        get => horizontalSpeed;
        set => horizontalSpeed = value;
    }

    /// <summary>
    /// 動けるか
    /// </summary>
    private bool isMovable;

    /// <summary>
    /// 動けるか取得
    /// </summary>
    public bool IsMovable
    {
        get => isMovable;
        set => isMovable = value;
    }

    /// <summary>
    /// 右壁に当たっているか
    /// </summary>
    private bool isRightWall;

    /// <summary>
    /// 右壁に当たっているか取得
    /// </summary>
    public bool IsRightWall
    {
        get => isRightWall;
        set => isRightWall = value;
    }

    /// <summary>
    /// 左壁に当たっているか
    /// </summary>
    private bool isLeftWall;

    /// <summary>
    /// 左壁に当たっているか取得
    /// </summary>
    public bool IsLeftWall
    {
        get => isLeftWall;
        set => isLeftWall = value;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // 動ける状態で初期化
        isMovable = true;

        // 両壁に当たっていない状態で初期化
        isRightWall = false;
        isLeftWall = false;

        // 通常速度で初期化
        weight = Weight.NORMAL;
    }
}