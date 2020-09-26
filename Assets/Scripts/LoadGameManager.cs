using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class LoadGameManager
{
    private static List<string> AvailableGames = new List<string>() { "CovidRoad", "HandWashing", "SickEscapees", "NoSneeze", "Pong" };
    private static Queue<string> PreviouslyPlayed = new Queue<string>();

    public static string GetAvailableGame()
    {
        string result;
        result = AvailableGames[Random.Range(0, AvailableGames.Count)];
        AvailableGames.Remove(result);
        PreviouslyPlayed.Enqueue(result);
        if (PreviouslyPlayed.Count > 2)
        {
            string dequeued = PreviouslyPlayed.Dequeue();
            AvailableGames.Add(dequeued);
        }
        return result;
    }
}
