using UnityEngine;
using UnityEngine.Tilemaps;

public class StageManager : SingletonMonoBehaviour<StageManager>
{
    [Tooltip("stageのデータの添え字最大値縦")]
    private int arrayHeight;

    /// <summary>
    /// stageのデータの添え字最大値縦取得
    /// </summary>
    public int ArrayHeight
    {
        get => arrayHeight;
        set => arrayHeight = value;
    }

    /// <summary>
    /// stageのデータの添え字最大値横
    /// </summary>
    private int arrayWidth;

    /// <summary>
    /// stageのデータの添え字最大値横取得
    /// </summary>
    public int ArrayWidth
    {
        get => arrayWidth;
        set => arrayWidth = value;
    }

    [SerializeField]
    [Tooltip("マップポジション")]
    private Tilemap mapPos;

    [SerializeField]
    [Tooltip("テストオブジェクト")]
    private GameObject[] mapchip;

    private StageData data;

    public StageData Data
    { get=>  data; set => data = value; }

    private StageData[] dataTable = new StageData[6];

    private float startPos = 0.0f;

    public enum MapChip
    {
        /// <summary>
        /// 空
        /// </summary>
        EMPTY,
        /// <summary>
        /// 壁
        /// </summary>
        WALL,
        /// <summary>
        /// センサー付き壁
        /// </summary>
        WALLSENSOR,
        /// <summary>
        /// 棘
        /// </summary>
        SPLINTER,
        /// <summary>
        /// 壊せるブロック
        /// </summary>
        FRAGILEBLOCK,
        /// <summary>
        /// 大砲(右向き)
        /// </summary>
        CANNONRIGHT,
        /// <summary>
        /// 大砲(左向き)
        /// </summary>
        CANNONLEFT,
        /// <summary>
        /// スコア加算用ブロック
        /// </summary>
        SCOREBROCK,
    }

    public enum Stage
    {
        /// <summary>
        /// ステージ01
        /// </summary>
        Stage1 = 1,
        /// <summary>
        /// ステージ02
        /// </summary>
        Stage2,
        /// <summary>
        /// ステージ03
        /// </summary>
        Stage3,
        /// <summary>
        /// ステージ04
        /// </summary>
        Stage4,
        /// <summary>
        /// ステージ05
        /// </summary>
        Stage5,
        /// <summary>
        /// ステージ06
        /// </summary>
        Stage6,
    }

    // Start is called before the first frame update
    void Start()
    {
        //data = JsonReader.LoadStage(Stage.Stage1.ToString());

        //StageGenerator(data);

        // jsonを配列に格納しておく
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

        //ステージ配列の添え字最大値を取得
        arrayHeight = hoge.Height;
        arrayWidth = hoge.Width;

        Debug.Log(arrayHeight);
        Debug.Log(arrayWidth);

        //左上から順番においていく
        for (int row = 0; row < hoge.Height; ++row)
        {
            for (int col = 0; col < hoge.Width; ++col)
            {
                //座標を取得と整えてる
                Vector3Int position = new(col, hoge.Height - row - 1);

                //一時配列なので座標足す
                var chip = (MapChip)hoge.MapChip[col + row * hoge.Width];

                switch (chip)
                {
                    case MapChip.EMPTY:
                        break;
                    case MapChip.WALL:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;
                    case MapChip.WALLSENSOR:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;
                }
            }
        }

        NextStage();
    }

    /// <summary>
    /// ステージ作成
    /// </summary>
    /// <param name="hoge">ステージのデータ番号</param>
    /// <param name="fuga">ステージ作成の高さ</param>
    public void NextStageGenetator(StageData hoge,float fuga)
    {
        Debug.Log(hoge);
        Debug.Log(fuga);
        //ステージ配列の添え字最大値を取得
        arrayHeight = hoge.Height;
        arrayWidth = hoge.Width;

        //左上から順番においていく
        for (int row = 0; row < hoge.Height; ++row)
        {
            for (int col = 0; col < hoge.Width; ++col)
            {
                //座標を取得と整えてる
                Vector3Int position = new(col, hoge.Height - (row + 1) + ((int)fuga - hoge.Height));

                //一時配列なので座標足す
                var chip = (MapChip)hoge.MapChip[col + (row * hoge.Width)];

                switch (chip)
                {
                    case MapChip.EMPTY:
                        break;
                    case MapChip.WALL:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;
                    case MapChip.WALLSENSOR:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;
                    case MapChip.SPLINTER:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;
                    case MapChip.FRAGILEBLOCK:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;
                    case MapChip.CANNONRIGHT:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;
                    case MapChip.CANNONLEFT:
                        EntryWall(chip, mapPos.GetCellCenterWorld(position));
                        break;

                }
            }
        }
        // 次のステージを決める
        NextStage();
    }

    /// <summary>
    /// 対応するオブジェクトを配置する
    /// </summary>
    /// <param name="chipCode">オブジェクト番号</param>
    /// <param name="hoge">ポジション</param>
    private void EntryWall(MapChip chipCode, Vector3 hoge)
    {
        //オブジェクト配置
        Instantiate(mapchip[(int)chipCode], new Vector3(hoge.x - 0.5f, hoge.y - 0.5f, hoge.z), Quaternion.identity);
    }

    /// <summary>
    /// 次のステージを決める
    /// </summary>
    private void NextStage()
    {
        // 次のステージ番号を決める
        var rnd = Random.Range(1, 7);

        Debug.Log(rnd);

        // データの設定
        data = dataTable[rnd - 1];
    }
}
