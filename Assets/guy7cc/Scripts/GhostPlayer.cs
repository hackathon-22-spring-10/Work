using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostPlayer : Player
{
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (active) Move();
        else Stop();
    }

    public void SetAlpha(float t)
    {
        t = Mathf.Max(0, Mathf.Min(1f, t));
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, t);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GhostObstacle")
        {
            //èàóù
        }
    }
}
