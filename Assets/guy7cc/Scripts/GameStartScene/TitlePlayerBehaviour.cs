using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayerBehaviour : MonoBehaviour
{
    public Sprite naturalFace;
    public Sprite watchingFace;
    public Sprite naturalFaceGirl;
    private ButtonBehaviour exitButton;

    private SpriteRenderer spriteRenderer;

    public bool cleared = false;  //ÉNÉäÉAå„ÇÕèóÇÃéqÇ…Ç»ÇÈ

    private Vector2 initPos;
    private bool moving = false;
    private float movingTime = 0;

    private void Awake()
    {
        exitButton = GameObject.Find("ExitButton").GetComponent<ButtonBehaviour>();
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!cleared)
        {
            transform.localScale = new Vector2(50, 50);
            if (exitButton.MouseOn)
            {
                spriteRenderer.sprite = watchingFace;
            }
            else
            {
                spriteRenderer.sprite = naturalFace;
            }
        }
        else
        {
            transform.localScale = new Vector2(40, 40);
            if (exitButton.MouseOn)
            {
                spriteRenderer.sprite = naturalFaceGirl;
            }
            else
            {
                spriteRenderer.sprite = naturalFaceGirl;
            }
        }

        if (moving)
        {
            movingTime += Time.deltaTime;
            Vector2 cyc = EasingFunc.Cycloid(0.75f, movingTime * 4 * Mathf.PI);
            transform.position = initPos + new Vector2(cyc.x / 1.5f, cyc.y / 2f);
        }

        
    }


    public void StartMoving()
    {
        moving = true;
    }

    
}
