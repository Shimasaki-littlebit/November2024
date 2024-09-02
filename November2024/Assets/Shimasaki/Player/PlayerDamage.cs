using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̔�_���[�W����
/// </summary>
public class PlayerDamage : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// ���G���ԃ^�C�}�[
    /// </summary>
    private Timer invincibleTimer;

    /// <summary>
    /// ���G����
    /// </summary>
    [SerializeField]
    private float invincibleTime;

    /// <summary>
    /// ���G���Ԃ��ǂ���
    /// </summary>
    private bool isInvincible;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // �^�C�}�[������
        invincibleTimer = new();
        // ���G���ԏ�����
        isInvincible = false;
    }

    
    private void FixedUpdate()
    {
        // ���G���ԂȂ疳�G���Ԍv�Z
        if (isInvincible)
        {
            invincibleTimer.Count(Time.deltaTime);
        }
    }

    /// <summary>
    /// ��_���[�W
    /// </summary>
    /// <param name="damageValue">�_���[�W�l</param>
    public void TakeDamage(int damageValue)
    {
        // ���G���ԂȂ烊�^�[��
        if (isInvincible) return;

        // ���G���ԊJ�n
        StartInvincible();

        // �̗͂����炷
        playerManager.HitPoint-= damageValue;

        // �̗͂��Ȃ���΃Q�[���I�[�o�[����
        if(playerManager.HitPoint <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// �Q�[���I�[�o�[����
    /// </summary>
    private void GameOver()
    {
        
    }

    /// <summary>
    /// ���G���ԊJ�n
    /// </summary>
    private void StartInvincible()
    {
        isInvincible = true;

        // ���G���ԃ^�C�}�[��ݒ�
        invincibleTimer.SetTimer(invincibleTime,FinishInvincible);
    }

    /// <summary>
    /// ���G���ԏI��
    /// </summary>
    private void FinishInvincible()
    {
        isInvincible = false;
    }

}
