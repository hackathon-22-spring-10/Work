using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool OnGround
    {
        get
        {
            return triggered > 0;
        }
    }

    [SerializeField]
    private int triggered;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Stage") ++triggered;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Stage") --triggered;
    }
}
