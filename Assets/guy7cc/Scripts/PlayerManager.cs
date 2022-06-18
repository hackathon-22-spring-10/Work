using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PlayerManager : MonoBehaviour
{
    public PlayerConfig config = new PlayerConfig();  //default value

    public RealPlayer realPlayer;

    public GhostPlayer ghostPlayer;

    public Mode mode;

    private bool active = true;

    private float swapTime;
    public float SwapRate { 
        get
        {
            return Mathf.Max(0, Mathf.Min(1f, swapTime / swapTimeMax));
        } 
    }

    private const float swapTimeMax = 0.15f;

    public void Initialize(PlayerConfig config)
    {
        this.config = config;
        realPlayer.config = config;
        ghostPlayer.config = config;
    }

    // Start is called before the first frame update
    void Start()
    {
        mode = Mode.Real;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (config.GetKeyDown(PlayerConfig.InputType.Swap))
            {
                switch (mode)
                {
                    case Mode.Real:
                        if (swapTime <= 0f) mode = Mode.Ghost;
                        break;
                    case Mode.Ghost:
                        if (swapTime >= swapTimeMax) mode = Mode.Real;
                        break;
                }
            }
            switch (mode)
            {
                case Mode.Real:
                    realPlayer.active = true;
                    ghostPlayer.active = false;
                    if (swapTime > 0) swapTime = Mathf.Max(swapTime - Time.deltaTime, 0);
                    break;
                case Mode.Ghost:
                    realPlayer.active = false;
                    ghostPlayer.active = true;
                    if (swapTime < swapTimeMax) swapTime = Mathf.Min(swapTime + Time.deltaTime, swapTimeMax);
                    break;
            }

            ghostPlayer.SetAlpha(SwapRate * SwapRate);
        }
        else
        {
            realPlayer.active = false;
            ghostPlayer.active = false;
        }
    }

    public void Inactivate()
    {
        active = false;
    }


    public enum Mode
    {
        Real = 0,
        Ghost = 1
    }
}
