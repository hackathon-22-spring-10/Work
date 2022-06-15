using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Obstacle
{
    [SerializeField]private float moveSpeed;
    private Transform girl;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        isRealObstacle = false;
        rb = GetComponent<Rigidbody2D>();
        girl = GameObject.FindWithTag("Girl").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //���̎q��ǂ�������
        if (!attackingGirl)
        {
            rb.position += moveSpeed * Time.deltaTime * (Vector2)(girl.position - this.transform.position).normalized;
        }
    }
}
