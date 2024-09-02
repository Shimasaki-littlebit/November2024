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
        STOP,
        NORMAL,
        HEAVY,
        LIGHT,
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
        get=> weight;
        set=> weight = value;
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

    // Start is called before the first frame update
    private void Start()
    {
        // �������Ԃŏ�����
        isMovable = true;

        // ���ǂɓ������Ă��Ȃ���Ԃŏ�����
        isRightWall = false;
        isLeftWall = false;

        // �ʏ푬�x�ŏ�����
        weight = Weight.NORMAL;
    }
}