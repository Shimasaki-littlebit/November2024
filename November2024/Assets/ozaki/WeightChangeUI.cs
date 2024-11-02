using PlayerWeight;
using UnityEngine;

public class WeightChangeUI : SingletonMonoBehaviour<WeightChangeUI>
{
    PlayerManager playerManager;

    /// <summary>
    /// 重さ(普通)UI座標
    /// </summary>
    [SerializeField]
    private RectTransform nomalPos;

    /// <summary>
    /// UI切り替えの移動速度
    /// </summary>
    [SerializeField]
    private float ShiftMoveSpeed;

    /// <summary>
    /// 真ん中の座標
    /// </summary>
    [SerializeField]
    private RectTransform centerPos;

    /// <summary>
    /// 左に移動したときの座標取得用
    /// </summary>
    [SerializeField]
    private RectTransform leftPos;

    /// <summary>
    /// 右に移動したときの座標取得用
    /// </summary>
    [SerializeField]
    private RectTransform rightPos;

    /// <summary>
    /// 目的地の座標
    /// </summary>
    private RectTransform goalShiftPos;

    /// <summary>
    /// 左に動く
    /// </summary>
    private bool isLeftMove;

    /// <summary>
    /// 右に動く
    /// </summary>
    private bool isRightMove;

    private int nowWeight;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.Instance;

        // ひとつ前の状態の取得
        nowWeight = (int)playerManager.GetWeight;

        // 移動していない状態に
        isLeftMove = false;
        isRightMove = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isLeftMove)
        {
            LeftMove();
        }

        if (isRightMove)
        {
            RightMove();
        }

    }

    public void ShiftMove()
    {
        switch (playerManager.GetWeight)
        {
            // ノーマル状態
            case Weight.NORMAL:
                // ゴール地点を真ん中に
                goalShiftPos = centerPos;
                // 前回のステータスを見て重ければ右へ軽ければ左へ移動
                if (nowWeight > (int)playerManager.GetWeight)
                {
                    Debug.Log("重いから普通");
                    isRightMove = true;
                }
                else if (nowWeight < (int)playerManager.GetWeight)
                {
                    Debug.Log("軽いから普通");
                    isLeftMove = true;
                }
                // ステータスを更新
                nowWeight = (int)playerManager.GetWeight;
                break;
            case Weight.LIGHT:
                // ゴール地点を重いへ(普通を重いに持っていくと軽いか真ん中に来る)
                Debug.Log("右へ");
                goalShiftPos = rightPos;
                isLeftMove = false;
                isRightMove = true;

                // ステータスを更新
                nowWeight = (int)playerManager.GetWeight;
                break;
            case Weight.HEAVY:
                // ゴール地点を軽いへ(普通を軽いに持っていくと重いか真ん中に来る)
                Debug.Log("左へ");

                goalShiftPos = leftPos;

                Debug.Log(goalShiftPos.localPosition.x);
                Debug.Log(nomalPos.localPosition.x);

                isRightMove = false;
                isLeftMove = true;
                // ステータスを更新
                nowWeight = (int)playerManager.GetWeight;
                break;
        }
    }


    /// <summary>
    /// 左へ移動(状態:重いor普通)
    /// </summary>
    private void LeftMove()
    {
        nomalPos.Translate(-ShiftMoveSpeed * Time.deltaTime, 0, 0);

        // ゴール地点へ着くと位置を調整して動きを止める
        if (goalShiftPos.localPosition.x >= nomalPos.localPosition.x)
        {

            Debug.Log("ストップ");
            nomalPos.localPosition = goalShiftPos.localPosition;

            isLeftMove = false;
        }
    }

    /// <summary>
    /// 右へ移動(状態:普通or軽い)
    /// </summary>
    private void RightMove()
    {
        nomalPos.Translate(ShiftMoveSpeed * Time.deltaTime, 0, 0);

        // ゴール地点へ着くと位置を調整して動きを止める
        if (goalShiftPos.anchoredPosition.x <= nomalPos.anchoredPosition.x)
        {
            Debug.Log("ストップ");
            nomalPos.localPosition = goalShiftPos.localPosition;

            isRightMove = false;
        }
    }
}
