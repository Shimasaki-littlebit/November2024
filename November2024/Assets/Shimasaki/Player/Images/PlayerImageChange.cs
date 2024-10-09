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

    /// <summary>
    /// �����ڂ̃Z�b�g
    /// </summary>
    public void SetPlayerImage()
    {
        // �d�ʂ����ĕ���
        switch(playerManager.GetWeight)
        {
            // �y��
            case Weight.LIGHT:

                // �摜�؂�ւ�
                spriteRenderer.sprite = playerManager.LightImage;

                // �v���y���\��
                playerManager.LightPropeller.SetActive(true);

                break;

            // ����
            case Weight.NORMAL:

                // �摜�؂�ւ�
                spriteRenderer.sprite = playerManager.NormalImage;

                // �e�d���n���\��
                playerManager.LightPropeller.SetActive(false);
                playerManager.HeavyWeapon.SetActive(false);

                break;

            // �d��
            case Weight.HEAVY:

                // �摜�؂�ւ�
                spriteRenderer.sprite = playerManager.HeavyImage;

                // �d������\��
                playerManager.HeavyWeapon.SetActive(true);

                break;
        }
    }
}
