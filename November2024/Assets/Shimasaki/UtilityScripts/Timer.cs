using UnityEngine.Events;

/// <summary>
/// �^�C�}�[�N���X
/// </summary>
public class Timer
{
    /// <summary>
    /// �v�Z����
    /// </summary>
    private float time = 0.0f;

    /// <summary>
    /// �^�C�}�[�ݒ莞��
    /// </summary>
    private float limitTime = 0.0f;

    /// <summary>
    /// ���s���郁�\�b�h
    /// </summary>
    private UnityAction action;

    /// <summary>
    /// �^�C�}�[�̎��Ԃ�ݒ�
    /// </summary>
    /// <param name="setTime">�ݒ�b��</param>
    /// <param name="setAction">�ݒ胁�\�b�h</param>
    /// <param name="isOverWrite">�㏑�����邩</param>
    public void SetTimer(float setTime, UnityAction setAction, bool isOverWrite = false)
    {
        // �㏑�����\�ȏꍇ
        if (isOverWrite == true)
        {
            ResetTimer();
        }
        // �㏑���ł��Ȃ��ꍇ
        else
        {
            // �^�C�}�[�������X�^�[�g���Ă���΃��^�[��
            if (isTimerStart()) return;
        }

        // �}�C�i�X�b���̏ꍇ���^�[��
        if (setTime < 0.0f) return;

        // �^�C�}�[���Ԃ�ݒ�
        limitTime = setTime;

        // ���\�b�h��ݒ�
        action = setAction;
    }

    /// <summary>
    /// �^�C�}�[������������
    /// </summary>
    public void ResetTimer()
    {
        time = 0.0f;
        limitTime = 0.0f;

        action = null;
    }

    /// <summary>
    /// ���Ԍv�Z
    /// </summary>
    public void Count(float calDeltaTime)
    {
        if (!isTimerStart()) return;

        time += calDeltaTime;

        JudgeTimeLimit();
    }

    /// <summary>
    /// �ݒ莞�Ԃ��I�������烁�\�b�h�����s
    /// </summary>
    public void JudgeTimeLimit()
    {
        // �ݒ莞�Ԃ��I����������s�����Z�b�g
        if (time >= limitTime)
        {
            if (action != null)
            {
                action();
            }

            ResetTimer();
        }
    }

    /// <summary>
    /// �^�C�}�[���X�^�[�g���Ă��邩
    /// </summary>
    /// <returns>true �X�^�[�g���Ă���</returns>
    public bool isTimerStart()
    {
        if (limitTime <= 0.0f) return false;

        return true;
    }
}
