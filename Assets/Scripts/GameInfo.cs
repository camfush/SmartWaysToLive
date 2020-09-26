﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    public static int PlayerLives;
    public static float TimeMultiplier;
    public static int PlayerScore;

    public static void ResetValues()
    {
        PlayerLives = 3;
        TimeMultiplier = 1;
        PlayerScore = 0;
    }

    public static void IncScore()
    {
        PlayerScore++;
        if (PlayerScore % 5 == 0)
        {
            TimeMultiplier += 0.3f;
        }
    }
}