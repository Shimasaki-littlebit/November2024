using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// �v���C���[�̏d����ύX����N���X
/// </summary>
public class PlayerChangeWeight : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �N�[���_�E���p�^�C�}�[
    /// </summary>
    private Timer coolTimer;

    /// <summary>
    /// �N�[���_�E������
    /// </summary>
    private float coolTime = 0.5f;

    /// <summary>
    /// �J�����ړ��X�N���v�g
    /// </summary>
    private CameraMove camera;

    /// <summary>
    /// �N�[���_�E������
    /// </summary>
    private bool isCoolDown;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // �^�C�}�[������
        coolTimer = new();

        // �N�[���_�E���t���O������
        isCoolDown = false;

        camera = CameraMove.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        AlterWeight();
    }

    private void FixedUpdate()
    {
        // �^�C�}�[�v�Z
        coolTimer.Count(Time.deltaTime);
    }

    /// <summary>
    /// �d���ύX
    /// </summary>
    private void AlterWeight()
    {
        // �N�[���_�E�����Ȃ�I��
        if (isCoolDown) return;

        // ���͂��Ȃ����A�������͂�����ΏI��
        if (LeftInput() && RightInput()) return;
        if (!LeftInput() && !RightInput()) return;

        // ���V�t�g
        if (LeftInput())
        {
            ShiftLeft();
        }

        // �E�V�t�g
        if (RightInput())
        {
            ShiftRight();
        }
    }

    /// <summary>
    /// RB,RT�̓��͔���
    /// </summary>
    /// <returns>true = ���͂���</returns>
    private bool RightInput()
    {
        if (Input.GetAxisRaw("RTrigger") > 0.0f) return true;
        if (Input.GetKeyDown("joystick button 5")) return true;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return true;

        return false;
    }

    /// <summary>
    /// LB,LT�̓��͔���
    /// </summary>
    /// <returns>true = ���͂���</returns>
    private bool LeftInput()
    {
        if (Input.GetAxisRaw("LTrigger") > 0.0f) return true;
        if (Input.GetKeyDown("joystick button 4")) return true;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return true;

        return false;
    }

    /// <summary>
    /// �d���E�V�t�g
    /// </summary>
    private void ShiftRight()
    {
        // ���ɏd����ΏI��
        if (playerManager.GetWeight >= Weight.HEAVY) return;

        // �E�ɃV�t�g
        playerManager.GetWeight++;

        StartCoolDown();
    }

    /// <summary>
    /// �d�����V�t�g
    /// </summary>
    private void ShiftLeft()
    {
        // ���Ɍy����ΏI��
        if (playerManager.GetWeight <= Weight.LIGHT) return;

        // ���ɃV�t�g
        playerManager.GetWeight--;

        //camera.StartMoveUp();

        StartCoolDown();
    }

    /// <summary>
    /// �N�[���_�E���J�n����
    /// </summary>
    private void StartCoolDown()
    {
        isCoolDown = true;

        // �^�C�}�[���Z�b�g
        coolTimer.SetTimer(coolTime, FinishCoolDown);
    }

    /// <summary>
    /// �N�[���_�E���I������
    /// </summary>
    private void FinishCoolDown()
    {
        isCoolDown = false;
    }
}
