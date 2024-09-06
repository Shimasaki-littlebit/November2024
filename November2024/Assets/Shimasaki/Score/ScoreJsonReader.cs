using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// json�t�@�C���Ǎ��ۑ�
/// </summary>
public static class ScoreJsonReader
{
    [Tooltip("�t�@�C���p�X")]
    //static string path;

    /// <summary>
    /// �f�[�^�̓ǂݍ���
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataName"></param>
    public static T LoadData<T>(string dataName)
    {
        // �p�X�w��
        string path = Application.dataPath + dataName + ".json";

        // �t�@�C����ǂݍ��߂Ȃ���
        if (File.Exists(path) == false)
        {
            Save<T>(default,dataName,true);
        }

            return Load<T>(path);
    }

    /// <summary>
    /// ���[�h
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    private static T Load<T>(string loadPath)
    {
        // �t�@�C���ǂݍ��ݎw��
        StreamReader rd = new StreamReader(loadPath);

        // �t�@�C�����e�Ǎ�
        string json = rd.ReadToEnd();

        // �t�@�C�������
        rd.Close();

        // �f�[�^�𕶎���Ƃ��ĕԂ�
        return JsonUtility.FromJson<T>(json);
    }

    /// <summary>
    /// �Z�[�u
    /// </summary>
    /// <typeparam name="T">�Z�[�u����f�[�^�^</typeparam>
    /// <param name="data">�f�[�^���e</param>
    /// <param name="dataName">�f�[�^�̖��O</param>
    /// <param name="isNewData">true = �V�K�Z�[�u</param>
    public static void Save<T>(T data,string dataName,bool isNewData)
    {
        // �p�X�w��
        string path = Application.dataPath + dataName + ".json";

        // �f�[�^��json���ɂ��ĕ������
        string json = JsonUtility.ToJson(data);

        // �㏑���w���StreamWriter�𐶐�
        StreamWriter wr = new StreamWriter(path, isNewData);
        
        // ��������
        wr.WriteLine(json);

        // �t�@�C�������
        wr.Close();
    }
}
