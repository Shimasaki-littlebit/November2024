using UnityEngine;

/// <summary>
/// �̗�UI�\��
/// </summary>
public class LifeUI : SingletonMonoBehaviour<LifeUI>
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �̗͕\���pUI
    /// </summary>
    [SerializeField]
    private GameObject[] lifeImages;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X���擾
        playerManager = PlayerManager.Instance;

        // ���C�t������
        foreach (GameObject lifeImage in lifeImages)
        {
            lifeImage.SetActive(true);
        }
    }

    /// <summary>
    /// ���C�t�\��
    /// </summary>
    public void DisplayLife()
    {
        // ���C�tUI�Y�����p
        int lifeUINum = 0;

        // ���C�tUI������
        foreach (var lifeImage in lifeImages)
        {
            // ���C�t�ɉ�����UI�\��
            if (lifeUINum < playerManager.HitPoint)
            {
                lifeImage.SetActive(true);
            }
            else
            {
                lifeImage.SetActive(false);
            }

            // �Y�����ԍ��𑝉�
            ++lifeUINum;
        }
    }
}
