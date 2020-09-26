using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public static class LoadGameManager
{
    private static List<string> AvailableGames = new List<string>() { "CovidRoad", "HandWashing", "CovidRoad", "HandWashing" };
    private static Queue<string> PreviouslyPlayed = new Queue<string>();

    public static string GetAvailableGame()
    {
        string result;
        result = AvailableGames[Random.Range(0, AvailableGames.Count - 1)];
        AvailableGames.Remove(result);
        PreviouslyPlayed.Enqueue(result);
        if (PreviouslyPlayed.Count > 2)
        {
            string dequeued = PreviouslyPlayed.Dequeue();
            if (dequeued != "")
            {
                AvailableGames.Add(dequeued);
            }
        }
        return result;
    }
}
