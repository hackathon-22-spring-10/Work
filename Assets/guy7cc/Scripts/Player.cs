using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    public PlayerConfig config = new PlayerConfig();  //default config

    public bool active = false;

    public float xSpeed;

    public float ySpeed;

    protected Rigidbody2D rigid;

    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;

    protected MoveDirection preDirection;
    protected MoveDirection direction;

    // Start is called before the first frame update
    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        preDirection = MoveDirection.Right;
        direction = MoveDirection.None;
    }

    protected void Move()
    {
        float x = 0;
        float y = 0;
        if (Input.GetKey(config.left)) x -= xSpeed;
        if (Input.GetKey(config.right)) x += xSpeed;
        if (Input.GetKey(config.down)) y -= ySpeed;
        if (Input.GetKey(config.jump)) y += ySpeed;
        if (transform.position.y > upperBound) y = Mathf.Min(0, y);
        if (transform.position.y < lowerBound) y = Mathf.Max(0, y);
        if (transform.position.x > rightBound) x = Mathf.Min(0, x);
        if (transform.position.x < leftBound) x = Mathf.Max(0, x);
        rigid.velocity = new Vector2(x, y);

        if (x > 0) direction = MoveDirection.Right;
        else if (x < 0) direction = MoveDirection.Left;
        else
        {
            if (y > 0) direction = MoveDirection.Up;
            else if (y < 0) direction = MoveDirection.Down;
            else
            {
                if (direction != MoveDirection.None) preDirection = direction;
                direction = MoveDirection.None;
            }
        }
    }
    protected void Stop()
    {
        rigid.velocity = Vector2.zero;
        if (direction != MoveDirection.None) preDirection = direction;
        direction = MoveDirection.None;
    }
}
