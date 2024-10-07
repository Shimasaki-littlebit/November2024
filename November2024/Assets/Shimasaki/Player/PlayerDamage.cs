using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    /// ���G���Ԃ��ǂ���
    /// </summary>
    private bool isInvincible;

    /// <summary>
    /// �������~�܂��Ă��鎞�̃^�C�}�[
    /// </summary>
    private Timer stopTimer;

    /// <summary>
    /// �Q�[���I�[�o�[�v�Z�p�^�C�}�[
    /// </summary>
    private Timer gameOverTimer;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // ���G���ԃ^�C�}�[������
        invincibleTimer = new();
        // ���G���ԏ�����
        isInvincible = false;
        // ��~�^�C�}�[������
        stopTimer = new();
        // �Q�[���I�[�o�[�^�C�}�[�擾
        gameOverTimer = new();
    }

    
    private void FixedUpdate()
    {
        // ���G���ԂȂ疳�G���Ԍv�Z
        if (isInvincible)
        {
            invincibleTimer.Count(Time.deltaTime);
        }

        // �Q�[���I�[�o�[�^�C�}�[�̌v�Z
        gameOverTimer.Count(Time.deltaTime);

        StopTimeCalc();
    }

    /// <summary>
    /// ��_���[�W
    /// </summary>
    /// <param name="damageValue">�_���[�W�l</param>
    public void TakeDamage(int damageValue)
    {
        // ���G���ԂȂ�I��
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
        // �v���C���[�̈ړ����~
        playerManager.IsMovable = false;

        // �Q�[���I�[�o�[�̃^�C�}�[�J�n
        gameOverTimer.SetTimer(playerManager.GameOverWait, EndScene);
    }

    /// <summary>
    /// ���G���ԊJ�n
    /// </summary>
    private void StartInvincible()
    {
        isInvincible = true;

        // ���G���ԃ^�C�}�[��ݒ�
        invincibleTimer.SetTimer(playerManager.InvincibleTime,FinishInvincible);
    }

    /// <summary>
    /// ���G���ԏI��
    /// </summary>
    private void FinishInvincible()
    {
        isInvincible = false;
    }

    /// <summary>
    /// ������~���̎��Ԍv�Z
    /// </summary>
    private void StopTimeCalc()
    {
        // �ڒn���Ȃ痎����~�^�C�}�[���J�n
        if (playerManager.IsGround)
        {
            // �J�n���Ă��Ȃ���ΊJ�n
            if (!stopTimer.isTimerStart())
            {
                stopTimer.SetTimer(playerManager.StopLimit, StopTimeLimit);
            }

            // �J�n���Ă���΃^�C�}�[�v�Z
            else
            {
                stopTimer.Count(Time.deltaTime);
            }
        }

        // �ڒn���łȂ���΃^�C�}�[�����Z�b�g
        else
        {
            // �^�C�}�[���n�܂��Ă���΃^�C�}�[���Z�b�g
            if (stopTimer.isTimerStart())
            {
                stopTimer.ResetTimer();
            }
        }
    }

    /// <summary>
    /// ������~���Ԃ��I���������̏���
    /// </summary>
    private void StopTimeLimit()
    {
        // �Q�[���I�[�o�[��
        GameOver();
    }

    /// <summary>
    /// �V�[���I��
    /// </summary>
    private void EndScene()
    {
        // ���U���g�V�[����
        SceneManager.LoadScene("ResultScene");
    }
}
