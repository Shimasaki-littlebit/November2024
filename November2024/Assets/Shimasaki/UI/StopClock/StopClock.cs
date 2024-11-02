using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̗�����~���̃^�C�����~�b�g�\��
/// </summary>
public class StopClock : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �\���I�u�W�F�N�g
    /// </summary>
    [SerializeField]
    private GameObject clockObject;

    /// <summary>
    /// �\���̓��g�Q�[�W
    /// </summary>
    private Image clockInner;

    /// <summary>
    /// �\���܂ł̎��Ԑ����l
    /// </summary>
    private float initTimerStart = 1.0f;

    /// <summary>
    /// �\���܂ł̎��Ԑ����v�Z�l
    /// </summary>
    private float timerStart;

    /// <summary>
    /// �\�����Ԑ����l
    /// </summary>
    private float initTimeLimit;

    /// <summary>
    /// �\�����Ԑ����v�Z�l
    /// </summary>
    private float timeLimit;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // �������Ԃ�������
        ResetTimeLimits();

        // �\���̓��g�Q�[�W�擾
        clockInner = clockObject.transform.GetChild(0).GetComponent<Image>();

        clockInner.fillAmount = 1.0f;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        ClockCalc();

        ClockInnerDisplay();
    }

    /// <summary>
    /// �^�C�}�[�\���̌v�Z
    /// </summary>
    private void ClockCalc()
    {
        // �v���C���[���ڒn��
        if (playerManager.IsGround)
        {
            if (timerStart > 0.0f)
            {
                timerStart -= Time.deltaTime;
            }
            else
            {
                // �^�C�}�[����\���Ȃ�\��
                if (!clockObject.activeSelf)
                {
                    clockObject.SetActive(true);
                }

                // �^�C�����~�b�g�\�������Z
                timeLimit -= Time.deltaTime;
            }
        }
        // �ڒn������Ȃ����
        else
        {
            // �^�C�}�[�l�������ł������Ă���΃��Z�b�g
            if (timerStart < initTimerStart)
            {
                ResetTimeLimits();
            }

            // �^�C�}�[���\�����Ȃ��\��
            if (clockObject.activeSelf)
            {
                clockObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// �^�C�}�[�̕\��
    /// </summary>
    private void ClockInnerDisplay()
    {
        // �^�C�}�[���\������Ă��Ȃ���ΏI��
        if (!clockObject.activeSelf) return;

        // �\���̈�𐧌����Ԃ���v�Z���Ĕ��f
        clockInner.fillAmount = timeLimit / initTimeLimit;
    }

    /// <summary>
    /// ���Ԑ����̏�����
    /// </summary>
    private void ResetTimeLimits()
    {
        Debug.Log("���Z�b�g");

        // �^�C�}�[�\���܂ł̎��Ԃ�������
        timerStart = initTimerStart;

        // �^�C�}�[�̎��Ԑ����l���v�Z
        initTimeLimit = playerManager.StopLimit - initTimerStart;

        // �^�C�}�[�̎��Ԑ����l��������
        timeLimit = initTimeLimit;
    }
}
