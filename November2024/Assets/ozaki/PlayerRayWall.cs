using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerRayWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }


    private void RayChack()
    {
        RaycastHit2D[] hits;

        hits = Physics2D.RaycastAll((new Vector2(transform.position.x - 10.0f, transform.position.y + 10.0f)),
                                     transform.right,
                                     100.0f);

        foreach (RaycastHit2D hit in hits)
        {
            hit.collider.GetComponent<DestroyObj>().Destroy();
        }
    }
}
