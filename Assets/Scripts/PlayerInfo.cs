using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerInfo 
{
    public static int countLevels;
    public static string loginPlayer;
    public static int coins =0;
    public static float time = 0.0f;

    public static int ReturnLevel()
    {
        return countLevels;
    }
}
