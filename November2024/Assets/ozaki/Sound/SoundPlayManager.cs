using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// 予め登録した効果音から指定された効果音を再生するクラス
/// 効果音は任意の列挙子で検索できる
/// </summary>
//[RequireComponent(typeof(AudioSource))]
public class SoundPlayManager : SingletonMonoBehaviour<SoundPlayManager>
{
    /// <summary>
    /// 効果音の種類
    /// </summary>
    public enum SEKey
    {
        /// <summary>
        /// ブロック破壊
        /// </summary>
        SE_BREAK,
        /// <summary>
        /// 選択
        /// </summary>
        SE_CHOISE,
        /// <summary>
        /// 被ダメ
        /// </summary>
        SE_DAMAGE,
    }

    /// <summary>
    /// 効果音と対応するキーのリスト
    /// </summary>
    [SerializeField]
    List<SerializablePair<SEKey, AudioClip>> SEList;

    [SerializeField]
    AudioClip titleBGM;

    [SerializeField]
    AudioClip gameBGM;

    /// <summary>
    /// soundEffectListをDictionary化したもの
    /// DictionaryはSerializeできないためSerializablePairのリストをDictionaryに変換して扱う
    /// </summary>
    Dictionary<SEKey, AudioClip> SEListBody = new Dictionary<SEKey, AudioClip>();

    /// <summary>
    /// SEオーディオソース
    /// </summary>
    [SerializeField]
    AudioSource seAudioSource;

    /// <summary>
    /// タイトルBGMオーディオソース
    /// </summary>
    [SerializeField]
    AudioSource titleBGMAudioSource;

    /// <summary>
    /// ゲームBGMオーディオソース
    /// </summary>
    [SerializeField]
    AudioSource gameBGMAudioSource;

    void Start()
    {
        // soundEffectListをDictionaryに変換
        SEListBody = SEList.ToDictionary(key => key.Key, value => value.Value);
    }

    /// <summary>
    /// 指定されたキーの効果音を再生する
    /// </summary>
    /// <param name="_key"></param>
    public void PlaySE(SEKey key)
    {
        // キーがリストに存在しない場合は何もしない
        if(SEListBody.ContainsKey(key) == false)
        {
            return;
        }

        // 指定されたキーの効果音を再生
        seAudioSource.PlayOneShot(SEListBody[key]);
    }

    public void TitlePlayBGM()
    {
        // 指定されたキーの効果音を再生
       titleBGMAudioSource.clip = titleBGM;
       titleBGMAudioSource.Play();
    }

    public void GamePlayBGM()
    {
        // 指定されたキーの効果音を再生
        titleBGMAudioSource.clip = gameBGM;
        titleBGMAudioSource.Play();
    }
}
