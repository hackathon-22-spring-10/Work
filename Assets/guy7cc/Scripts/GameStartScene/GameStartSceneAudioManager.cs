using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartSceneAudioManager : MonoBehaviour
{


    private AudioSource audio;
    private AudioSource intro;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        intro = GameObject.Find("AudioSourceIntro").GetComponent<AudioSource>();
        intro.PlayScheduled(AudioSettings.dspTime);
        audio.PlayScheduled(AudioSettings.dspTime + 1.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
