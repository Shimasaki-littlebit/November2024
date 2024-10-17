using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̉��ȏ�
/// </summary>
public class PlayerHorizontalMove : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �����͒l
    /// </summary>
    private float horizontalValue;

    /// <summary>
    /// ���C�p�Ԋu
    /// </summary>
    private float rayDistance = 0.05f;

    /// <summary>
    /// �ǂ̃��C���[
    /// </summary>
    private int wallLayer = 1 << 6;

    // Start is called before the first frame update
    private void Start()
    {
        playerManager = PlayerManager.Instance;

        // �����͒l������
        horizontalValue = 0.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        // �����͊��m
        HorizontalInput();

        // ���E�̓����蔻�背�C
        RightRay();
        LeftRay();
    }

    private void FixedUpdate()
    {
        HorizontalMove();
    }

    /// <summary>
    /// ���̓��͌��m
    /// </summary>
    private void HorizontalInput()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");

        // �����L�[�{�[�h���͂�����Δ��f
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            horizontalValue = KeyInput();
        }
    }

    /// <summary>
    /// ���ړ�
    /// </summary>
    private void HorizontalMove()
    {
        // �ړ��ł��Ȃ���ΕԂ�
        if (!CheckMovable()) return;

        var playerPos = transform.position;

        // �ړ��v�Z
        playerPos.x += horizontalValue * playerManager.HorizontalSpeed * Time.deltaTime;

        // ���f
        transform.position = playerPos;
    }

    /// <summary>
    /// �ړ��\�����ׂ�
    /// </summary>
    /// <returns>true = �ړ��\</returns>
    private bool CheckMovable()
    {
        // �����Ȃ���ԂȂ�false
        if (!playerManager.IsMovable) return false;

        // �E�ǐڐG���ɉE���͂������false
        if (playerManager.IsRightWall)
        {
            if (horizontalValue > 0.0f) return false;
        }

        // ���ǐڐG���ɍ����͂������false
        if (playerManager.IsLeftWall)
        {
            if (horizontalValue < 0.0f) return false;
        }

        // ���v�Ȃ�true
        return true;
    }

    /// <summary>
    /// �E�ʂ̃��C
    /// </summary>
    private void RightRay()
    {
        // ���C�̊J�n�n�_
        Vector2 startPos = new(transform.position.x + transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f - rayDistance);

        // ���C�̋���
        float distance = transform.localScale.y - rayDistance * 2.0f;

        // ���C����
        Ray ray = new Ray(startPos, Vector2.down);

        Debug.DrawRay(startPos, Vector2.down * distance, Color.red);

        // ���C���΂��ē���������E�ǔ���
        if (Physics2D.Raycast(startPos, Vector2.down, distance,wallLayer))
        {
            if (!playerManager.IsRightWall)
            {
                playerManager.IsRightWall = true;
            }

            // ���W����
            transform.position = RoundPositionX();
        }

        // �����łȂ����͉E�ǔ��肵�Ȃ�
        else
        {
            if (playerManager.IsRightWall)
            {
                playerManager.IsRightWall = false;
            }
        }
    }

    /// <summary>
    /// ���ʂ̃��C
    /// </summary>
    private void LeftRay()
    {
        // ���C�̊J�n�n�_
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f - rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f - rayDistance);

        // ���C�̋���
        float distance = transform.localScale.y - rayDistance * 2.0f;

        // ���C����
        Ray ray = new Ray(startPos, Vector2.down);

        Debug.DrawRay(startPos, Vector2.down * distance, Color.red);

        // ���C���΂��ē��������獶�ǔ���
        if (Physics2D.Raycast(startPos, Vector2.down, distance, wallLayer))
        {
            if (!playerManager.IsLeftWall)
            {
                playerManager.IsLeftWall = true;
            }

            // ���W����
            transform.position = RoundPositionX();
        }

        // �����łȂ����͍��ǔ��肵�Ȃ�
        else
        {
            if (playerManager.IsLeftWall)
            {
                playerManager.IsLeftWall = false;
            }
        }
    }

    /// <summary>
    /// X���W�̎l�̌ܓ��C��
    /// (�ړ��̒l���傫���ꍇ�͂��蔲����)
    /// </summary>
    /// <returns>�C������W</returns>
    private Vector2 RoundPositionX()
    {
        Vector2 pos = transform.position;

        pos.x = Mathf.Round(pos.x);

        return pos;
    }

    /// <summary>
    /// �L�[���͂̐��l
    /// </summary>
    /// <returns>���E�̓��͒l</returns>
    private float KeyInput()
    {
        float result = 0.0f;

        // A���͂ō�����
        if (Input.GetKey(KeyCode.A))
        {
            result -= 1.0f;
        }

        // D���͂ŉE����
        if (Input.GetKey(KeyCode.D))
        {
            result += 1.0f;
        }

        return result;
    }
}
