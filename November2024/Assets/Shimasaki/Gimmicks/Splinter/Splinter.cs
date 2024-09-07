using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;


/// <summary>
/// ���̏���
/// </summary>
public class Splinter : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �v���C���[�̃_���[�W�X�N���v�g
    /// </summary>
    private PlayerDamage damage;

    /// <summary>
    /// �^�����b�_���[�W
    /// </summary>
    [SerializeField]
    private int damageValue;

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

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;

        // �_���[�W�X�N���v�g�擾
        damage = playerManager.Player.GetComponent<PlayerDamage>();
    }

    // Update is called once per frame
    private void Update()
    {
        SplinterDamage();
    }

    /// <summary>
    /// ���̃_���[�W���菈��
    /// </summary>
    private void SplinterDamage()
    {
        // �������`�ʂ���Ă��Ȃ���ΏI��
        if (!isDisplay) return;

        // �v���C���[�ɓ������Ă����
        if(SplinterRay())
        {
            // �v���C���[�Ƀ_���[�W��^����
            damage.TakeDamage(DamageCalculation());
        }
    }

    /// <summary>
    /// ���̓����蔻��Ray
    /// </summary>
    /// <returns>true = �������Ă���</returns>
    private bool SplinterRay()
    {
        // ���C�̊J�n�n�_
        Vector2 startPos = new(transform.position.x - transform.localScale.x * 0.5f + rayDistance,
                               transform.position.y + transform.localScale.y * 0.5f + rayDistance);

        // ���C�̋���
        float distance = transform.localScale.x - rayDistance * 2.0f;

        // ���C����
        Ray ray = new Ray(startPos, Vector2.right);

        Debug.DrawRay(startPos, Vector2.right * distance, Color.red);

        // ���C���΂��ē���������true��Ԃ�
        if (Physics2D.Raycast(startPos, Vector2.right, distance,playerLayerMask))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// �_���[�W�l���v�Z
    /// </summary>
    /// <returns></returns>
    private int DamageCalculation()
    {
        if(playerManager.GetWeight == Weight.HEAVY)
        {
            return damageValue << 1;
        }

        return damageValue;
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
