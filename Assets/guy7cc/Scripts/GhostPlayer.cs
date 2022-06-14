using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : Player
{
    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
    }

    void Update()
    {
        if (active) Move();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GhostObstacle")
        {
            //èàóù
        }
    }
}
