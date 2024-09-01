using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 縦に並んだ場合のボタン遷移
/// </summary>
public class VerticalUIControl : MonoBehaviour
{
    /// <summary>
    /// 選択時のボタン配列
    /// </summary>
    [SerializeField]
    private GameObject[] targetButtons;

    /// <summary>
    /// 選択ボタン番号
    /// </summary>
    private int selectNum = 0;

    /// <summary>
    /// 選んでいるボタン番号取得
    /// </summary>
    public int SelectNum
    {
        get => selectNum;
    }

    /// <summary>
    /// 入力停止フラグ
    /// </summary>
    private bool isStopInput = false;

    /// <summary>
    /// 入力停止時間
    /// </summary>
    private float stopInputTime = 0.2f;

    /// <summary>
    /// 入力停止計算用
    /// </summary>
    private float calTime = 0.0f;

    // Start is called before the first frame update
    private void Start()
    {
        // 初期表示
        DisplayImage();
    }

    // Update is called once per frame
    private void Update()
    {
        ButtonChange();
    }

    private void FixedUpdate()
    {
        if (isStopInput)
        {
            CalculationStopTime();
        }
    }

    /// <summary>
    /// ボタンの変更を検知
    /// </summary>
    private void ButtonChange()
    {
        // 入力停止中なら返す
        if (isStopInput) return;

        float vertical = 0.0f;

        // 左スティック縦入力を検知
        vertical = Input.GetAxisRaw("Vertical");

        // 下入力orキーボードS入力があればボタン番号を増やす
        if (vertical > 0.0f || Input.GetKey(KeyCode.S))
        {
            // 入力停止フラグを建てる
            isStopInput = true;

            // 下限なら返す
            if (selectNum <= 0) return;

            --selectNum;

            // 画像更新
            DisplayImage();
        }
        // 上入力orキーボードW入力があればボタン番号を増やす
        else if (vertical < 0.0f || Input.GetKey(KeyCode.W))
        {
            // 入力停止フラグを建てる
            isStopInput = true;

            // 上限なら返す
            if (selectNum >= targetButtons.Length - 1) return;

            ++selectNum;

            // 画像更新
            DisplayImage();
        }
    }

    /// <summary>
    /// 表示画像の更新
    /// </summary>
    private void DisplayImage()
    {
        int buttonNum = 0;

        // 全てのボタンを見て選択されているボタンの画像のみ表示する
        foreach (var button in targetButtons)
        {
            if (buttonNum == selectNum)
            {
                button.SetActive(true);
            }
            else
            {
                button.SetActive(false);
            }

            ++buttonNum;
        }
    }

    /// <summary>
    /// 入力停止中の時間計算
    /// </summary>
    private void CalculationStopTime()
    {
        calTime += Time.deltaTime;

        // 入力停止時間が終われば入力を受け付ける状態に
        if (calTime >= stopInputTime)
        {
            isStopInput = false;

            calTime = 0.0f;
        }
    }
}
