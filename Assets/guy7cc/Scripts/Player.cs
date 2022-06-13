using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerConfig config = new PlayerConfig();  //default config

    public bool active = false;

    public float xSpeed;

    public float ySpeed;

    protected Rigidbody2D rigid;

    // Start is called before the first frame update
    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

}
