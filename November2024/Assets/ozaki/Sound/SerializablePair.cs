using System;
using UnityEngine;

/// <summary>
/// Dictionary��SerializeField�ň�����悤�ɂ��邽�߂̃W�F�l���b�N�N���X
/// </summary>
/// <typeparam name="TKey">Dictionary��key�ɑ���</typeparam>
/// <typeparam name="TValue">Dictionary��value�ɑ���</typeparam>
[Serializable]
public class SerializablePair<TKey, TValue>
{
    /// <summary>
    /// �l����肷�邽�߂̃L�[
    /// Dictionary��key�ɑ���
    /// </summary>
    [SerializeField]
    TKey key;

    /// <summary>
    /// ���ۂ̒l
    /// Dictionary��value�ɑ���
    /// </summary>
    [SerializeField]
    TValue value;

    /// <summary>
    /// key�̃v���p�e�B
    /// </summary>
    public TKey Key
    {
        get
        {
            return key;
        }
        set
        {
            {
                key = value;
            }
        }
    }

    /// <summary>
    /// value�̃v���p�e�B
    /// </summary>
    public TValue Value
    {
        get
        {
            return value;
        }
        set
        {
            this.value = value;
        }
    }
}