using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̏c�ړ�
/// </summary>
public class PlayerVerticalMove : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �y�����x
    /// </summary>
    private float lightFallSpeed;

    /// <summary>
    /// �d�����x
    /// </summary>
    private float heavyFallSpeed;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // ���x�ݒ�
        SetSpeed();
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// �d���y�����̑��x�ݒ�
    /// </summary>
    private void SetSpeed()
    {
        // �y����Ԃ̑��x�ݒ�
        lightFallSpeed = playerManager.NomalFallSpeed * playerManager.LightMagnification;

        // �d����Ԃ̑��x�ݒ�
        heavyFallSpeed = playerManager.NomalFallSpeed * playerManager.HeavyMagnification;
    }
}
