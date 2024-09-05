using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̏d�����̕���
/// </summary>
public class PlayerHeavyWeapon : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    PlayerManager playerManager;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;
    }

    /// <summary>
    /// �d����\��
    /// </summary>
    public void ShowHeavyWeapon()
    {
        // ��\���Ȃ�\����
        if(!playerManager.HeavyWeapon.activeSelf)
        {
            playerManager.HeavyWeapon.SetActive(true);
        }
    }

    /// <summary>
    /// �d�����\��
    /// </summary>
    public void HideHeavyWeapon()
    {
        // �\�����Ȃ��\����
        if (playerManager.HeavyWeapon.activeSelf)
        {
            playerManager.HeavyWeapon.SetActive(false);
        }
    }
}
