using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public static class GameInfo
{
    public static int PlayerLives;
    public static int PlayerScore;
    public static float SpeedMultiplier;

    public static void ResetValues()
    {
        PlayerLives = 3;
        PlayerScore = 0;
    }

    public static void IncScore()
    {
        PlayerScore++;
        if (PlayerScore % 5 == 0)
        {
            SpeedMultiplier += 0.2f;
        }
    }
}
