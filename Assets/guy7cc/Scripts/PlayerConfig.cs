using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig
{
    public KeyCode jump;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode action;

    public PlayerConfig()
    {
        jump = KeyCode.W;
        down = KeyCode.S;
        left = KeyCode.A;
        right = KeyCode.D;
        action = KeyCode.Space;
    }
     
    
}
