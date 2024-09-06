using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// jsonファイル読込保存
/// </summary>
public static class ScoreJsonReader
{
    [Tooltip("ファイルパス")]
    //static string path;

    /// <summary>
    /// データの読み込み
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="dataName"></param>
    public static T LoadData<T>(string dataName)
    {
        // パス指定
        string path = Application.dataPath + dataName + ".json";

        // ファイルを読み込めない時
        if (File.Exists(path) == false)
        {
            Save<T>(default,dataName,true);
        }

            return Load<T>(path);
    }

    /// <summary>
    /// ロード
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="path"></param>
    /// <returns></returns>
    private static T Load<T>(string loadPath)
    {
        // ファイル読み込み指定
        StreamReader rd = new StreamReader(loadPath);

        // ファイル内容読込
        string json = rd.ReadToEnd();

        // ファイルを閉じる
        rd.Close();

        // データを文字列として返す
        return JsonUtility.FromJson<T>(json);
    }

    /// <summary>
    /// セーブ
    /// </summary>
    /// <typeparam name="T">セーブするデータ型</typeparam>
    /// <param name="data">データ内容</param>
    /// <param name="dataName">データの名前</param>
    /// <param name="isNewData">true = 新規セーブ</param>
    public static void Save<T>(T data,string dataName,bool isNewData)
    {
        // パス指定
        string path = Application.dataPath + dataName + ".json";

        // データをjson式にして文字列に
        string json = JsonUtility.ToJson(data);

        // 上書き指定でStreamWriterを生成
        StreamWriter wr = new StreamWriter(path, isNewData);
        
        // 書き込み
        wr.WriteLine(json);

        // ファイルを閉じる
        wr.Close();
    }
}
