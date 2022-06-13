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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        girlMove();
    }

    void girlMove()
    {
        rb.velocity = new Vector2(speed, 0);
    }
}
