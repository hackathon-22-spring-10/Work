using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class RealPlayer : Player
{
    private Animator animator;

    // Start is called before the first frame update
    public void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active) Move();
        else Stop();
        ManageAnimation();
    }

    private void ManageAnimation()
    {
        animator.SetBool("moving", direction != MoveDirection.None);
        animator.SetInteger("direction", direction != MoveDirection.None ? (int)direction : (int)preDirection);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "RealObstacle")
        {
            //èàóù
        }
    }

}
