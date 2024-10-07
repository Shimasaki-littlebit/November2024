using System.Collections;
using System.Collections.Generic;
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
    /// ����
    /// </summary>
    private float timeLimit;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // �������Ԃ�������
        timeLimit = playerManager.StopLimit;

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
            // �^�C�}�[����\���Ȃ�\��
            if (!clockObject.activeSelf)
            {
                clockObject.SetActive(true);
            }

            // �^�C�����~�b�g�\�������Z
            timeLimit -= Time.deltaTime;
        }

        // �ڒn������Ȃ����
        else
        {
            // �^�C�}�[����\���Ȃ�I��
            if (!clockObject.activeSelf) return;

            // �^�C�����~�b�g�\��������
            timeLimit = playerManager.StopLimit;

            // �^�C�}�[��\��
            clockObject.SetActive(false);
        }
    }

    /// <summary>
    /// �^�C�}�[�̕\��
    /// </summary>
    private void ClockInnerDisplay()
    {
        // �ڒn���łȂ���ΏI��
        if (!playerManager.IsGround) return;

        // �\���̈�𐧌����Ԃ���v�Z���Ĕ��f
        clockInner.fillAmount = timeLimit / playerManager.StopLimit;
    }
}
