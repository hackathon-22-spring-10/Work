using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float damage;
    protected bool attackingGirl = false;
    protected bool isRealObstacle = true;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.CompareTag("RealPlayer") && isRealObstacle) || (collision.CompareTag("GhostPlayer") && !isRealObstacle))
        {

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Girl"))
        {
            attackingGirl = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Girl"))
        {
            attackingGirl = false;
        }
    }

    public float GetObstacleDamage()
    {
        return damage;
    }


}
