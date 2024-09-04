using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    [Tooltip("stage�̃f�[�^�̓Y�����ő�l�c")]
    private int arrayHeight;

    /// <summary>
    /// stage�̃f�[�^�̓Y�����ő�l�c�擾
    /// </summary>
    public int ArrayHeight
    {
        get => arrayHeight;
        set => arrayHeight = value;
    }

    /// <summary>
    /// stage�̃f�[�^�̓Y�����ő�l��
    /// </summary>
    private int arrayWidth;

    /// <summary>
    /// stage�̃f�[�^�̓Y�����ő�l���擾
    /// </summary>
    public int ArrayWidth
    {
        get => arrayWidth;
        set => arrayWidth = value;
    }

    [SerializeField]
    [Tooltip("�}�b�v�|�W�V����")]
    private Tilemap mapPos;

    [SerializeField]
    [Tooltip("�e�X�g�I�u�W�F�N�g")]
    private GameObject[] mapchip;

    private StageData data;

    public enum MapChip
    {
        /// <summary>
        /// ��
        /// </summary>
        Empty,
        /// <summary>
        /// ��
        /// </summary>
        Wall,
    }

    // Start is called before the first frame update
    void Start()
    {
        data = JsonReader.LoadStage("Sumple");

        StageGenerator(data);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StageGenerator(StageData hoge)
    {
        //�^�C���}�b�v����������
        mapPos.ClearAllTiles();

        //�X�e�[�W�z��̓Y�����ő�l���擾
        arrayHeight = hoge.Height;
        arrayWidth = hoge.Width;

        //���ォ�珇�Ԃɂ����Ă���
        for (int row = 0; row < hoge.Height; ++row)
        {
            for (int col = 0; col < hoge.Width; ++col)
            {
                //���W���擾�Ɛ����Ă�
                Vector3Int position = new(col, hoge.Height - row - 1);

                //�ꎞ�z��Ȃ̂ō��W����
                var chip = (MapChip)hoge.MapChip[col + row * hoge.Width];

                switch (chip)
                {
                    case MapChip.Empty:
                        break;
                    case MapChip.Wall:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position), new(col, hoge.Height - (row + 1)));
                        break;
                }


            }
        }
    }

    /// <summary>
    /// �Ή�����I�u�W�F�N�g��z�u����
    /// </summary>
    /// <param name="chipCode">�I�u�W�F�N�g�ԍ�</param>
    /// <param name="hoge">�|�W�V����</param>
    private void EntryWall(MapChip chipCode, Vector3 hoge, Vector2Int fuga)
    {
        //�I�u�W�F�N�g�z�u
        Instantiate(mapchip[(int)chipCode], hoge, Quaternion.identity);
    }
}
