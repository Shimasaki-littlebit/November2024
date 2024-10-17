using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

// �����@Ray�̔���v���P


/// <summary>
/// ����u���b�N
/// </summary>
public class FragileBlock : MonoBehaviour
{
    /// <summary>
    /// ���C�p�Ԋu
    /// </summary>
    private float rayDistance = 0.05f;

    /// <summary>
    /// �������`�ʂ���Ă��邩
    /// </summary>
    private bool isDisplay = false;

    /// <summary>
    /// �v���C���[�̃��C���[�}�X�N
    /// </summary>
    private int playerLayerMask = 1 << 3;

    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    private void Start()
    {
        // �C���X�^���X�擾
        playerManager = PlayerManager.Instance;
    }

    // Update is called once per frame
    private void Update()
    {
        BreakBlock();
    }

    /// <summary>
    /// �u���b�N���󂷂��ǂ������肷��Ray
    /// </summary>
    private bool BreakBlockRay()
    {
        // ���C�̊J�n�n�_
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f + rayDistance);

        // ���C�̋���
        float distance = transform.localScale.x - rayDistance * 2.0f;

        Debug.DrawRay(startPos, Vector2.right * distance, Color.red);

        // ���C���΂��ē���������true��Ԃ�
        if (Physics2D.Raycast(startPos, Vector2.right, distance, playerLayerMask))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// �u���b�N���󂷏���
    /// </summary>
    private void BreakBlock()
    {
        // �`�ʂ���Ă��Ȃ���ΏI��
        if (!isDisplay) return;

        // �󂷔���Ray�ɓ������Ă���Ή�
        if(BreakBlockRay())
        {
            // �v���C���[�̏d�����d������Ȃ���ΏI��
            if (playerManager.GetWeight != Weight.HEAVY) return;

            Destroy(gameObject);
        }
    }

    /// <summary>
    /// ��ʂɉf�������̏���
    /// </summary>
    private void OnBecameVisible()
    {
        // �������J�n
        isDisplay = true;
    }
}
