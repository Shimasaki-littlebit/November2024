using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�}�l�[�W���[
/// </summary>
public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{
    /// <summary>
    /// �d���񋓌^
    /// </summary>
    public enum Weight
    {
        LIGHT,
        NORMAL,
        HEAVY,
    }

    /// <summary>
    /// �v���C���[�̏d��
    /// </summary>
    private Weight weight;

    /// <summary>
    /// �d���擾
    /// </summary>
    public Weight GetWeight
    {
        get => weight;
        set => weight = value;
    }

    /// <summary>
    /// �v���C���[�̎Q��
    /// </summary>
    private GameObject player;

    /// <summary>
    /// �v���C���[�̎Q�Ǝ擾
    /// </summary>
    public GameObject Player
    {
        get => player;
    }

    /// <summary>
    /// �̗�
    /// </summary>
    [SerializeField]
    private int hitPoint;

    /// <summary>
    /// �̗͎擾
    /// </summary>
    public int HitPoint
    {
        get => hitPoint;
        set => hitPoint = value;
    }

    /// <summary>
    /// ���ړ����x
    /// </summary>
    [SerializeField]
    private float horizontalSpeed;

    /// <summary>
    /// ���ړ����x�擾
    /// </summary>
    public float HorizontalSpeed
    {
        get => horizontalSpeed;
        set => horizontalSpeed = value;
    }

    /// <summary>
    /// �ʏ헎�����x
    /// </summary>
    [SerializeField]
    private float nomalFallSpeed;

    /// <summary>
    /// �ʏ헎�����x�擾
    /// </summary>
    public float NomalFallSpeed
    {
        get => nomalFallSpeed;
        set => nomalFallSpeed = value;
    }

    /// <summary>
    /// �y�����x�{��
    /// </summary>
    [SerializeField]
    private float lightMagnification;

    /// <summary>
    /// �y�����x�{���擾
    /// </summary>
    public float LightMagnification
    {
        get => lightMagnification;
        set => lightMagnification = value;
    }

    /// <summary>
    /// �d�����x�{��
    /// </summary>
    [SerializeField]
    private float heavyMagnification;

    /// <summary>
    /// �d�����x�{���擾
    /// </summary>
    public float HeavyMagnification
    {
        get => heavyMagnification;
        set => heavyMagnification = value;
    }

    /// <summary>
    /// �����邩
    /// </summary>
    private bool isMovable;

    /// <summary>
    /// �����邩�擾
    /// </summary>
    public bool IsMovable
    {
        get => isMovable;
        set => isMovable = value;
    }

    /// <summary>
    /// �E�ǂɓ������Ă��邩
    /// </summary>
    private bool isRightWall;

    /// <summary>
    /// �E�ǂɓ������Ă��邩�擾
    /// </summary>
    public bool IsRightWall
    {
        get => isRightWall;
        set => isRightWall = value;
    }

    /// <summary>
    /// ���ǂɓ������Ă��邩
    /// </summary>
    private bool isLeftWall;

    /// <summary>
    /// ���ǂɓ������Ă��邩�擾
    /// </summary>
    public bool IsLeftWall
    {
        get => isLeftWall;
        set => isLeftWall = value;
    }

    /// <summary>
    /// �n�ʂɓ������Ă��邩
    /// </summary>
    private bool isGround;

    /// <summary>
    /// �n�ʂɓ������Ă��邩�擾
    /// </summary>
    private bool IsGround
    {
        get => isGround;
        set => isGround = value;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // �ʏ푬�x�ŏ�����
        weight = Weight.NORMAL;

        // �v���C���[�̎Q�Ƃ��擾
        player = gameObject;

        // �������Ԃŏ�����
        isMovable = true;

        // ���ǂɓ������Ă��Ȃ���Ԃŏ�����
        isRightWall = false;
        isLeftWall = false;
    }
}