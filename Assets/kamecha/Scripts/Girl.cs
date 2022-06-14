using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Girl : MonoBehaviour
{
    public float speed;
    public const float maxHitPoint = 100f;
    public float hitPoint { get; set; } = maxHitPoint;
    public float favorabilityRating { get; set; } = 0;
    private Rigidbody2D rb;
    public bool flagTest;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rotate(3.0f, flagTest);
    }
    void girlMove()
    {
        rb.velocity = new Vector2(speed, 0);
    }
    // Unityのx,y軸で半径radiusで正の方向に回転
    // inversionFlag == true -> 負の方向に回転
    public void rotate(float radius, bool inversionFlag)
    {
        float vx = radius * Mathf.Sin(Time.time * speed);
        vx = -vx;
        float vy = radius * Mathf.Cos(Time.time * speed);
        vy = (inversionFlag) ? -vy : vy;
        rb.velocity = new Vector2(vx, vy);
    }
}
