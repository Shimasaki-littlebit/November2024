using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ’e
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// ˆÚ“®‘¬“x
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// ‰EŒü‚«‚É”ò‚Ô‚©
    /// </summary>
    private bool isRight;

    // Start is called before the first frame update
    private void Start()
    {
        // ‰EŒü‚«‚Å‰Šú‰»
        isRight = true;
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// ”­Ëˆ—
    /// </summary>
    /// <param name="shotRight">”­Ë•ûŒü</param>
    public void Shot(bool shotRight)
    {
        // ”­Ë•ûŒü‚ğŒˆ’è
        isRight = shotRight;
    }

    /// <summary>
    /// ’e‚ÌˆÚ“®
    /// </summary>
    private void Move()
    {
        var movePos = transform.position;

        // ˆÚ“®‰ÁZ
        movePos.x += moveSpeed * Time.deltaTime;

        // À•W‚ğ”½‰f
        transform.position = movePos;
    }

    // Á‚¦‚éˆ—‚Æ“–‚½‚è”»’è
}
