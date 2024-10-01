using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NextStegeSensor : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�}�X�N
    /// </summary>
    private LayerMask playerMask = 1 << 3;
    
    /// <summary>
    /// �c�̒���
    /// </summary>
    private float height;

    /// <summary>
    /// �X�e�[�W�}�l�[�W���[
    /// </summary>
    private StageManager stageManager;

    /// <summary>
    /// �v���C���[�ɓ����������̊m�F
    /// </summary>
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        // �X�e�[�W�}�l�[�W���[�擾
        stageManager = StageManager.Instance;
        
        // �c�̕����擾
        height = stageManager.ArrayHeight * 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // �v���C���[���m
        if (!hit && Physics2D.Raycast(transform.position,
                             transform.right,
                             20.0f,
                             playerMask))
        {
            // ����������Ԃ�
            hit = true;
            // ���̃X�e�[�W�̍쐻
            NextStageCreate();
        }
    }

    /// <summary>
    /// ���̃X�e�[�W�쐻�ɕK�v�ȏ���n��
    /// </summary>
    private void NextStageCreate()
    {
        // �X�e�[�W�f�[�^�ƍ�����n��
        stageManager.NextStageGenetator(stageManager.Data, transform.position.y - height);
    }
}
