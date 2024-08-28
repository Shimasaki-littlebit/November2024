using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    /// �^�C�}�[�̎��Ԃ�ݒ�
    /// </summary>
    /// <param name="setTime">�ݒ�b��</param>
    /// <param name="isOverWrite">true = �㏑���J�n</param>
    public void SetTimer(float setTime ,bool isOverWrite = false)
    {
        // �㏑�����\�ȏꍇ
        if(isOverWrite == true)
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

        limitTime = setTime;
    }

    /// <summary>
    /// �^�C�}�[������������
    /// </summary>
    public void ResetTimer()
    {
        time = 0.0f;
        limitTime = 0.0f;
    }

    /// <summary>
    /// ���Ԍv�Z
    /// </summary>
    public void Calculation(float calDeltaTime)
    {
        if (!isTimerStart()) return;

        time += calDeltaTime;
    }

    /// <summary>
    /// �ݒ莞�Ԃ��I��������
    /// </summary>
    /// <returns>true = �I��</returns>
    public bool isTimeLimit()
    {
        if (!isTimerStart()) return false;

        // �ݒ莞�Ԃ��I��������true��Ԃ����Z�b�g
        if (time >= limitTime)
        {
            ResetTimer();

            return true;
        }

        return false;
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
