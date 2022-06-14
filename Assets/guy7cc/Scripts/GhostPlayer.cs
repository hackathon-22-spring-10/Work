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

    private void Move()
    {
        float x = 0;
        float y = 0;
        if (Input.GetKey(config.left)) x -= xSpeed;
        if (Input.GetKey(config.right)) x += xSpeed;
        if (Input.GetKey(config.down)) y -= ySpeed;
        if (Input.GetKey(config.jump)) y += ySpeed;
        rigid.velocity = new Vector2(x, y);
    }
}
