using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �X�R�A�{�[�h�̃V�[���J��
/// </summary>
public class ScoreBoardSceneManager : MonoBehaviour
{
    // Update is called once per frame
    private void Update()
    {
        // A�{�^��orEnter�L�[���͂ŃV�[���ǂݍ���
        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.Return))
        {
            LoadScene();
        }
    }

    /// <summary>
    /// �V�[���J��
    /// </summary>
    private void LoadScene()
    {
        // �^�C�g���V�[����
        SceneManager.LoadScene("TitleScene");
    }
}
