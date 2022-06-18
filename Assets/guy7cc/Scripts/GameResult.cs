using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{
    public float hp;
    public float fav;

    public float necessaryFav;

    public Result GetResult()
    {
        if (hp <= 0) return Result.GameOver;
        else if (fav < necessaryFav) return Result.ConfessionFailure;
        else return Result.ConfessionSuccess;
    }

    public enum Result
    {
        GameOver,
        ConfessionFailure,
        ConfessionSuccess
    }
}
