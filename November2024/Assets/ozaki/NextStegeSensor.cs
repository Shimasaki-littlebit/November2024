using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NextStegeSensor : MonoBehaviour
{
    private LayerMask playerMask = 1 << 3;
    private float height;

    private StageManager stageManager;
    private bool hit = false;
    // Start is called before the first frame update
    void Start()
    {
        stageManager = StageManager.Instance;
        height = stageManager.ArrayHeight * 0.5f;
        Debug.Log(height);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hit && Physics2D.Raycast(transform.position,
                             transform.right,
                             20.0f,
                             playerMask))
        {
            hit = true;
            NextStageCreate();
        }
    }

    private void NextStageCreate()
    {
        stageManager.NextStageGenetator(stageManager.Data, transform.position.y - height);
        Debug.Log(stageManager.Data);
        Debug.Log(transform.position.y - height);
    }
}
