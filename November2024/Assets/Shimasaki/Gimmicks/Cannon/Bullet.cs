using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �v���C���[�̃_���[�W�X�N���v�g
    /// </summary>
    private PlayerDamage playerDamage;

    /// <summary>
    /// �e�̉摜
    /// </summary>
    [SerializeField]
    private GameObject bulletImage;

    /// <summary>
    /// �ړ����x
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// �e�̃_���[�W
    /// </summary>
    [SerializeField]
    private int bulletDamage;

    /// <summary>
    /// �E�����ɔ�Ԃ�
    /// </summary>
    private bool isRight;

    /// <summary>
    /// �v���C���[�̃��C���[�}�X�N
    /// </summary>
    private int playerLayerMask = 1 << 3;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // �v���C���[�_���[�W�X�N���v�g�擾
        playerDamage = playerManager.Player.GetComponent<PlayerDamage>();
    }

    private void Update()
    {
        HitPlayer();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// ���ˏ���
    /// </summary>
    /// <param name="shotRight">���˕���</param>
    public void Shot(bool shotRight)
    {
        // ���˕���������
        isRight = shotRight;

        ImageDirection();
    }

    /// <summary>
    /// �摜�̕�����ς���
    /// </summary>
    private void ImageDirection()
    {
        var rotate = bulletImage.transform.eulerAngles;

        if (isRight)
        {
            rotate.z = 0.0f;           
        }
        else
        {
            rotate.z = 180.0f;
        }

        bulletImage.transform.eulerAngles = rotate;
    }

    /// <summary>
    /// �e�̈ړ�
    /// </summary>
    private void Move()
    {
        var movePos = transform.position;

        // �E����
        if (isRight)
        {
            // �ړ����Z
            movePos.x += moveSpeed * Time.deltaTime;
        }

        // ������
        else
        {
            // �ړ����Z
            movePos.x -= moveSpeed * Time.deltaTime;
        }


        // ���W�𔽉f
        transform.position = movePos;
    }

    /// <summary>
    /// �v���C���[�ɓ��������ۂ̏���
    /// </summary>
    private void HitPlayer()
    {
        // �v���C���[�ɓ������Ă��Ȃ���ΏI��
        if (!HitBoxRay()) return;

        // �v���C���[�ɔ�_���[�W����
        playerDamage.TakeDamage(bulletDamage);

        Delete();
    }

    /// <summary>
    /// �e�̓����蔻��
    /// </summary>
    /// <returns>true = ��������</returns>
    private bool HitBoxRay()
    {
        //Gizmos.color = Color.yellow;

        //Gizmos.DrawWireCube(transform.position, transform.localScale * 0.5f);

        // �v���C���[�݂̂ɓ�����{�b�N�X�L���X�g���΂�
        if (Physics2D.BoxCast(transform.position, transform.localScale, 0.0f, Vector2.zero, 0.0f, playerLayerMask))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// �J�����O�ɍs���ƍ폜
    /// </summary>
    private void OnBecameInvisible()
    {
        Delete();
    }

    /// <summary>
    /// ������ۂ̏���
    /// </summary>
    private void Delete()
    {
        Destroy(gameObject);
    }
}
