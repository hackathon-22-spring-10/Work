using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Budguy : Obstacle
{
    [SerializeField]private float moveSpeed;
    private Transform girlTF;
    [SerializeField] private Animator animator;
    private Coroutine moveCoroutine;
    private AudioSource audioSource;
    private Animator girlAnimator;


    // Start is called before the first frame update
    void Start()
    {
        girlTF = GameObject.FindWithTag("Girl").transform;
        girlAnimator = girlTF.GetComponent<Animator>();
        moveCoroutine = StartCoroutine(Move());
        audioSource = FindObjectOfType<AudioSource>();
    }


    private IEnumerator Move()
    {
        while (true)
        {
            //女の子を追いかける
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
            yield return new WaitForEndOfFrame();
        }
    }

    public override IEnumerator AttackGirl(Girl girl)
    {
        //yield return new WaitForSeconds(0.1f);
        while (true)
        {
            animator.SetTrigger("AttackTrigger");
            yield return new WaitForSeconds(0.1f);
            audioSource.PlayOneShot(attackSound, 0.3f);
            girl.hitPoint -= damage;
            girlAnimator.SetTrigger("isAttacked");
            yield return new WaitForSeconds(1f);
        }
    }

    public override IEnumerator Killed()
    {
        StopCoroutine(moveCoroutine);

        col.enabled = false;
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }

        audioSource.PlayOneShot(deathSound, 0.3f);
        rb.velocity = (transform.position - girlTF.position).normalized * 10;
        yield return new WaitForSeconds(0.3f);
        rb.velocity = Vector2.zero;

        while (sprite.color.a >= 0)
        {
            sprite.color = new Color(1, 1, 1, sprite.color.a - (3f * Time.deltaTime));
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }
}
