using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Obstacle
{
    [SerializeField]private float moveSpeed;
    private Transform girlTF;
    [SerializeField]private Rigidbody2D rb;
    [SerializeField]private ParticleSystem particle;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        girlTF = GameObject.FindWithTag("Girl").transform;
        audioSource = FindObjectOfType<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        //—‚ÌŽq‚ð’Ç‚¢‚©‚¯‚é
        if (Vector2.Distance(transform.position, girlTF.position) > 0.3f)
        {
            rb.position += moveSpeed * Time.deltaTime * (Vector2)(girlTF.position - this.transform.position).normalized;
        }

        if(girlTF.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    public override IEnumerator AttackGirl(Girl girl)
    {
        //yield return new WaitForSeconds(0.1f);
        while (true)
        {
            particle.Play();
            girl.hitPoint -= damage;
            audioSource.PlayOneShot(attackSound);

            yield return new WaitForSeconds(1f);
        }
    }

    public override IEnumerator Killed()
    {
        moveSpeed = 0;
        audioSource.PlayOneShot(deathSound);
        return base.Killed();
    }
}
