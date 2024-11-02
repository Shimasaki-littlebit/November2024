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
    /// ���͒�~�p�^�C�}�[
    /// </summary>
    private Timer stopTimer;

    // Start is called before the first frame update
    private void Start()
    {
        // �^�C�}�[������
        stopTimer = new();

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
        stopTimer.Count(Time.deltaTime);
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

        // ������or�L�[�{�[�hSor�\���L�[�����͂�����΃{�^���ԍ��𑝂₷
        if (vertical < 0.0f || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // ���͒�~�J�n
            StartStopInput();

            // ����Ȃ�Ԃ�
            if (selectNum >= targetButtons.Length - 1) return;

            ++selectNum;

            // �摜�X�V
            DisplayImage();

            Debug.Log("��");
        }

        // �����or�L�[�{�[�hWor�\���L�[����͂�����΃{�^���ԍ��𑝂₷
        if (vertical > 0.0f || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // ���͒�~�J�n
            StartStopInput();

            // �����Ȃ�Ԃ�
            if (selectNum <= 0) return;

            --selectNum;

            // �摜�X�V
            DisplayImage();

            Debug.Log("��");
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
    /// ���͒�~�J�n
    /// </summary>
    private void StartStopInput()
    {
        // ���͒�~�t���O�����Ă�
        isStopInput = true;

        Debug.Log("���͒�~");

        // �^�C�}�[�Z�b�g
        stopTimer.SetTimer(stopInputTime, EndStopInput);
    }
    
    /// <summary>
    /// ���͒�~�I��
    /// </summary>
    private void EndStopInput()
    {
        isStopInput = false;

        Debug.Log("���͍ĊJ");
    }
}
