using UnityEngine;

/// <summary>
/// �J�����̓���
/// </summary>
public class CameraMove : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�l�[�W���[
    /// </summary>
    private PlayerManager playerManager;

    // Start is called before the first frame update
    private void Start()
    {
        // �v���C���[�}�l�[�W���[�擾
        playerManager = PlayerManager.Instance;
    }

    private void Update()
    {
        TrackingPlayer();
    }

    /// <summary>
    /// �v���C���[��ǔ�����
    /// </summary>
    private void TrackingPlayer()
    {
        Vector3 cameraPos = transform.position;

        cameraPos.y = playerManager.Player.transform.position.y -1.5f;

        // ���W���f
        transform.position = cameraPos;
    }
}
