using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��U�^�C�g���ֈړ�
/// </summary>
public class ResultSceneManager : MonoBehaviour
{
    /// <summary>
    /// �T�E���h�}�l�[�W���[
    /// </summary>
    private SoundPlayManager soundPlayManager;


    private void Start()
    {
        // �C���X�^���X�擾
        soundPlayManager = SoundPlayManager.Instance;

        // �^�C�g��BGM�Đ�
        soundPlayManager.TitlePlayBGM();

    }

        // Update is called once per frame
        private void Update()
    {
        // A�{�^��orEnter�L�[orA�L�[���͂ŃV�[���ǂݍ���
        if (Input.GetKeyDown("joystick button 0") ||
            Input.GetKeyDown(KeyCode.Return) ||
            Input.GetKeyDown(KeyCode.A))
        {
            LoadScene();
        }
    }

    /// <summary>
    /// �V�[���J��
    /// </summary>
    private void LoadScene()
    {
        // �X�R�A�{�[�h�V�[����
        SceneManager.LoadScene("ScoreBoardScene");
    }
}
