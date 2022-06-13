using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RealPlayer : Player
{
    protected GroundChecker groundChecker;

    private int triggeredObjectNum = 0;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        groundChecker = GetComponentInChildren<GroundChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active) Move();
    }

    private void Move()
    {
        if (Input.GetKeyDown(config.jump) && groundChecker.OnGround) 
        {
            rigid.velocity = new Vector2(rigid.velocity.x, ySpeed);
        }
        float x = 0;
        if (Input.GetKey(config.left)) x -= xSpeed;
        if (Input.GetKey(config.right)) x += xSpeed;
        rigid.velocity = new Vector2(x, rigid.velocity.y);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RealObstacle")
        {
            //èàóù
        }
    }

}
