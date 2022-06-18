using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public float speed;
    public const float maxHitPoint = 100f;
    public const float maxFavorability = 100f;
    public float hitPoint = maxHitPoint;
    public float favorability = maxFavorability;
    private Rigidbody2D rb;
    public float upperBound;
    public float lowerBound;
    public float leftBound;
    public float rightBound;

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "RealPlayer":
            // Debug.Log("告白されちゃった");
            break;
            case "RealObstacle":
            hitPoint -= collision.gameObject.GetComponent<Obstacle>().GetObstacleDamage();
            if (hitPoint < 0)
            {
                hitPoint = 0;
            }
            // Debug.Log("HP下がっちゃった...");
            break;
            case "GhostObstacle":
            favorability -= collision.gameObject.GetComponent<Obstacle>().GetObstacleDamage();
            if (favorability < 0)
            {
                favorability = 0;
            }
            // Debug.Log("好感度下がっちゃった...");
            break;

        }
    }

    public void getDamage(float damage)
    {
        hitPoint -= damage;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // rotate(3.0f, Mathf.PI/2, flagTest);
    }
    void right()
    {
        rb.velocity = new Vector2(speed, 0);
    }
    // Unityのx,y軸で半径radiusで正の方向に回転
    // inversionFlag == true -> 負の方向に回転
    public void rotate(float radius, float theta, bool inversionFlag)
    {
        float vx = radius * Mathf.Sin(Time.time * speed + theta);
        vx = -vx;
        float vy = radius * Mathf.Cos(Time.time * speed + theta);
        vy = (inversionFlag) ? -vy : vy;
        rb.velocity = new Vector2(vx, vy);
    }

    public void wave(float radius) 
    {
        float vx = speed;
        float vy = radius * Mathf.Sin(Time.time * speed);
        rb.velocity = new Vector2(vx, vy);
    }

    public void checkDistance(){
        float x = rb.velocity.x;
        float y = rb.velocity.y;
        // Debug.Log(transform.position);
        if (transform.position.y > upperBound) y = Mathf.Min(0, y);
        if (transform.position.y < lowerBound) y = Mathf.Max(0, y);
        if (transform.position.x > rightBound) x = Mathf.Min(0, x);
        if (transform.position.x < leftBound) x = Mathf.Max(0, x);
        rb.velocity = new Vector2(x, y);
    }

    public void patternMove(int pattern) {
        switch (pattern)
        {
            case 0:
            right();
            checkDistance();
            break;
            // case 1:
            // rotate(3.0f, Mathf.PI/2, false);
            // checkDistance();
            // break;
            case 2:
            wave(2.0f);
            checkDistance();
            break;
            default:
            break;
        }
    }
}
