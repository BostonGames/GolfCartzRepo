using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int ballsHit;
    public int points;

    // change this to a list or array later to automatically find the length:
    public int checkpointsTotal = 5;
    public int checkpointsPassed;

    private void Awake()
    {
        instance = this;

        ballsHit = 0;
        points = 0;
        checkpointsPassed = 0;
    }

    public void BallHit()
    {
        ballsHit++;
    }

    public void AdjustPoints(int adjustThisMuch)
    {
        points = points + (adjustThisMuch);
    }


    public void ResetGameValues()
    {
        ballsHit = 0;
        points = 0;
        checkpointsPassed = 0;
    }
}
