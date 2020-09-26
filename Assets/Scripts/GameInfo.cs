using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo
{
    public static int PlayerLives;
    public static int PlayerScore;
    public static int Tick;
    public static int TickRate;

    public static void ResetValues()
    {
        PlayerLives = 3;
        PlayerScore = 0;
        Tick = 0;
    }

    public static bool IncTick()
    {
        Tick += 1;
        if (Tick % TickRate == 0)
        {
            return true;
        }
        return false;
    }

    public static void IncScore()
    {
        PlayerScore++;
        if (PlayerScore % 5 == 0)
        {
            TickRate -= 1;
        }
    }
}
