using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �e
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// �ړ����x
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// �E�����ɔ�Ԃ�
    /// </summary>
    private bool isRight;

    // Start is called before the first frame update
    private void Start()
    {
        // �E�����ŏ�����
        isRight = true;
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// ���ˏ���
    /// </summary>
    /// <param name="shotRight">���˕���</param>
    public void Shot(bool shotRight)
    {
        // ���˕���������
        isRight = shotRight;
    }

    /// <summary>
    /// �e�̈ړ�
    /// </summary>
    private void Move()
    {
        var movePos = transform.position;

        // �ړ����Z
        movePos.x += moveSpeed * Time.deltaTime;

        // ���W�𔽉f
        transform.position = movePos;
    }

    // �����鏈���Ɠ����蔻��
}
