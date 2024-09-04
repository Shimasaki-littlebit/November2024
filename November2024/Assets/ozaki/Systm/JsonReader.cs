using System.IO;
using UnityEngine;

/// <summary>
/// .json����e��f�[�^���擾����֐����܂Ƃ߂��N���X
/// </summary>
public static class JsonReader
{
    /// <summary>
    /// �w�肳�ꂽ�X�e�[�W����json����Ăяo���֐�
    /// </summary>
    /// <param name="stageName">���[�h�������X�e�[�W��</param>
    /// <returns>���[�h�����X�e�[�W�̃f�[�^</returns>
    public static StageData LoadStage(string stageName)
    {
        StreamReader rd;
        //�p�X�w��
        string path = Application.dataPath + SummarizeResourceDirectory.STAGE_DATA_PATH_TEMPLATE + stageName + ".json";

        //�p�X����f�[�^�������ė���邩���m�F����
        try
        {
            rd = new(path);
        }
        catch (FileNotFoundException e)
        {
            //�������݂��Ȃ��p�X�Ȃ烍�O�ɏ����ďI��
            Debug.LogError($"�t�@�C����{e.FileName}��������܂���ł���");
            return default;
        }

        string json = rd.ReadToEnd();
        rd.Close();

        return JsonUtility.FromJson<StageData>(json);
    }

    /// <summary>
    /// �P�̂̃p�����[�^��ǂݍ��ފ֐�
    /// </summary>
    /// <typeparam name="T">�ǂݍ��݂����f�[�^�^</typeparam>
    /// <param name="path">�t�@�C���p�X</param>
    public static T LoadMonoParameterFromJson<T>(string path)
    {
        StreamReader rd;

        //�p�X����f�[�^�������ė���邩���m�F����
        try
        {
            rd = new(path);
        }
        catch (FileNotFoundException e)
        {
            //�������݂��Ȃ��p�X�Ȃ烍�O�ɏ����ďI��
            Debug.LogError($"�t�@�C����{e.FileName}��������܂���ł���");
            return default;
        }

        string json = rd.ReadToEnd();

        rd.Close();

        return JsonUtility.FromJson<T>(json);
    }

    /// <summary>
    /// �p�����[�^�e�[�u����ǂݍ��ފ֐�
    /// </summary>
    /// <typeparam name="T">�ǂݍ��݂����f�[�^�^</typeparam>
    /// <param name="path">�t�@�C���p�X</param>
    public static T LoadParameterTableFromJson<T>(string path)
    {
        string fileData = "";

        try
        {
            fileData = File.ReadAllText(path);
        }
        catch (FileNotFoundException e)
        {
            //�������݂��Ȃ��p�X�Ȃ烍�O�ɏ����ďI��
            Debug.LogError($"�t�@�C����{e.FileName}��������܂���ł���");
            return default;
        }

        T table = JsonUtility.FromJson<T>(fileData);

        return table;
    }
}