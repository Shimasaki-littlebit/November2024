using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �c�ɕ��񂾏ꍇ�̃{�^���J��
/// </summary>
public class VerticalUIControl : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�I������Ă��鎞�̃{�^���z��")]
    private GameObject[] targetButtons;

    [Tooltip("�I��ł���{�^���̔ԍ�")]
    private int selectNum = 0;

    /// <summary>
    /// �I��ł���{�^���ԍ��擾
    /// </summary>
    public int SelectNum
    {
        get => selectNum;
    }

    [Tooltip("���͂��~�߂�t���O")]
    private bool isStopInput = false;

    [Tooltip("���͂��~�߂鎞��")]
    private float stopInputTime = 0.2f;

    [Tooltip("���Ԍv�Z�p")]
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

        // ���X�e�B�b�N�c���͂����m
        var vertical = Input.GetAxisRaw("Vertical");

        // �����͂�����΃{�^���ԍ��𑝂₷
        if (vertical > 0.0f)
        {
            // �����Ȃ�Ԃ�
            if (selectNum <= 0) return;

            --selectNum;

            // �摜�X�V
            DisplayImage();

        }
        // ����͂�����΃{�^���ԍ��𑝂₷
        else if (vertical < 0.0f)
        {
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

        // ���͒�~�t���O�����Ă�
        isStopInput = true;
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
