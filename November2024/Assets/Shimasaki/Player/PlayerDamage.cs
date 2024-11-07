using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerWeight;

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
    /// �̗͂̉摜
    /// </summary>
    private LifeUI lifeUI;

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

    /// <summary>
    /// �����ړ_�ŗp�^�C�}�[
    /// </summary>
    private Timer appearanceTimer;

    /// <summary>
    /// �_�ŗp�Ԋu
    /// </summary>
    private float appearanceInterval = 0.2f;

    /// <summary>
    /// �v���C���[�X�v���C�g�����_���[
    /// </summary>
    private SpriteRenderer playerSpriteRenderer;

    /// <summary>
    /// �y�����̃v���y���X�v���C�g�����_���[
    /// </summary>
    private SpriteRenderer lightPropellerSpriteRenderer;

    /// <summary>
    /// �X�e�[�W�̃X�R�A
    /// </summary>
    private StageScore stageScore;

    /// <summary>
    /// �T�E���h�}�l�[�W���[
    /// </summary>
    private SoundPlayManager soundPlayManager;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;
        // �C���X�^���X�擾
        soundPlayManager = SoundPlayManager.Instance;

        // �̗�UI�擾
        lifeUI = LifeUI.Instance;

        // ���G���ԃ^�C�}�[������
        invincibleTimer = new();
        // ���G���ԏ�����
        isInvincible = false;
        // ��~�^�C�}�[������
        stopTimer = new();
        // �Q�[���I�[�o�[�^�C�}�[������
        gameOverTimer = new();
        // �����ڃ^�C�}�[������
        appearanceTimer = new();

        // �X�v���C�g�����_���[�擾
        playerSpriteRenderer = playerManager.PlayerImage.GetComponent<SpriteRenderer>();
        lightPropellerSpriteRenderer = playerManager.LightPropeller.GetComponent<SpriteRenderer>();

        stageScore = StageScore.Instance;
    }


    private void FixedUpdate()
    {
        // ���G���ԂȂ疳�G���Ԍv�Z
        if (isInvincible)
        {
            invincibleTimer.Count(Time.deltaTime);

            // �����ڃ^�C�}�[�v�Z
            StartCalcAppearanceTimer();
        }
        else
        {
            // �����ڃ^�C�}�[���X�^�[�g���Ă���΃��Z�b�g
            if (appearanceTimer.isTimerStart())
            {
                appearanceTimer.ResetTimer();
            }
        }

        // �Q�[���I�[�o�[�^�C�}�[�̌v�Z
        gameOverTimer.Count(Time.deltaTime);

        // �����ڗp�^�C�}�[�̌v�Z
        appearanceTimer.Count(Time.deltaTime);

        // �Q�[���I�[�o�[���̎��Ԍv�Z
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
        playerManager.HitPoint -= damageValue;

        // ��_���[�W�̉����Đ�
        soundPlayManager.PlaySE(SoundPlayManager.SEKey.SE_DAMAGE);

        // �̗͕\��
        lifeUI.DisplayLife();

        // �̗͂��Ȃ���΃Q�[���I�[�o�[����
        if (playerManager.HitPoint <= 0)
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

        // ���S�t���O�𗧂Ă�
        playerManager.IsDead = true;

        // �X�R�A�������ĕێ�����
        stageScore.PlayEndScore();

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
        invincibleTimer.SetTimer(playerManager.InvincibleTime, FinishInvincible);
    }

    /// <summary>
    /// ���G���ԏI��
    /// </summary>
    private void FinishInvincible()
    {
        // ���G�t���O�����낷
        isInvincible = false;

        // �_���[�W�̓_�Ń^�C�}�[�����Z�b�g
        appearanceTimer.ResetTimer();

        // �e�_�ł��Ă��錩���ڂ����Z�b�g����
        ResetAppearance(playerSpriteRenderer);
        ResetAppearance(lightPropellerSpriteRenderer);
    }

    /// <summary>
    /// ������~���̎��Ԍv�Z
    /// </summary>
    private void StopTimeCalc()
    {
        // �ڒn���������Ă���Η�����~�^�C�}�[���J�n
        if (playerManager.IsGround && !playerManager.IsDead)
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
    /// �����ڗp�^�C�}�[���J�n
    /// </summary>
    private void StartCalcAppearanceTimer()
    {
        // �^�C�}�[�����ɊJ�n���Ă���ΏI��
        if (appearanceTimer.isTimerStart()) return;

        // �^�C�}�[�Z�b�g
        appearanceTimer.SetTimer(appearanceInterval, DamageAppearance);
    }

    /// <summary>
    /// ��_���[�W���̌�����
    /// </summary>
    private void DamageAppearance()
    {
        // �v���C���[�̌����ڂ�_�ł�����
        ImageFlashing(playerSpriteRenderer);

        // �y�����̓v���y�����_�ł�����
        if (playerManager.GetWeight == Weight.LIGHT)
        {
            ImageFlashing(lightPropellerSpriteRenderer);
        }
    }

    /// <summary>
    /// �摜�̓_��
    /// </summary>
    private void ImageFlashing(SpriteRenderer spriteRenderer)
    {
        // �����ڂ�����Ώ���
        if (spriteRenderer.color.a > 0.5f)
        {
            var color = spriteRenderer.color;

            color.a = 0.0f;

            spriteRenderer.color = color;
        }
        // �Ȃ���Ώo��
        else
        {
            var color = spriteRenderer.color;

            color.a = 1.0f;

            spriteRenderer.color = color;
        }
    }

    /// <summary>
    /// ��_���[�W���̌����ڂ��I��
    /// </summary>
    private void ResetAppearance(SpriteRenderer spriteRenderer)
    {
        // �������Ԃɂ���

        var color = spriteRenderer.color;

        color.a = 1.0f;

        spriteRenderer.color = color;
    }

    /// <summary>
    /// ������~���Ԃ��I���������̏���
    /// </summary>
    private void StopTimeLimit()
    {
        // �����̗͕��̃_���[�W��H����ăQ�[���I�[�o�[��
        TakeDamage(playerManager.HitPoint);
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
