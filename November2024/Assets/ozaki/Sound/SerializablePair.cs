using System;
using UnityEngine;

/// <summary>
/// DictionaryをSerializeFieldで扱えるようにするためのジェネリッククラス
/// </summary>
/// <typeparam name="TKey">Dictionaryのkeyに相当</typeparam>
/// <typeparam name="TValue">Dictionaryのvalueに相当</typeparam>
[Serializable]
public class SerializablePair<TKey, TValue>
{
    /// <summary>
    /// 値を特定するためのキー
    /// Dictionaryのkeyに相当
    /// </summary>
    [SerializeField]
    TKey key;

    /// <summary>
    /// 実際の値
    /// Dictionaryのvalueに相当
    /// </summary>
    [SerializeField]
    TValue value;

    /// <summary>
    /// keyのプロパティ
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
    /// valueのプロパティ
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