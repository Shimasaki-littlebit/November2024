using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// ��U�^�C�g���ֈړ�
/// </summary>
public class ResultSceneManager : MonoBehaviour
{
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
        // �^�C�g���V�[����
        SceneManager.LoadScene("TitleScene");
    }
}
