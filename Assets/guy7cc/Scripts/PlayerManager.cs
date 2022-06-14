using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerConfig config = new PlayerConfig();  //default value

    public RealPlayer realPlayer;

    public GhostPlayer ghostPlayer;

    public Mode mode;

    public void Initialize(PlayerConfig config)
    {
        this.config = config;
        realPlayer.config = config;
        ghostPlayer.config = config;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(config.swap))
        {
            switch (mode) 
            {
                case Mode.Real:
                    mode = Mode.Ghost;
                    break;
                case Mode.Ghost:
                    mode = Mode.Real;
                    break;
            }
        }
        switch (mode)
        {
            case Mode.Real:
                realPlayer.active = true;
                ghostPlayer.active = false;
                break;
            case Mode.Ghost:
                realPlayer.active = false;
                ghostPlayer.active = true;
                break;
        }
    }

    public enum Mode
    {
        Real = 0,
        Ghost = 1
    }
}
