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
        LIGHT,
        NORMAL,
        HEAVY,
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
        get => weight;
        set => weight = value;
    }

    /// <summary>
    /// プレイヤーの参照
    /// </summary>
    private GameObject player;

    /// <summary>
    /// プレイヤーの参照取得
    /// </summary>
    public GameObject Player
    {
        get => player;
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
    /// 通常落下速度
    /// </summary>
    [SerializeField]
    private float nomalFallSpeed;

    /// <summary>
    /// 通常落下速度取得
    /// </summary>
    public float NomalFallSpeed
    {
        get => nomalFallSpeed;
        set => nomalFallSpeed = value;
    }

    /// <summary>
    /// 軽さ速度倍率
    /// </summary>
    [SerializeField]
    private float lightMagnification;

    /// <summary>
    /// 軽さ速度倍率取得
    /// </summary>
    public float LightMagnification
    {
        get => lightMagnification;
        set => lightMagnification = value;
    }

    /// <summary>
    /// 重さ速度倍率
    /// </summary>
    [SerializeField]
    private float heavyMagnification;

    /// <summary>
    /// 重さ速度倍率取得
    /// </summary>
    public float HeavyMagnification
    {
        get => heavyMagnification;
        set => heavyMagnification = value;
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

    /// <summary>
    /// 地面に当たっているか
    /// </summary>
    private bool isGround;

    /// <summary>
    /// 地面に当たっているか取得
    /// </summary>
    private bool IsGround
    {
        get => isGround;
        set => isGround = value;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // 通常速度で初期化
        weight = Weight.NORMAL;

        // プレイヤーの参照を取得
        player = gameObject;

        // 動ける状態で初期化
        isMovable = true;

        // 両壁に当たっていない状態で初期化
        isRightWall = false;
        isLeftWall = false;
    }
}