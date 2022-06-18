using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneAudioManager : MonoBehaviour
{
    public AudioClip clear;
    public AudioClip dead;

    private PlayerManager playerManager;

    private AudioSource audio;
    private AudioLowPassFilter low;
    private AudioReverbFilter reverb;
    private AudioDistortionFilter dist;

    private bool isEnding = false;
    

    private void Awake()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
        audio = GetComponent<AudioSource>();
        low = GetComponent<AudioLowPassFilter>();
        reverb = GetComponent<AudioReverbFilter>();
        dist = GetComponent<AudioDistortionFilter>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnding)
        {
            ManageFilter();
        }
        else
        {
            InactivateFilter();
        }
    }

    private void ManageFilter()
    {
        float t = playerManager.SwapRate;
        low.cutoffFrequency = 600 * t + 22000 * (1 - t);
        if (t <= 0f) reverb.enabled = false;
        else
        {
            reverb.enabled = true;
            reverb.reverbLevel = 100 * t;
        }
        dist.distortionLevel = 0.5f * t;
    }
    public void SetClear()
    {
        audio.clip = clear;
        audio.loop = false;
        audio.Play();
        isEnding = true;
    }

    public void SetDead()
    {
        audio.clip = dead;
        audio.Play();
        isEnding = true;
    }

    private void InactivateFilter()
    {
        low.enabled = false;
        reverb.enabled = false;
        dist.enabled = false;
    }
}
