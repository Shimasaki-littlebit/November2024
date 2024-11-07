using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �^�C�g���̃V�[���J��
/// </summary>
public class TitleSceneManager : MonoBehaviour
{
    /// <summary>
    /// �c�̃{�^���ړ�
    /// </summary>
    private VerticalUIControl vUIControl;

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

        // �{�^���ړ��擾
        vUIControl = GetComponent<VerticalUIControl>();
    }

    // Update is called once per frame
    private void Update()
    {
        // A�{�^��orEnter�L�[orA�L�[���͂ŃV�[���ǂݍ���
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.A))
        {
            LoadScene();
        }
    }

    /// <summary>
    /// �V�[���ǂݍ���
    /// </summary>
    private void LoadScene()
    {
        switch (vUIControl.SelectNum)
        {
            // ���C���V�[����
            case 0:

                SceneManager.LoadScene("MainScene");

                break;

            // �X�R�A�{�[�h��
            case 1:

                SceneManager.LoadScene("ScoreBoardScene");

                break;

            // �N���W�b�g��
            case 2:

                SceneManager.LoadScene("CreditScene");

                break;

            // �Q�[���I��
            case 3:

#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();
#endif

                break;
        }
    }
}
