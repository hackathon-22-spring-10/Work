using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public float speed;
    public const float maxHitPoint = 100f;
    public const float maxFavorability = 100f;
    public float hitPoint
    {
        get { return hitPoint; }
        set
        {
            hitPoint += value;
            if (hitPoint < 0) hitPoint = 0;
            if (hitPoint > maxHitPoint) hitPoint = maxHitPoint;
        }
    }
    public float favorability
    {
        get { return favorability; }
        set
        {
            favorability += value;
            if (favorability < 0) favorability = 0;
            if (favorability > maxFavorability) favorability = maxFavorability;
        }
    }
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        hitPoint = maxHitPoint;
    }

    void Update()
    {
        int pattern = (int)Time.time / 3;
        pattern %= 3;
        patternMove(pattern);
    }
    void right()
    {
        rb.velocity = new Vector2(speed, 0);
    }
    // Unityのx,y軸で半径radiusで正の方向に回転
    // inversionFlag == true -> 負の方向に回転
    public void rotate(float radius, float theta, bool inversionFlag)
    {
        float inversion = (inversionFlag) ? -1f : 1f;
        float vx = -radius * Mathf.Sin(inversion*(Time.time + theta));
        float vy = radius * Mathf.Cos(inversion*(Time.time + theta));
        Vector2 direction = new Vector2(vx, vy).normalized;
        rb.velocity = speed * direction;
    }

    public void wave(float radius) 
    {
        float vx = 1;
        float vy = radius * Mathf.Cos(Time.time);
        Vector2 direction = new Vector2(vx, vy).normalized;
        rb.velocity = speed * direction;
    }

    public void moveTo(Vector2 destination)
    {
        Vector2 nowPosition = transform.position;
        Vector2 direction = (destination - nowPosition).normalized;
        rb.velocity = speed * direction;
    }

    public void checkDistance(){
        float vx = rb.velocity.x;
        float vy = rb.velocity.y;
        if (transform.position.y > upperBound) vy = Mathf.Min(0, vy);
        if (transform.position.y < lowerBound) vy = Mathf.Max(0, vy);
        if (transform.position.x > rightBound) vx = Mathf.Min(0, vx);
        if (transform.position.x < leftBound) vx = Mathf.Max(0, vx);
        Vector2 direction = new Vector2(vx, vy).normalized;
        rb.velocity = speed * direction;
    }

    public void patternMove(int pattern) {
        switch (pattern)
        {
            case 0:
            case 1:
            right();
            checkDistance();
            break;
            case 2:
            wave(2.0f);
            checkDistance();
            break;
            default:
            break;
        }
    }
}
