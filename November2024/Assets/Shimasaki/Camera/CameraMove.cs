using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// �J�����̓���
/// </summary>
public class CameraMove : SingletonMonoBehaviour<CameraMove>
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �J���������炷��
    /// </summary>
    [SerializeField]
    private float cameraShift;

    ///// <summary>
    ///// �ړ��p�^�C�}�[
    ///// </summary>
    //private Timer moveTimer;

    //private bool isMoveUp;

    //private bool isMoveDown;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        //// �^�C�}�[������
        //moveTimer = new();

        //isMoveUp = false;
        //isMoveDown = false;
    }

    private void FixedUpdate()
    {
        TrackingPlayer();

        //MoveUp();

        // �^�C�}�[�v�Z
        //moveTimer.Count(Time.deltaTime);
    }

    /// <summary>
    /// �v���C���[��ǔ�����
    /// </summary>
    private void TrackingPlayer()
    {
        Vector3 cameraPos = transform.position;

        // �v���C���[�̏d�������ăJ�����ʒu��ς���
        switch (playerManager.GetWeight)
        {
            // �y��
            case Weight.LIGHT:

                cameraPos.y = playerManager.Player.transform.position.y - cameraShift;

                break;

            // ����
            case Weight.NORMAL:

                cameraPos.y = playerManager.Player.transform.position.y;

                break;

            // �d��
            case Weight.HEAVY:

                cameraPos.y = playerManager.Player.transform.position.y + cameraShift;

                break;
        }

        // ���W���f
        transform.position = cameraPos;
    }

    //public void StartMoveUp()
    //{
    //    isMoveUp = true;

    //    moveTimer.SetTimer(0.5f, EndMoveUp);
    //}

    //private void EndMoveUp()
    //{
    //    isMoveUp = false;

    //    var pos = transform.localPosition;

    //    pos.y = Mathf.Round(pos.y);

    //    transform.localPosition = pos;
    //}

    //private void MoveUp()
    //{
    //    if (!isMoveUp) return;

    //    var cameraPos = transform.localPosition;

    //    cameraPos.y += cameraShift * Time.deltaTime * 2.0f;

    //    transform.localPosition = cameraPos;
    //}
}
