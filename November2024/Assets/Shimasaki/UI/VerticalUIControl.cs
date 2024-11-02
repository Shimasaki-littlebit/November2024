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
    /// 入力停止用タイマー
    /// </summary>
    private Timer stopTimer;

    // Start is called before the first frame update
    private void Start()
    {
        // タイマー初期化
        stopTimer = new();

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
        stopTimer.Count(Time.deltaTime);
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

        // 下入力orキーボードSor十字キー下入力があればボタン番号を増やす
        if (vertical < 0.0f || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // 入力停止開始
            StartStopInput();

            // 上限なら返す
            if (selectNum >= targetButtons.Length - 1) return;

            ++selectNum;

            // 画像更新
            DisplayImage();

            Debug.Log("上");
        }

        // 上入力orキーボードWor十字キー上入力があればボタン番号を増やす
        if (vertical > 0.0f || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // 入力停止開始
            StartStopInput();

            // 下限なら返す
            if (selectNum <= 0) return;

            --selectNum;

            // 画像更新
            DisplayImage();

            Debug.Log("下");
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
    /// 入力停止開始
    /// </summary>
    private void StartStopInput()
    {
        // 入力停止フラグを建てる
        isStopInput = true;

        Debug.Log("入力停止");

        // タイマーセット
        stopTimer.SetTimer(stopInputTime, EndStopInput);
    }
    
    /// <summary>
    /// 入力停止終了
    /// </summary>
    private void EndStopInput()
    {
        isStopInput = false;

        Debug.Log("入力再開");
    }
}
