using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerRayWall : MonoBehaviour
{
    private void RayChack()
    {
        RaycastHit2D[] hits;

        hits = Physics2D.RaycastAll((new Vector2(transform.position.x - 30.0f, transform.position.y + 20.0f)),
                                     transform.right,
                                     100.0f);

        foreach (RaycastHit2D hit in hits)
        {
            hit.collider.GetComponent<DestroyObj>().Destroy();
        }
    }
}
