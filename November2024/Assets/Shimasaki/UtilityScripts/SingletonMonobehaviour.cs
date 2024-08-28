using UnityEngine;
using System;

/// <summary>
/// �V���O���g����MonoBehavior���p������ۂ̊��N���X
/// </summary>
/// <typeparam name="T">�N���X�e���v���[�g</typeparam>
public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    //�C���X�^���X
    private static T instance;

    public static T Instance
    {
        get
        {
            //�����C���X�^���X��null��������
            if (instance == null)
            {
                //���g�̌^���擾
                Type t = typeof(T);

                //�����^�����I�u�W�F�N�g��T���āA�C���X�^���X�o�^
                instance = (T)FindObjectOfType(t);

            }

            //�C���X�^���X��Ԃ�
            return instance;
        }
    }

    virtual protected void Awake()
    {
        //�����ɃA�^�b�`����ĂȂ������ׂ�
        CheckInstance();
    }

    /// <summary>
    /// ���̃Q�[���I�u�W�F�N�g�ɃA�^�b�`����Ă��邩����
    /// �A�^�b�`����Ă���ꍇ�͔j������B
    /// </summary>
    protected bool CheckInstance()
    {
        //�C���X�^���X��null(�������������̃N���X�������Ă����)
        if (instance == null)
        {
            //�C���X�^���X�̌^�����g�̌^�ɃL���X�g
            instance = this as T;

            return true;
        }
        else if (Instance == this)
        {
            return true;
        }

        //���ɃC���X�^���X�����������ꍇ�͎��g���폜����
        Destroy(this);

        return false;
    }


}
