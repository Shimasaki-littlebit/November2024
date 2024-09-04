using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// �J�����̓���
/// </summary>
public class CameraMove : MonoBehaviour
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

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;
    }

    private void FixedUpdate()
    {
        TrackingPlayer();
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
}
