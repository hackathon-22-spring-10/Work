using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private Collider2D col;
    [SerializeField] protected SpriteRenderer sprite;

    //protected bool attackingGirl = false;
    protected Coroutine attackCoroutine;


    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(1);
        if ((collision.CompareTag("RealPlayer") && this.CompareTag("RealObstacle")) || (collision.CompareTag("GhostPlayer") && this.CompareTag("GhostObstacle")))
        {
            StartCoroutine(Killed());
        }
        else if (collision.CompareTag("Girl"))
        {
            Debug.Log(2);
            attackCoroutine = StartCoroutine(AttackGirl());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            StopCoroutine(attackCoroutine);
        }
    }

    public float GetObstacleDamage()
    {
        return damage;
    }

    public virtual IEnumerator AttackGirl()
    {
        //Á–Å‚·‚éˆ—

        yield return new WaitForEndOfFrame();
        Destroy(gameObject);
    }

    public virtual IEnumerator Killed()
    {
        col.enabled = false;
        if (attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
        }
        while (sprite.color.a >= 0)
        {
            sprite.color = new Color(1, 1, 1, sprite.color.a - 0.5f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        Destroy(gameObject);
    }

}
