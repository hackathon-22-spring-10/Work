using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Budguy : Obstacle
{
    [SerializeField]private float moveSpeed;
    private Transform girlTF;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        girlTF = GameObject.FindWithTag("Girl").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //女の子を追いかける
        if (Vector2.Distance(transform.position, girlTF.position) > 0.3f)
        {
            rb.position += moveSpeed * Time.deltaTime * (Vector2)(girlTF.position - this.transform.position).normalized;
        }

        if (girlTF.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    public override IEnumerator AttackGirl()
    {
        //yield return new WaitForSeconds(0.1f);
        while (true)
        {
            yield return new WaitForSeconds(1f);
        }
    }
}
