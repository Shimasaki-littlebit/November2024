using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

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

    /// <summary>
    /// ���C�p�Ԋu
    /// </summary>
    private float rayDistance = 0.05f;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // ���x�ݒ�
        SetSpeed();
    }

    private void Update()
    {
        GroundRay();
    }

    private void FixedUpdate()
    {
        Fall();
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

    /// <summary>
    /// ���x�擾
    /// </summary>
    /// <returns>���x</returns>
    private float GetSpeed()
    {
        // �v���C���[�̏d���ŕ���
        switch (playerManager.GetWeight)
        {
            // �y��
            case Weight.LIGHT:

                return lightFallSpeed;

            // ����
            case Weight.NORMAL:

                return playerManager.NomalFallSpeed;

            // �d��
            case Weight.HEAVY:

                return heavyFallSpeed;

            default:

                return playerManager.NomalFallSpeed;
        }
    }

    /// <summary>
    /// ��������
    /// </summary>
    private void Fall()
    {
        // �����Ȃ���ΏI��
        if (!playerManager.IsMovable) return;
        if (playerManager.IsGround) return;

        Vector2 movePos = transform.position;

        // �������x�v�Z
        movePos.y -= GetSpeed() * Time.deltaTime;

        // ���W�ɔ��f
        transform.position = movePos;
    }

    /// <summary>
    /// �n�ʂ𔻒肷�郌�C
    /// </summary>
    private void GroundRay()
    {
        // ���C�̊J�n�n�_
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y - transform.localScale.y * 0.5f - rayDistance);

        // ���C�̋���
        float distance = transform.localScale.x - rayDistance * 2.0f;

        // ���C����
        Ray ray = new Ray(startPos, Vector2.right);

        Debug.DrawRay(startPos, Vector2.right * distance, Color.green);

        // ���C���΂��ē���������n�ʔ���
        if (Physics2D.Raycast(startPos, Vector2.right, distance))
        {
            if (!playerManager.IsGround)
            {
                playerManager.IsGround = true;
            }

            // ���W����
            transform.position = RoundPositionY();
        }

        // �������Ă��Ȃ���Βn�ʔ�����~�낷
        else
        {
            if (playerManager.IsGround)
            {
                playerManager.IsGround = false;
            }
        }
    }

    /// <summary>
    /// Y���W�̎l�̌ܓ��C��
    /// </summary>
    /// <returns>�C������W</returns>
    private Vector2 RoundPositionY()
    {
        Vector2 pos = transform.position;

        pos.y = Mathf.Round(pos.y);

        return pos;
    }
}
