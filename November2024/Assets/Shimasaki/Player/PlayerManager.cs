using UnityEngine;
using PlayerWeight;

namespace PlayerWeight
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
}

/// <summary>
/// �v���C���[�}�l�[�W���[
/// </summary>
public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
{

    /// <summary>
    /// �v���C���[�̏d��
    /// </summary>
    [SerializeField]
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
    /// �d����
    /// </summary>
    [SerializeField]
    private GameObject heavyWeapon;

    /// <summary>
    /// �d����擾
    /// </summary>
    public GameObject HeavyWeapon
    {
        get => heavyWeapon;
    }

    /// <summary>
    /// �y�����̃v���y��
    /// </summary>
    [SerializeField]
    private GameObject lightPropeller;

    /// <summary>
    /// �y�����̃v���y���擾
    /// </summary>
    public GameObject LightPropeller
    {
        get => lightPropeller;
    }

    /// <summary>
    /// �v���C���[�̉摜
    /// </summary>
    [SerializeField]
    private GameObject playerImage;

    /// <summary>
    /// �v���C���[�̉摜�擾
    /// </summary>
    public GameObject PlayerImage
    {
        get => playerImage;
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
    /// ���G����
    /// </summary>
    [SerializeField]
    private float invincibleTime;

    /// <summary>
    /// ���G���Ԏ擾
    /// </summary>
    public float InvincibleTime
    {
        get => invincibleTime;
        set => invincibleTime = value;
    }

    /// <summary>
    /// �n�ʂɓ������Ă��邩
    /// </summary>
    private bool isGround;

    /// <summary>
    /// �n�ʂɓ������Ă��邩�擾
    /// </summary>
    public bool IsGround
    {
        get => isGround;
        set => isGround = value;
    }

    /// <summary>
    /// ������~���̃^�C�����~�b�g
    /// </summary>
    [SerializeField]
    private float stopLimit;

    /// <summary>
    /// ������~���^�C�����~�b�g�擾
    /// </summary>
    public float StopLimit
    {
        get => stopLimit;
    }

    /// <summary>
    /// �Q�[���I�[�o�[���ҋ@����
    /// </summary>
    [SerializeField]
    private float gameOverWait;

    /// <summary>
    /// �Q�[���I�[�o�[���ҋ@���Ԏ擾
    /// </summary>
    public float GameOverWait
    {
        get => gameOverWait;
    }

    /// <summary>
    /// �y�����̉摜
    /// </summary>
    [SerializeField]
    private Sprite lightImage;

    /// <summary>
    /// �y�����̉摜
    /// </summary>
    public Sprite LightImage
    {
        get => lightImage;
    }

    /// <summary>
    /// �ʏ펞�̉摜
    /// </summary>
    [SerializeField]
    private Sprite normalImage;

    /// <summary>
    /// �ʏ펞�̉摜
    /// </summary>
    public Sprite NormalImage
    {
        get => normalImage;
    }

    /// <summary>
    /// �d�����̉摜
    /// </summary>
    [SerializeField]
    private Sprite heavyImage;

    /// <summary>
    /// �d�����̉摜
    /// </summary>
    public Sprite HeavyImage
    {
        get => heavyImage;
    }

    override protected void Awake()
    {
        CheckInstance();

        // �v���C���[�̎Q�Ƃ��擾
        player = gameObject;
    }

    // Start is called before the first frame update
    private void Start()
    {
        // �ʏ푬�x�ŏ�����
        weight = Weight.NORMAL;

        // �d������\���ŏ�����
        heavyWeapon.SetActive(false);
        // �v���y�����\���ŏ�����
        lightPropeller.SetActive(false);

        // �������Ԃŏ�����
        isMovable = true;

        // ���ǂɓ������Ă��Ȃ���Ԃŏ�����
        isRightWall = false;
        isLeftWall = false;
    }
}