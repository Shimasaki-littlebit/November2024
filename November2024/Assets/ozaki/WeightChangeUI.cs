using PlayerWeight;
using UnityEngine;

public class WeightChangeUI : SingletonMonoBehaviour<WeightChangeUI>
{
    PlayerManager playerManager;

    /// <summary>
    /// �d��(����)UI���W
    /// </summary>
    [SerializeField]
    private RectTransform nomalPos;

    /// <summary>
    /// UI�؂�ւ��̈ړ����x
    /// </summary>
    [SerializeField]
    private float ShiftMoveSpeed;

    /// <summary>
    /// �^�񒆂̍��W
    /// </summary>
    [SerializeField]
    private RectTransform centerPos;

    /// <summary>
    /// ���Ɉړ������Ƃ��̍��W�擾�p
    /// </summary>
    [SerializeField]
    private RectTransform leftPos;

    /// <summary>
    /// �E�Ɉړ������Ƃ��̍��W�擾�p
    /// </summary>
    [SerializeField]
    private RectTransform rightPos;

    /// <summary>
    /// �ړI�n�̍��W
    /// </summary>
    private RectTransform goalShiftPos;

    /// <summary>
    /// ���ɓ���
    /// </summary>
    private bool isLeftMove;

    /// <summary>
    /// �E�ɓ���
    /// </summary>
    private bool isRightMove;

    private int nowWeight;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.Instance;

        // �ЂƂO�̏�Ԃ̎擾
        nowWeight = (int)playerManager.GetWeight;

        // �ړ����Ă��Ȃ���Ԃ�
        isLeftMove = false;
        isRightMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLeftMove)
        {
            LeftMove();
        }

        if (isRightMove)
        {
            RightMove();
        }

    }

    public void ShiftMove()
    {
        switch (playerManager.GetWeight)
        {
            // �m�[�}�����
            case Weight.NORMAL:
                // �S�[���n�_��^�񒆂�
                goalShiftPos = centerPos;
                // �O��̃X�e�[�^�X�����ďd����ΉE�֌y����΍��ֈړ�
                if (nowWeight > (int)playerManager.GetWeight)
                {
                    Debug.Log("�d�����畁��");
                    isRightMove = true;
                }
                else if (nowWeight < (int)playerManager.GetWeight)
                {
                    Debug.Log("�y�����畁��");
                    isLeftMove = true;
                }
                // �X�e�[�^�X���X�V
                nowWeight = (int)playerManager.GetWeight;
                break;
            case Weight.LIGHT:
                // �S�[���n�_���d����(���ʂ��d���Ɏ����Ă����ƌy�����^�񒆂ɗ���)
                Debug.Log("�E��");
                goalShiftPos = rightPos;
                isLeftMove = false;
                isRightMove = true;

                // �X�e�[�^�X���X�V
                nowWeight = (int)playerManager.GetWeight;
                break;
            case Weight.HEAVY:
                // �S�[���n�_���y����(���ʂ��y���Ɏ����Ă����Əd�����^�񒆂ɗ���)
                Debug.Log("����");

                goalShiftPos = leftPos;

                Debug.Log(goalShiftPos.localPosition.x);
                Debug.Log(nomalPos.localPosition.x);

                isRightMove = false;
                isLeftMove = true;
                // �X�e�[�^�X���X�V
                nowWeight = (int)playerManager.GetWeight;
                break;
        }
    }


    /// <summary>
    /// ���ֈړ�(���:�d��or����)
    /// </summary>
    private void LeftMove()
    {
        nomalPos.Translate(-ShiftMoveSpeed * Time.deltaTime, 0, 0);

        // �S�[���n�_�֒����ƈʒu�𒲐����ē������~�߂�
        if (goalShiftPos.localPosition.x >= nomalPos.localPosition.x)
        {

            Debug.Log("�X�g�b�v");
            nomalPos.localPosition = goalShiftPos.localPosition;

            isLeftMove = false;
        }
    }

    /// <summary>
    /// �E�ֈړ�(���:����or�y��)
    /// </summary>
    private void RightMove()
    {
        nomalPos.Translate(ShiftMoveSpeed * Time.deltaTime, 0, 0);

        // �S�[���n�_�֒����ƈʒu�𒲐����ē������~�߂�
        if (goalShiftPos.anchoredPosition.x <= nomalPos.anchoredPosition.x)
        {
            Debug.Log("�X�g�b�v");
            nomalPos.localPosition = goalShiftPos.localPosition;

            isRightMove = false;
        }
    }
}
