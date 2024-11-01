using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreBox : MonoBehaviour
{
    private PlayerManager playerManager;
    private StageScore stageScore;

    Vector2 playerPos;

    bool isAddedScore;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = PlayerManager.Instance;
        stageScore = StageScore.Instance;

        isAddedScore = false;
    }

    private void FixedUpdate()
    {
        playerPos = playerManager.transform.position;

        if(playerPos.y <= this.gameObject.transform.position.y && !isAddedScore)
        {
            stageScore.AddScore();

            isAddedScore = true;
        }
    }
}
