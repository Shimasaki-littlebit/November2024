using System;
using System.Collections.Generic;
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

    public enum MapChip
    {
        /// <summary>
        /// 空
        /// </summary>
        Empty,
        /// <summary>
        /// 壁
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
        //タイルマップ初期化する
        mapPos.ClearAllTiles();

        //ステージ配列の添え字最大値を取得
        arrayHeight = hoge.Height;
        arrayWidth = hoge.Width;

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
    /// 対応するオブジェクトを配置する
    /// </summary>
    /// <param name="chipCode">オブジェクト番号</param>
    /// <param name="hoge">ポジション</param>
    private void EntryWall(MapChip chipCode, Vector3 hoge, Vector2Int fuga)
    {
        //オブジェクト配置
        Instantiate(mapchip[(int)chipCode], hoge, Quaternion.identity);
    }
}
