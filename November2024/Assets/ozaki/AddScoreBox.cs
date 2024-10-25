using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreBox : MonoBehaviour
{
    private PlayerManager playerManager;
    private StageScore stageScore;

    Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.Instance;
        stageScore = StageScore.Instance;
    }

    private void FixedUpdate()
    {
        playerPos = playerManager.transform.position;

        if(playerPos.y <= this.gameObject.transform.position.y)
        {
            stageScore.AddScore();
        }
    }
}
