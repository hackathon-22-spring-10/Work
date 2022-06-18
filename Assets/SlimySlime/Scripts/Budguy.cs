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
        //—‚ÌŽq‚ð’Ç‚¢‚©‚¯‚é
        if (Vector2.Distance(transform.position, girlTF.position) > 0.4f)
        {
            rb.position += moveSpeed * Time.deltaTime * (Vector2)(girlTF.position - this.transform.position).normalized;
        }

        if (girlTF.position.x < transform.position.x)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = true;
        }
    }

    public override IEnumerator AttackGirl(Girl girl)
    {
        //yield return new WaitForSeconds(0.1f);
        while (true)
        {
            animator.SetTrigger("AttackTrigger");
            yield return new WaitForSeconds(0.1f);
            girl.getDamage(damage);
            yield return new WaitForSeconds(1f);
        }
    }
}
