using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStageManager : MonoBehaviour
{
    /// <summary>
    /// �T�E���h�}�l�[�W���[
    /// </summary>
    private SoundPlayManager soundPlayManager;

    // Start is called before the first frame update
    private void Start()
    {
        // �C���X�^���X�擾
        soundPlayManager = SoundPlayManager.Instance;

        // �Q�[��BGM�Đ�
        soundPlayManager.GamePlayBGM();
    }
}
