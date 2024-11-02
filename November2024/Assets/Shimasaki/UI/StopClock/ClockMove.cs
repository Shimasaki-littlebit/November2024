using UnityEngine;

/// <summary>
/// �v���C���[������~�����Ԑ����^�C�}�[UI�̓���
/// </summary>
public class ClockMove : MonoBehaviour
{
    /// <summary>
    /// �I�t�Z�b�g
    /// </summary>
    [SerializeField]
    private Vector3 offset;

    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// �v���C���[�̃g�����X�t�H�[��
    /// </summary>
    private Transform playerTransform;

    /// <summary>
    /// �^�C�}�[�\���̃g�����X�t�H�[��
    /// </summary>
    [SerializeField]
    private Transform clockTransform;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        playerManager = PlayerManager.Instance;

        // �v���C���[�̃g�����X�t�H�[���擾
        playerTransform = playerManager.Player.transform;
    }

    private void FixedUpdate()
    {
        // �^�C�}�[�̈ʒu���v���C���[+�I�t�Z�b�g�̈ʒu�ɒ�����������
        clockTransform.position = RectTransformUtility.
            WorldToScreenPoint(Camera.main,playerTransform.position + offset);
    }
}
