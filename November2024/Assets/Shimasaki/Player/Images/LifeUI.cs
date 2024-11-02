using UnityEngine;

/// <summary>
/// 体力UI表示
/// </summary>
public class LifeUI : SingletonMonoBehaviour<LifeUI>
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// 体力表示用UI
    /// </summary>
    [SerializeField]
    private GameObject[] lifeImages;

    // Start is called before the first frame update
    private void Start()
    {
        // インスタンスを取得
        playerManager = PlayerManager.Instance;

        // ライフ初期化
        foreach (GameObject lifeImage in lifeImages)
        {
            lifeImage.SetActive(true);
        }
    }

    /// <summary>
    /// ライフ表示
    /// </summary>
    public void DisplayLife()
    {
        // ライフUI添え字用
        int lifeUINum = 0;

        // ライフUIを見る
        foreach (var lifeImage in lifeImages)
        {
            // ライフに応じてUI表示
            if (lifeUINum < playerManager.HitPoint)
            {
                lifeImage.SetActive(true);
            }
            else
            {
                lifeImage.SetActive(false);
            }

            // 添え字番号を増加
            ++lifeUINum;
        }
    }
}
