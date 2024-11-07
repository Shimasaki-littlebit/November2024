using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

/// <summary>
/// �\�ߓo�^�������ʉ�����w�肳�ꂽ���ʉ����Đ�����N���X
/// ���ʉ��͔C�ӂ̗񋓎q�Ō����ł���
/// </summary>
//[RequireComponent(typeof(AudioSource))]
public class SoundPlayManager : SingletonMonoBehaviour<SoundPlayManager>
{
    /// <summary>
    /// ���ʉ��̎��
    /// </summary>
    public enum SEKey
    {
        /// <summary>
        /// �u���b�N�j��
        /// </summary>
        SE_BREAK,
        /// <summary>
        /// �I��
        /// </summary>
        SE_CHOISE,
        /// <summary>
        /// ��_��
        /// </summary>
        SE_DAMAGE,
    }

    /// <summary>
    /// ���ʉ��ƑΉ�����L�[�̃��X�g
    /// </summary>
    [SerializeField]
    List<SerializablePair<SEKey, AudioClip>> SEList;

    [SerializeField]
    AudioClip titleBGM;

    [SerializeField]
    AudioClip gameBGM;

    /// <summary>
    /// soundEffectList��Dictionary����������
    /// Dictionary��Serialize�ł��Ȃ�����SerializablePair�̃��X�g��Dictionary�ɕϊ����Ĉ���
    /// </summary>
    Dictionary<SEKey, AudioClip> SEListBody = new Dictionary<SEKey, AudioClip>();

    /// <summary>
    /// SE�I�[�f�B�I�\�[�X
    /// </summary>
    [SerializeField]
    AudioSource seAudioSource;

    /// <summary>
    /// �^�C�g��BGM�I�[�f�B�I�\�[�X
    /// </summary>
    [SerializeField]
    AudioSource titleBGMAudioSource;

    /// <summary>
    /// �Q�[��BGM�I�[�f�B�I�\�[�X
    /// </summary>
    [SerializeField]
    AudioSource gameBGMAudioSource;

    void Start()
    {
        // soundEffectList��Dictionary�ɕϊ�
        SEListBody = SEList.ToDictionary(key => key.Key, value => value.Value);
    }

    /// <summary>
    /// �w�肳�ꂽ�L�[�̌��ʉ����Đ�����
    /// </summary>
    /// <param name="_key"></param>
    public void PlaySE(SEKey key)
    {
        // �L�[�����X�g�ɑ��݂��Ȃ��ꍇ�͉������Ȃ�
        if(SEListBody.ContainsKey(key) == false)
        {
            return;
        }

        // �w�肳�ꂽ�L�[�̌��ʉ����Đ�
        seAudioSource.PlayOneShot(SEListBody[key]);
    }

    public void TitlePlayBGM()
    {
        // �w�肳�ꂽ�L�[�̌��ʉ����Đ�
       titleBGMAudioSource.clip = titleBGM;
       titleBGMAudioSource.Play();
    }

    public void GamePlayBGM()
    {
        // �w�肳�ꂽ�L�[�̌��ʉ����Đ�
        titleBGMAudioSource.clip = gameBGM;
        titleBGMAudioSource.Play();
    }
}
