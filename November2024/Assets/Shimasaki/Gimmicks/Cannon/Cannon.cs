using UnityEngine;

/// <summary>
/// ��C
/// </summary>
public class Cannon : MonoBehaviour
{
    /// <summary>
    /// �e�̃v���n�u
    /// </summary>
    [SerializeField]
    private GameObject bulletPrefab;

    /// <summary>
    /// ���˗p�^�C�}�[
    /// </summary>
    private Timer shotTimer;

    /// <summary>
    /// ���ˊԊu
    /// </summary>
    private float shotInterval = 3.0f;

    /// <summary>
    /// �E������
    /// </summary>
    [SerializeField]
    private bool isRight;

    /// <summary>
    /// �E�������擾
    /// </summary>
    public bool IsRight
    {
        get => isRight;
        set => isRight = value;
    }

    // Start is called before the first frame update
    private void Start()
    {
        shotTimer = new();

        // �^�C�}�[�Z�b�g
        shotTimer.SetTimer(shotInterval, FinishShotTimer);
    }

    private void FixedUpdate()
    {
        if (shotTimer.isTimerStart())
        {
            // �^�C�}�[�J�E���g
            shotTimer.Count(Time.deltaTime);
        }
        else
        {
            // �^�C�}�[�Z�b�g
            shotTimer.SetTimer(shotInterval, FinishShotTimer);
        }
    }

    /// <summary>
    /// �^�C�}�[�I�����̏���
    /// </summary>
    private void FinishShotTimer()
    {
        // ����
        ShotBullet();

        //// �^�C�}�[�Z�b�g
        //shotTimer.SetTimer(shotInterval, FinishShotTimer);
    }

    /// <summary>
    /// �e�̔���
    /// </summary>
    private void ShotBullet()
    {
        // �������W�p
        Vector2 shotPos = transform.position;

        // �E�����̏ꍇ
        if (isRight)
        {
            // �{�̉E���̍��W���v�Z
            shotPos += Vector2.right;

            // �{�̉E���ɒe�𐶐�
            var bullet = Instantiate(bulletPrefab, shotPos, Quaternion.identity);

            // �X�N���v�g���擾���Ĕ��ˏ���
            var bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Shot(isRight);
        }

        // �������̏ꍇ
        else
        {
            // �{�̉E���̍��W���v�Z
            shotPos += Vector2.left;

            // �{�̉E���ɒe�𐶐�
            var bullet = Instantiate(bulletPrefab, shotPos, Quaternion.identity);

            // �X�N���v�g���擾���Ĕ��ˏ���
            var bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Shot(isRight);
        }
    }
}
