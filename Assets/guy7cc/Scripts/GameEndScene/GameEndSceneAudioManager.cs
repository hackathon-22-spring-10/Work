using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndSceneAudioManager : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip gameOver;
    public AudioClip confessionFailure;
    public AudioClip confessionSuccess;

    private GameObject result;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        result = GameObject.Find("GameResult");
        switch (result != null ? result.GetComponent<GameResult>().GetResult() : GameResult.Result.GameOver)
        {
            case GameResult.Result.GameOver:
                audio.clip = gameOver;
                break;
            case GameResult.Result.ConfessionFailure:
                audio.clip = confessionFailure;
                break;
            case GameResult.Result.ConfessionSuccess:
                audio.clip = confessionSuccess;
                break;
        }
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
