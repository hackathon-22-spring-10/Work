using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerConfig
{
    
    private Dictionary<InputType, KeyCode[]> dic;

    public PlayerConfig()
    {
        KeyCode[] up = new KeyCode[] { KeyCode.W, KeyCode.UpArrow };
        KeyCode[] down = new KeyCode[] { KeyCode.S, KeyCode.DownArrow };
        KeyCode[] left = new KeyCode[] { KeyCode.A, KeyCode.LeftArrow };
        KeyCode[] right = new KeyCode[] { KeyCode.D, KeyCode.RightArrow };
        KeyCode[] swap = new KeyCode[] { KeyCode.F, KeyCode.Space };
        dic = new Dictionary<InputType, KeyCode[]>();
        dic.Add(InputType.Up, up);
        dic.Add(InputType.Down, down);
        dic.Add(InputType.Left, left);
        dic.Add(InputType.Right, right);
        dic.Add(InputType.Swap, swap);
    }

    public bool GetKeyDown(InputType type)
    {
        foreach(KeyCode code in dic[type])
        {
            if (Input.GetKeyDown(code)) return true;
        }
        return false;
    }

    public bool GetKey(InputType type)
    {
        foreach(KeyCode code in dic[type])
        {
            if (Input.GetKey(code)) return true;
        }
        return false;
    }

     
    public enum InputType
    {
        Up, 
        Down, 
        Left,
        Right,
        Swap
    }
}
