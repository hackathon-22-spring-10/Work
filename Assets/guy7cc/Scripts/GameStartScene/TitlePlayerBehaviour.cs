using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitlePlayerBehaviour : MonoBehaviour
{
    public Sprite naturalFace;
    public Sprite watchingFace;
    public Sprite closedEyeFace;
    public Sprite naturalFaceGirl;
    public Sprite closedEyeFaceGirl;
    private ButtonBehaviour exitButton;
    private AudioSource audio;

    private SpriteRenderer spriteRenderer;

    public AudioClip footstep;

    public bool cleared = false;  //ÉNÉäÉAå„ÇÕèóÇÃéqÇ…Ç»ÇÈ

    private Vector2 initPos;
    private float timeUntilBlink = 1f;

    private bool moving = false;
    private float movingTime = 0;
    private float nextFootStepTime = 0.5f;

    private void Awake()
    {
        exitButton = GameObject.Find("ExitButton").GetComponent<ButtonBehaviour>();
        audio = GameObject.Find("AudioSource").GetComponent<AudioSource>();
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
        timeUntilBlink -= Time.deltaTime;
        if (!cleared)
        {
            transform.localScale = new Vector2(50, 50);
            if (exitButton.MouseOn) spriteRenderer.sprite = watchingFace;
            else spriteRenderer.sprite = naturalFace;
            if(timeUntilBlink < 0f) spriteRenderer.sprite = closedEyeFace;
        }
        else
        {
            transform.localScale = new Vector2(40, 40);
            if (exitButton.MouseOn) spriteRenderer.sprite = naturalFaceGirl;
            else spriteRenderer.sprite = naturalFaceGirl;
            if (timeUntilBlink < 0f) spriteRenderer.sprite = closedEyeFaceGirl;
        }

        if(timeUntilBlink < -0.1f)
        {
            if(Random.Range(0f, 1f) >= 0.2f) timeUntilBlink = Random.Range(2f, 8f);
            else timeUntilBlink = Random.Range(0.25f, 0.5f);
        }

        if (moving)
        {
            movingTime += Time.deltaTime;
            Vector2 cyc = EasingFunc.Cycloid(0.75f, movingTime * 4 * Mathf.PI);
            transform.position = initPos + new Vector2(cyc.x / 1.5f, cyc.y / 2f);
            if(movingTime >= nextFootStepTime)
            {
                nextFootStepTime += 0.5f;
                audio.PlayOneShot(footstep, Mathf.Exp(-movingTime));
            }
        }

        
    }


    public void StartMoving()
    {
        moving = true;
    }

    
}
