using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �c�ɕ��񂾏ꍇ�̃{�^���J��
/// </summary>
public class VerticalUIControl : MonoBehaviour
{
    /// <summary>
    /// �I�����̃{�^���z��
    /// </summary>
    [SerializeField]
    private GameObject[] targetButtons;

    /// <summary>
    /// �I���{�^���ԍ�
    /// </summary>
    private int selectNum = 0;

    /// <summary>
    /// �I��ł���{�^���ԍ��擾
    /// </summary>
    public int SelectNum
    {
        get => selectNum;
    }

    /// <summary>
    /// ���͒�~�t���O
    /// </summary>
    private bool isStopInput = false;

    /// <summary>
    /// ���͒�~����
    /// </summary>
    private float stopInputTime = 0.2f;

    /// <summary>
    /// ���͒�~�v�Z�p
    /// </summary>
    private float calTime = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // �����\��
        DisplayImage();
    }

    // Update is called once per frame
    private void Update()
    {
        ButtonChange();
    }

    private void FixedUpdate()
    {
        if (isStopInput)
        {
            CalculationStopTime();
        }
    }

    /// <summary>
    /// �{�^���̕ύX�����m
    /// </summary>
    private void ButtonChange()
    {
        // ���͒�~���Ȃ�Ԃ�
        if (isStopInput) return;

        float vertical = 0.0f;

        // ���X�e�B�b�N�c���͂����m
        vertical = Input.GetAxisRaw("Vertical");

        // ������or�L�[�{�[�hS���͂�����΃{�^���ԍ��𑝂₷
        if (vertical > 0.0f || Input.GetKey(KeyCode.S))
        {
            // ���͒�~�t���O�����Ă�
            isStopInput = true;

            // �����Ȃ�Ԃ�
            if (selectNum <= 0) return;

            --selectNum;

            // �摜�X�V
            DisplayImage();
        }
        // �����or�L�[�{�[�hW���͂�����΃{�^���ԍ��𑝂₷
        else if (vertical < 0.0f || Input.GetKey(KeyCode.W))
        {
            // ���͒�~�t���O�����Ă�
            isStopInput = true;

            // ����Ȃ�Ԃ�
            if (selectNum >= targetButtons.Length - 1) return;

            ++selectNum;

            // �摜�X�V
            DisplayImage();
        }
    }

    /// <summary>
    /// �\���摜�̍X�V
    /// </summary>
    private void DisplayImage()
    {
        int buttonNum = 0;

        // �S�Ẵ{�^�������đI������Ă���{�^���̉摜�̂ݕ\������
        foreach (var button in targetButtons)
        {
            if (buttonNum == selectNum)
            {
                button.SetActive(true);
            }
            else
            {
                button.SetActive(false);
            }

            ++buttonNum;
        }
    }

    /// <summary>
    /// ���͒�~���̎��Ԍv�Z
    /// </summary>
    private void CalculationStopTime()
    {
        calTime += Time.deltaTime;

        // ���͒�~���Ԃ��I���Γ��͂��󂯕t�����Ԃ�
        if (calTime >= stopInputTime)
        {
            isStopInput = false;

            calTime = 0.0f;
        }
    }
}
