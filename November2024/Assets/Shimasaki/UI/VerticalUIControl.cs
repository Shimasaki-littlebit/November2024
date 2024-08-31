using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 縦に並んだ場合のボタン遷移
/// </summary>
public class VerticalUIControl : MonoBehaviour
{
    [SerializeField]
    [Tooltip("選択されている時のボタン配列")]
    private GameObject[] targetButtons;

    [Tooltip("選んでいるボタンの番号")]
    private int selectNum = 0;

    /// <summary>
    /// 選んでいるボタン番号取得
    /// </summary>
    public int SelectNum
    {
        get => selectNum;
    }

    [Tooltip("入力を止めるフラグ")]
    private bool isStopInput = false;

    [Tooltip("入力を止める時間")]
    private float stopInputTime = 0.2f;

    [Tooltip("時間計算用")]
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

        // 左スティック縦入力を検知
        var vertical = Input.GetAxisRaw("Vertical");

        // 下入力があればボタン番号を増やす
        if (vertical > 0.0f)
        {
            // 下限なら返す
            if (selectNum <= 0) return;

            --selectNum;

            // 画像更新
            DisplayImage();

        }
        // 上入力があればボタン番号を増やす
        else if (vertical < 0.0f)
        {
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

        // 入力停止フラグを建てる
        isStopInput = true;
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
