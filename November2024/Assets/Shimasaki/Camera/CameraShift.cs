using PlayerWeight;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �d���ɂ��J�����̈ʒu�ύX
/// </summary>
public class CameraShift : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �d�����̐؂�ւ����x
    /// </summary>
    private float heavyChangeSpeed = 0.05f;

    /// <summary>
    /// �y�����̐؂�ւ����x
    /// </summary>
    private float lightChangeSpeed = 0.01f;

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

    // Update is called once per frame
    private void Update()
    {
        Shift();
    }

    /// <summary>
    /// �J�����̈ʒu�ύX
    /// </summary>
    private void Shift()
    {
        // ���[�J�����W�擾
        var cameraPos = transform.localPosition;

        // �v���C���[�̏d�������ă��[�J�����W��ς���
        switch (playerManager.GetWeight)
        {
            // �y��
            case Weight.LIGHT:

                // �w��ʒu�܂ł������ƃJ���������炷
                if (cameraPos.y > -cameraShift)
                {
                    cameraPos.y -= lightChangeSpeed;
                }
                else
                {
                    if (cameraPos.y != -cameraShift)
                    {
                        cameraPos.y = Mathf.Round(cameraPos.y);
                    }
                }

                break;

            // ����
            case Weight.NORMAL:

                if (cameraPos.y > 0.0f)
                {
                    cameraPos = Vector3.MoveTowards(cameraPos, new Vector3(cameraPos.x, 0.0f, cameraPos.z), lightChangeSpeed);
                }
                else
                {
                    cameraPos = Vector3.MoveTowards(cameraPos, new Vector3(cameraPos.x, 0.0f, cameraPos.z), heavyChangeSpeed);
                }

                break;

            // �d��
            case Weight.HEAVY:

                // �w��ʒu�܂ł������ƃJ���������炷
                if (cameraPos.y < cameraShift)
                {
                    cameraPos.y += heavyChangeSpeed;
                }
                else
                {
                    if (cameraPos.y != cameraShift)
                    {
                        cameraPos.y = Mathf.Round(cameraPos.y);
                    }
                }

                break;
        }

        transform.localPosition = cameraPos;
    }
}
