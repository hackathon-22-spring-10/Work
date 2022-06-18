using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public float hp;
    public float favorability;

    public float necessaryFav;

    public Result GetResult()
    {
        if (hp <= 0) return Result.GameOver;
        else if (favorability < necessaryFav) return Result.ConfessionFailure;
        else return Result.ConfessionSuccess;
    }

    public enum Result
    {
        GameOver,
        ConfessionFailure,
        ConfessionSuccess
    }
}
