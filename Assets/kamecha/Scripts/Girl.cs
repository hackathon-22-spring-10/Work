using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public float speed;
    public const float maxHitPoint = 100f;
    public const float maxFavorabilityRating = 100f;
    public float hitPoint = maxHitPoint;
    public float favorabilityRating = 0;
    private Rigidbody2D rb;
    public bool flagTest;

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "RealPlayer":
            Debug.Log("告白されちゃった");
            break;
            case "RealObstacle":
            Debug.Log("HP下がっちゃった...");
            break;
            case "GhostObstacle":
            Debug.Log("好感度下がっちゃった...");
            break;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // rotate(3.0f, Mathf.PI/2, flagTest);
        patternMove(Random.Range(0, 3));
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

    public void patternMove(int pattern) {
        switch (pattern)
        {
            case 0:
            right();
            break;
            case 1:
            rotate(3.0f, Mathf.PI/2, false);
            break;
            case 2:
            wave(2.0f);
            break;
            default:
            break;
        }
    }
}
