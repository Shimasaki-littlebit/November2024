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

    public StageData Data
    { get=>  data; set => data = value; }

    private StageData[] dataTable = new StageData[6];

    private float startPos = 0.0f;

    public enum MapChip
    {
        /// <summary>
        /// ��
        /// </summary>
        EMPTY,
        /// <summary>
        /// ��
        /// </summary>
        WALL,
        /// <summary>
        /// �Z���T�[�t����
        /// </summary>
        WALLSENSOR,
    }

    public enum Stage
    {
        /// <summary>
        /// �X�e�[�W01
        /// </summary>
        Stage1 = 1,
        /// <summary>
        /// �X�e�[�W02
        /// </summary>
        Stage2,
        /// <summary>
        /// �X�e�[�W03
        /// </summary>
        Stage3,
        /// <summary>
        /// �X�e�[�W04
        /// </summary>
        Stage4,
        /// <summary>
        /// �X�e�[�W05
        /// </summary>
        Stage5,
        /// <summary>
        /// �X�e�[�W06
        /// </summary>
        Stage6,
    }

    // Start is called before the first frame update
    void Start()
    {
        //data = JsonReader.LoadStage(Stage.Stage1.ToString());

        //StageGenerator(data);

        // json��z��Ɋi�[���Ă���
        for (int i = (int)Stage.Stage1; i <= (int)Stage.Stage6; i++)
        {
            dataTable[i - 1] = (JsonReader.LoadStage("Stage" + i));

            data = dataTable[i - 1];
        }

        StageGenerator(data);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void StageGenerator(StageData hoge)
    {
        Debug.Log(hoge);

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
                    case MapChip.EMPTY:
                        break;
                    case MapChip.WALL:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position), new(col, hoge.Height - (row + 1)));
                        break;
                    case MapChip.WALLSENSOR:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position), new(col, hoge.Height - (row + 1)));
                        break;
                }
            }
        }

        NextStage();
    }

    public void NextStageGenetator(StageData hoge,float fuga)
    {
        Debug.Log(hoge);
        Debug.Log(fuga);
        //�X�e�[�W�z��̓Y�����ő�l���擾
        arrayHeight = hoge.Height;
        arrayWidth = hoge.Width;

        //���ォ�珇�Ԃɂ����Ă���
        for (int row = 0; row < hoge.Height; ++row)
        {
            for (int col = 0; col < hoge.Width; ++col)
            {
                //���W���擾�Ɛ����Ă�
                Vector3Int position = new(col, hoge.Height - (row + 1) + ((int)fuga - hoge.Height));

                //�ꎞ�z��Ȃ̂ō��W����
                var chip = (MapChip)hoge.MapChip[col + (row * hoge.Width)];

                switch (chip)
                {
                    case MapChip.EMPTY:
                        break;
                    case MapChip.WALL:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position), new(position.x, position.y));
                        break;
                    case MapChip.WALLSENSOR:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position), new(position.x, position.y));
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

    private void NextStage()
    {
        var rnd = Random.Range(1, 6);

        dataTable[rnd - 1] = (JsonReader.LoadStage("Stage" + rnd));

        data = dataTable[rnd - 1];
    }
}
