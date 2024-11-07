using UnityEngine;
using UnityEngine.SceneManagement;
using PlayerWeight;

/// <summary>
/// プレイヤーの被ダメージ処理
/// </summary>
public class PlayerDamage : MonoBehaviour
{
    /// <summary>
    /// プレイヤーマネージャー
    /// </summary>
    private PlayerManager playerManager;

    /// <summary>
    /// 体力の画像
    /// </summary>
    private LifeUI lifeUI;

    /// <summary>
    /// 無敵時間タイマー
    /// </summary>
    private Timer invincibleTimer;

    /// <summary>
    /// 無敵時間かどうか
    /// </summary>
    private bool isInvincible;

    /// <summary>
    /// 落下が止まっている時のタイマー
    /// </summary>
    private Timer stopTimer;

    /// <summary>
    /// ゲームオーバー計算用タイマー
    /// </summary>
    private Timer gameOverTimer;

    /// <summary>
    /// 見た目点滅用タイマー
    /// </summary>
    private Timer appearanceTimer;

    /// <summary>
    /// 点滅用間隔
    /// </summary>
    private float appearanceInterval = 0.2f;

    /// <summary>
    /// プレイヤースプライトレンダラー
    /// </summary>
    private SpriteRenderer playerSpriteRenderer;

    /// <summary>
    /// 軽い時のプロペラスプライトレンダラー
    /// </summary>
    private SpriteRenderer lightPropellerSpriteRenderer;

    /// <summary>
    /// ステージのスコア
    /// </summary>
    private StageScore stageScore;

    /// <summary>
    /// サウンドマネージャー
    /// </summary>
    private SoundPlayManager soundPlayManager;

    // Start is called before the first frame update
    private void Start()
    {
        // プレイヤーマネージャー取得
        playerManager = PlayerManager.Instance;
        // インスタンス取得
        soundPlayManager = SoundPlayManager.Instance;

        // 体力UI取得
        lifeUI = LifeUI.Instance;

        // 無敵時間タイマー初期化
        invincibleTimer = new();
        // 無敵時間初期化
        isInvincible = false;
        // 停止タイマー初期化
        stopTimer = new();
        // ゲームオーバータイマー初期化
        gameOverTimer = new();
        // 見た目タイマー初期化
        appearanceTimer = new();

        // スプライトレンダラー取得
        playerSpriteRenderer = playerManager.PlayerImage.GetComponent<SpriteRenderer>();
        lightPropellerSpriteRenderer = playerManager.LightPropeller.GetComponent<SpriteRenderer>();

        stageScore = StageScore.Instance;
    }


    private void FixedUpdate()
    {
        // 無敵時間なら無敵時間計算
        if (isInvincible)
        {
            invincibleTimer.Count(Time.deltaTime);

            // 見た目タイマー計算
            StartCalcAppearanceTimer();
        }
        else
        {
            // 見た目タイマーがスタートしていればリセット
            if (appearanceTimer.isTimerStart())
            {
                appearanceTimer.ResetTimer();
            }
        }

        // ゲームオーバータイマーの計算
        gameOverTimer.Count(Time.deltaTime);

        // 見た目用タイマーの計算
        appearanceTimer.Count(Time.deltaTime);

        // ゲームオーバー時の時間計算
        StopTimeCalc();
    }

    /// <summary>
    /// 被ダメージ
    /// </summary>
    /// <param name="damageValue">ダメージ値</param>
    public void TakeDamage(int damageValue)
    {
        // 無敵時間なら終了
        if (isInvincible) return;

        // 無敵時間開始
        StartInvincible();

        // 体力を減らす
        playerManager.HitPoint -= damageValue;

        // 被ダメージの音声再生
        soundPlayManager.PlaySE(SoundPlayManager.SEKey.SE_DAMAGE);

        // 体力表示
        lifeUI.DisplayLife();

        // 体力がなくればゲームオーバー処理
        if (playerManager.HitPoint <= 0)
        {
            GameOver();
        }
    }

    /// <summary>
    /// ゲームオーバー処理
    /// </summary>
    private void GameOver()
    {
        // プレイヤーの移動を停止
        playerManager.IsMovable = false;

        // 死亡フラグを立てる
        playerManager.IsDead = true;

        // スコアを代入して保持する
        stageScore.PlayEndScore();

        // ゲームオーバーのタイマー開始
        gameOverTimer.SetTimer(playerManager.GameOverWait, EndScene);
    }

    /// <summary>
    /// 無敵時間開始
    /// </summary>
    private void StartInvincible()
    {
        isInvincible = true;

        // 無敵時間タイマーを設定
        invincibleTimer.SetTimer(playerManager.InvincibleTime, FinishInvincible);
    }

    /// <summary>
    /// 無敵時間終了
    /// </summary>
    private void FinishInvincible()
    {
        // 無敵フラグをおろす
        isInvincible = false;

        // ダメージの点滅タイマーをリセット
        appearanceTimer.ResetTimer();

        // 各点滅している見た目をリセットする
        ResetAppearance(playerSpriteRenderer);
        ResetAppearance(lightPropellerSpriteRenderer);
    }

    /// <summary>
    /// 落下停止時の時間計算
    /// </summary>
    private void StopTimeCalc()
    {
        // 接地中かつ生きていれば落下停止タイマーを開始
        if (playerManager.IsGround && !playerManager.IsDead)
        {
            // 開始していなければ開始
            if (!stopTimer.isTimerStart())
            {
                stopTimer.SetTimer(playerManager.StopLimit, StopTimeLimit);
            }
            // 開始していればタイマー計算
            else
            {
                stopTimer.Count(Time.deltaTime);
            }
        }

        // 接地中でなければタイマーをリセット
        else
        {
            // タイマーが始まっていればタイマーリセット
            if (stopTimer.isTimerStart())
            {
                stopTimer.ResetTimer();
            }
        }
    }

    /// <summary>
    /// 見た目用タイマーを開始
    /// </summary>
    private void StartCalcAppearanceTimer()
    {
        // タイマーが既に開始していれば終了
        if (appearanceTimer.isTimerStart()) return;

        // タイマーセット
        appearanceTimer.SetTimer(appearanceInterval, DamageAppearance);
    }

    /// <summary>
    /// 被ダメージ時の見た目
    /// </summary>
    private void DamageAppearance()
    {
        // プレイヤーの見た目を点滅させる
        ImageFlashing(playerSpriteRenderer);

        // 軽い時はプロペラも点滅させる
        if (playerManager.GetWeight == Weight.LIGHT)
        {
            ImageFlashing(lightPropellerSpriteRenderer);
        }
    }

    /// <summary>
    /// 画像の点滅
    /// </summary>
    private void ImageFlashing(SpriteRenderer spriteRenderer)
    {
        // 見た目があれば消す
        if (spriteRenderer.color.a > 0.5f)
        {
            var color = spriteRenderer.color;

            color.a = 0.0f;

            spriteRenderer.color = color;
        }
        // なければ出す
        else
        {
            var color = spriteRenderer.color;

            color.a = 1.0f;

            spriteRenderer.color = color;
        }
    }

    /// <summary>
    /// 被ダメージ時の見た目を終了
    /// </summary>
    private void ResetAppearance(SpriteRenderer spriteRenderer)
    {
        // 見える状態にする

        var color = spriteRenderer.color;

        color.a = 1.0f;

        spriteRenderer.color = color;
    }

    /// <summary>
    /// 落下停止時間が終了した時の処理
    /// </summary>
    private void StopTimeLimit()
    {
        // 現存体力分のダメージを食らってゲームオーバーに
        TakeDamage(playerManager.HitPoint);
    }

    /// <summary>
    /// シーン終了
    /// </summary>
    private void EndScene()
    {
        // リザルトシーンへ
        SceneManager.LoadScene("ResultScene");
    }
}
