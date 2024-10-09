using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerWeight;

/// <summary>
/// �v���C���[�̉摜�ύX
/// </summary>
public class PlayerImageChange : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �v���C���[�̌����ڃX�v���C�g�����_���[
    /// </summary>
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        playerManager = PlayerManager.Instance;

        spriteRenderer = playerManager.PlayerImage.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// �����ڂ̃Z�b�g
    /// </summary>
    private void SetPlayerImage()
    {
        // �d�ʂ����ĕ���
        switch(playerManager.GetWeight)
        {
            // �y��
            case Weight.LIGHT:

                spriteRenderer.sprite = playerManager.LightImage;

                break;

            // ����
            case Weight.NORMAL:

                spriteRenderer.sprite = playerManager.NormalImage;

                break;

            // �d��
            case Weight.HEAVY:

                spriteRenderer.sprite = playerManager.HeavyImage;

                break;
        }
    }
}
