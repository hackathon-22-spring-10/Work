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
        float horizontalKey = Input.GetAxis("Horizontal");
        if (horizontalKey > 0)
        {
            Debug.Log("a");
            rb.velocity = new Vector2(speed, 0);
        }
        else if (horizontalKey < 0)
        {
            Debug.Log("b");
            rb.velocity = new Vector2(-speed, 0);
        }
        else
        {
            Debug.Log("c");
            rb.velocity = Vector2.zero;
        }

    }
}
